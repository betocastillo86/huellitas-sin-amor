var AutorespuestaView = Backbone.View.extend({
    el: "#formAdopcion",

    events: {
        "click .btnResponder": "enviarRespuesta"
    },

    model: undefined,


    enviarRespuesta: function () {

        var yaRespondido = $('#FormularioRespondido').length;
        if (!yaRespondido || (yaRespondido && confirm('¿Este formulario ya habia sido respondido, esta seguro de volver a enviarlo?')))
        {
            if (confirm("¿Está acción eviará un correo de confirmación, está seguro de hacerlo?")) {
                this.$('form').submit();
            }
        }
    }
});