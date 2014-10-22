var ResultadosHuellitasView = Backbone.View.extend({
    el: "#divResultadosBusqueda",

    listaContenidos: undefined,

    template: _.template($("#templateResultadosBusqueda").html()),

    initialize: function (args)
    {
        
        this.listaContenidos = new ContenidoCollection();
        //this.cargarContenidos(args);
        
    },
    render: function ()
    {
        this.$el.html(this.template(this.listaContenidos.toJSON()));
        return this;
    },
    cargarContenidos: function (args)
    {
        this.listaContenidos.on("sync", this.render, this);
        this.listaContenidos.cargarHuellitasPorFiltro(args);
        //this.render();
    }
});