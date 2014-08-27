var ContenidoModel = Backbone.Model.extend({
    url: "/Admin/Contenido"
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