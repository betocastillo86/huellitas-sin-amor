var ContenidoModel = Backbone.Model.extend({
    idAttribute: "ContenidoId",
    url : "/api/contenidos"
});

var ContenidoCollection = Backbone.Collection.extend({
    model: ContenidoModel,
    url: "/api/contenidos",

    cargarHuellitasPorFiltro: function (args)
    {
        this.url = "/api/contenidos/perros";
        this.fetch();
        return this;
    }

});