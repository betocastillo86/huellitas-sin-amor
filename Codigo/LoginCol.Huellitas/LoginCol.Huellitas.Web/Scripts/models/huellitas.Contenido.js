var ContenidoModel = Backbone.Model.extend({
    idAttribute: "ContenidoId",
    url : "/api/contenidos"
});

var ContenidoCollection = Backbone.Collection.extend({
    model: ContenidoModel,
    url: "/api/contenidos",

    cargarHuellitasPorFiltro: function (args)
    {
        var queryString = "";
        if (args != undefined)
            queryString = "/?"+$.param(args);

        this.url = "/api/contenidos/tip-" + Constantes.TipoContenidoAnimales + "/true/"+ queryString;
        this.fetch();
        return this;
    }

});