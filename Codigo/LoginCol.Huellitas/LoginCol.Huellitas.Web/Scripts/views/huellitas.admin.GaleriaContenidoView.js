var GaleriaContenidoView = Backbone.View.extend({
    el: "#divImagenesContenido",

    url: "/api/adminimagenes",

    lista: undefined,

    template: _.template($("#templateImagenesContenido").html()),

    templateFila: _.template($("#templateFilaImagenContenido").html()),

    alertaView: undefined,

    initialize: function (args)
    {
        if (args.id == undefined)
            alert("falta definir el id");

        this.alertaView = new AlertHtmlView();

        this.lista = new ImagenCollection({ idContenido: args.id });
        this.lista.on("add", this.imagenAgregada, this);

        this.render();
    },
    render: function () {
        this.lista.fetch();
    },
    imagenAgregada: function (model)
    {
        $("#ulImagenes").append(this.templateFila(model));
    },
    mostrar: function () {
        this.alertaView.mostrar(this.$el.html(), "Imagenes Relacionadas");
    },
    ocultar: function ()
    {
        this.alertaView.ocultar();
    },
    desactivar: function () {
        this.$el.hide();
        this.undelegateEvents();
    }
});