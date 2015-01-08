var ContenidoModel = Backbone.Model.extend({
    idAttribute: "ContenidoId",
    url: "/api/contenidos",

    obtenerValorCampo: function (campo)
    {
        var campoEncontrado = _.findWhere(this.get("Campos"), { CampoNombre: campo });
        return campoEncontrado != undefined ? campoEncontrado.Valor : "";
    },
    obtenerPorId: function (id) {
        this.fetch({ data: $.param({ id: id }) });
        return this;
    }
});

var ContenidoCollection = Backbone.Collection.extend({
    model: ContenidoModel,
    url: "/api/contenidos",

    cargarHuellitasPorFiltro: function (args)
    {
        var queryString = "";
        if (args != undefined)
            queryString = "/?" + $.param(args);

        if (!args.tipoFiltroBase)
            args.tipoFiltroBase = Constantes.TipoContenidoAnimales;

        if(args.esTipoPadre == undefined)
            args.esTipoPadre = true;

        this.url = "/api/contenidos/tip-" + args.tipoFiltroBase + "/" + args.esTipoPadre + "/" + queryString;
        this.fetch();
        return this;
    }

});