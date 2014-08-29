var ContenidoEditarView = Backbone.Router.extend({
    el: "#divVistaEditarContenidos",
    initialize: function (args)
    {
        var contenidos = new ContenidoCollection();
        contenidos.get(args.id);
    }
});