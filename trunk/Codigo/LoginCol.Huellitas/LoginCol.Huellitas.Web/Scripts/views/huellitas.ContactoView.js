var ContactoView = Backbone.View.extend({
    events : {
        "click .btn" : "guardarComentario"
    },
    bindings: {
        "#CorreoElectronico": "CorreoElectronico",
        "#Nombres": "Nombres",
        "#Telefono": "Telefono",
        "#Comentario" : "Comentario"
    },
    initialize: function (args) {
        this.model = new ContactoModel();
        this.render();
    },
    guardarComentario : function(){
        this.model.guardar({ success: this.comentarioGuardado, invalid: this.errorComentario }, this);
    },
    comentarioGuardado : function(model){
        if (model.toJSON().OperacionExitosa) {
            alert("Muchas gracias por contactarnos, pronto tendrás una respuesta");
            Huellitas.limpiarFormulario(this, this.bindings);
        }
        else {
            alert("No fue posible guardar tu comentario, intenta de nuevo");
        }
    },
    errorComentario: function (errores, ctx) {
        Huellitas.marcarErroresFormulario(errores, ctx);
    },
    render: function () {
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    }

});