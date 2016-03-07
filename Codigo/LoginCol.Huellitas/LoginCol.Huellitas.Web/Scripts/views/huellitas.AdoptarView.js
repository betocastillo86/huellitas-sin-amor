var AdoptarView = Backbone.View.extend({

    el: "#divAdopcion",


    idContenido: 0,

    vistaZonas: undefined,

    formulario: undefined,

    pasoActual: 1,

    templateCampoEdad: _.template("<input class='grid_1 edades' placeholder='EDAD <%=obj%>'  customval='int'  />"),

    events: {
        "click #btnSiguiente": "siguiente",
        "click #btnCerrarCondiciones": 'cerrarCondiciones',
        'change #MiembrosFamilia': 'cargarCamposEdades',
        'change .edades': 'llenarEdades',
        "click input[name='pregunta14']": "cargarAnteriorMascota",
        "click input[name='pregunta15']": "cargarActualMascota",
    },

    initialize: function (args)
    {
        this.idContenido = args.id;
        this.vistaZonas = new ZonasGeograficasView({ el: this.el });
        this.$("#Usuario_FechaNacimiento").datepicker({ maxDate: '-18y', changeYear: true, changeMonth : true });
        
        this.formulario = $(this.$("form")[0]);

        this.$("#divInfoAdopcion").dialog({ modal: true });
        this.ocultarPreguntas();
        
    },
    siguiente: function (args)
    {
        if (this.validarFormulario() && this.validarPreguntas()) {

            //Si el paso es el 4 envia el formulario
            if (this.pasoActual == 4) {
                MostrarCargandoTodo(true);
                this.formulario.submit();
            }
            else {
                this.marcarPasoActual(true);
            }
        }

        
    },
    validarFormulario : function()
    {
        if (!this.formulario.validate().form())
        {
            alert("Por favor complete todos los campos");
        }
        else
            return true;
    },
    ocultarPreguntas : function()
    {
        this.$(".preg271").hide();
        this.$(".preg274").hide();
    },
    validarPreguntas : function()
    {
        if (this.pasoActual > 1) {

            var valido = true;

            var elemento = this.$(".seccionPreguntas")[this.pasoActual - 2];
            _.each($(elemento).find(".preguntasFormulario"), function (pregunta) {

                
                //Si alguna preguntaestá sin chequear retorna false
                pregunta = $(pregunta);

                if (pregunta.is(":visible"))
                {
                    if (pregunta.find("input[type='checkbox']").length > 0 || pregunta.find("input[type='radio']").length > 0) {
                        if (pregunta.find("input:checked").length == 0)
                            valido = false;
                    }
                    else if (pregunta.find("input[type='text']").length > 0) {
                        _.each(pregunta.find("input[type='text']"), function (element, index) {
                            if ($(element).val().length == 0)
                                valido = false;
                        });
                    }
                    else if (pregunta.find("textarea").length > 0) {
                        if (pregunta.find("textarea").val().length == 0)
                            valido = false;
                    }
                }

                
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

    },
    cargarCamposEdades : function()
    {
        var numMiembros = this.$("#MiembrosFamilia").val();
        if (!isNaN(numMiembros) && parseInt(numMiembros) > 0)
        {
            var divEdades = this.$("#divEdades").show();
            divEdades.find('input').remove();
            for (var i = 0; i < numMiembros; i++) {
                divEdades.append(this.templateCampoEdad(i+1));
            }
        }
    },
    llenarEdades : function()
    {
        var txtEdades = $("#EdadesMiembrosFamilia").val("");
        _.each(this.$(".edades"), function (element, index) {
            element = $(element);
            if (element.val())
                txtEdades.val(txtEdades.val()+( txtEdades.val().length > 0 ? "," + element.val() : element.val()));
        });

    },
    cargarAnteriorMascota : function(obj)
    {
        obj = $(obj.target);
        if(obj.attr("value") == "Si")
            this.$(".preg274").show();
        else
            this.$(".preg274").hide();
    },
    cargarActualMascota: function (obj) {
        obj = $(obj.target);
        if (obj.attr("value") == "Si")
            this.$(".preg271").show();
        else
            this.$(".preg271").hide();
    },
    cerrarCondiciones: function ()
    {
        this.$("#divInfoAdopcion").dialog('close');
    }

});