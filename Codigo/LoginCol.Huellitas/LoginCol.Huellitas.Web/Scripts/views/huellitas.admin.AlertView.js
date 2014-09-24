var AlertView = Backbone.View.extend({
    el: "#myModal",

    template : _.template($("#templateAlert").html()),

    initialize: function () {
        //this.$el.modal();
    },
    mostrar: function (texto, titulo) {
        if (titulo == undefined)
            titulo = "Alerta";
        
        this.$el.html(this.template({ Texto: texto, Titulo: titulo }));

        this.$el.modal('show');
    }

});

