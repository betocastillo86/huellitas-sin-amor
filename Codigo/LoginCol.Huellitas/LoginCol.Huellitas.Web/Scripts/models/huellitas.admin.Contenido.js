var ContenidoModel = Backbone.Model.extend({
    url: "/api/contenidos",
    idAttribute: "ContenidoId",
    
    initialize: function (args)
    {
        if (args.url != undefined)
            this.url = args.url;
    }

});

var ContenidoCollection = Backbone.Collection.extend({
    model: ContenidoModel,
    url: "/Admin/Contenidos",
    initialize: function (args)
    {
        if (args.url != undefined)
            this.url = args.url;

        console.log("Colección contenido creada");
    }
});