var AlertHtmlView = Backbone.View.extend({
    el: "#myModalHtml",

    template : _.template($("#templateAlertHtml").html()),

    initialize: function () {
        //this.$el.modal();
    },
    mostrar: function (texto, titulo) {
        if (titulo == undefined)
            titulo = "Alerta";
        
        this.$el.html(this.template({ Html : texto, Titulo: titulo }));

        this.$el.modal('show');
    },
    ocultar: function (texto, titulo)
    {
        this.$el.modal('hide');
    },
    desactivar: function () {
        this.undelegateEvents();
    }
});