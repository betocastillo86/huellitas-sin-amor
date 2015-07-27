var FormularioEditarView = Backbone.View.extend({
    el: "#formAdopcion",

    events: {
        "click .btnResponder": "enviarRespuesta"
    },


    bindings: {
        "#InformacionAdicionalCorreo": "InformacionAdicionalCorreo",
        "#Observaciones": "Observaciones",
        "#Estado": "Estado",
        "#FormularioAdopcionId": "FormularioAdopcionId"
    },

    model: undefined,

    initialize: function (args) {
        this.model = new FormularioAdopcionModel({ FormularioAdopcionId: args.id });
        this.model.on("sync", this.respuestaEnviada, this);
        this.render();
    },

    render: function ()
    {
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    },

    enviarRespuesta : function()
    {
       
        if (confirm("¿Está acción eviará un correo de confirmación, está seguro de hacerlo?")) {
            this.model.set({ Estado : this.$("#Estado").val() });
            this.model.enviarConfirmacion();
            return true;
        }
        else {
            return false;
        }
    },

    respuestaEnviada: function (respuesta)
    {
        respuesta = respuesta.toJSON();
        if (respuesta.OperacionExitosa) {
            App_Router.alertaView.mostrar("Correo enviado satisfactoriamente");
        }
        else {
            App_Router.alertaView.mostrar(respuesta.MensajeError);
        }
    }
    
});