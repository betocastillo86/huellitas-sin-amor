var ContenidoEditarView = Backbone.Router.extend({
    el: "#divVistaEditarContenidos",
    template: _.template($("#templateEditarContenidoBase").html()),
    initialize: function (args)
    {
        if (args.url != undefined)
            this.url = args.url;

        if (this.$el == undefined)
            this.$el = $(this.el);

        this.render(args);
    },
    render : function(args)
    {
        this.cargarContenido(args.id);
        return this;
    },
    cargarContenido: function (id)
    {
        var contenido;
        if (App_Router.listarAnimalView.lista == undefined) {
            contenido = new ContenidoModel();
            contenido.set("ContenidoId", id);
            contenido.fetch();
        }
        else {
            contenido = App_Router.listarAnimalView.lista.get(id);
        }

        var contenidoJson = contenido.toJSON();
        this.$el.html(this.template(contenidoJson));

        $(this.el + " input[name='Nombre']").val(contenidoJson.Nombre);
        $(this.el + " input[name='Nombre']").val(contenidoJson.Nombre);

        this.$el.show();
    }
});