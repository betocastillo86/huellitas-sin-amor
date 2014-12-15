var AdoptarView = Backbone.View.extend({

    el: "#divAdopcion",

    idContenido: 0,

    vistaZonas: undefined,

    formulario: undefined,

    pasoActual : 1,

    events: {
        "click #btnSiguiente" : "siguiente"
    },

    initialize: function (args)
    {
        this.idContenido = args.id;
        this.vistaZonas = new ZonasGeograficasView({ el: this.el });
        this.$("#Usuario_FechaNacimiento").datepicker();
        this.formulario = $(this.$("form")[0]);
    },
    siguiente: function (args)
    {
        if (this.formulario.validate().form() && this.validarPreguntas()) {

            //Si el paso es el 4 envia el formulario
            if (this.pasoActual == 4) {
                this.formulario.submit();
            }
            else {
                this.marcarPasoActual(true);
            }
        }
        
    },
    validarPreguntas : function()
    {
        if (this.pasoActual > 1) {

            var valido = true;

            var elemento = this.$(".seccionPreguntas")[this.pasoActual - 2];
            _.each($(elemento).find(".preguntasFormulario"), function (pregunta) {
                //Si alguna preguntaestá sin chequear retorna false
                if ($(pregunta).find("input:checked").length == 0)
                    valido = false;
            });

            if (!valido)
                alert("Todas las preguntas deben ser respondidas");

            return valido;
        }
        else
            return true;

    },
    marcarPasoActual: function (adelante)
    {
        var pasoAnterior = this.pasoActual;

        if (adelante)
            this.pasoActual++;
        else
            this.pasoActual--;

        this.$(".conte_pasos .active").removeClass("active");
        $(this.$(".conte_pasos li")[this.pasoActual - 1]).addClass("active");
        this.$("#paso" + this.pasoActual).show();
        this.$("#paso" + pasoAnterior).hide();

        this.$("#btnSiguiente").html(this.pasoActual != 4 ? "SIGUIENTE" : "FINALIZAR");

    }

});