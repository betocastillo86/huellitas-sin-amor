var ContenidoModel = Backbone.Model.extend({
    baseurl : "/api/admincontenidos/",
    url: "/api/admincontenidos",
    idAttribute: "ContenidoId",
    
    initialize: function (args)
    {
    },

    cargar: function (idContenido)
    {
        this.url = this.baseurl + idContenido;
        this.fetch();
    }

});

var ContenidoCollection = Backbone.Collection.extend({
    model: ContenidoModel,
    url: "/api/admincontenidos",
    initialize: function (args)
    {
        console.log("Colección contenido creada");
    },
    cargarPorPadre : function(idTipoContenido)
    {
        console.log("Conulsta de contenidos por tipo padre");
        this.url = "/api/admincontenidos/tip-" + idTipoContenido + "/true";
        return this.cargar();
    },
    cargarPorTipo: function (idTipoContenido, params)
    {
        console.log("Conulsta de contenidos por tipo");
        this.url = "/api/admincontenidos/tip-" + idTipoContenido + "/false";
        this.cargar(params);
    },
    cargar: function (params)
    {
        if (params)
            this.fetch({ data: params });
        else
            this.fetch();
        return this;
    }
});