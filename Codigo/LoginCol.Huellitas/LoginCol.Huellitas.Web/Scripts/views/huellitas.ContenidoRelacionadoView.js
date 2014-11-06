var ContenidoRelacionadoView = Backbone.View.extend({

    contenidoPadreId: 0,

    tipoRelacion: 0,

    template: _.template($("#templateContenidosRelacionados").html()),

    listaContenidos: undefined,

    titulo : undefined,

    initialize: function (args)
    {
        this.contenidoPadreId = args.id;
        this.tipoRelacion = args.tipoRelacion;
        this.titulo = args.titulo;

        this.listaContenidos = new ContenidoRelacionadoCollection();
        this.listaContenidos.on("sync", this.mostrarContenidos, this);
        this.listaContenidos.cargarContenidos(this.contenidoPadreId, this.tipoRelacion);
    },

    mostrarContenidos : function()
    {
        this.render();
    },
    render: function ()
    {
        this.$el.html(this.template({ Titulo: this.titulo, Contenidos: this.listaContenidos.toJSON() }));
        $('#cbp-fwslider').cbpFWSlider();
        return this;
    }
});