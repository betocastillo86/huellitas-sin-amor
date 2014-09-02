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
        this.$el.show();
        return this;
    },
    cargarContenido: function (id)
    {
        var contenido;
        if (App_Router.listarAnimalView == undefined ||  App_Router.listarAnimalView.lista == undefined) {            
            contenido = new ContenidoModel({ url: this.url });
            contenido.set("ContenidoId", id);
            contenido.once("change", this.mostrarContenido, this);
            contenido.fetch();
        }
        else {
            contenido = App_Router.listarAnimalView.lista.get(id);
            this.mostrarContenido(contenido);
        }
    },
    mostrarContenido: function (contenido, context)
    {
        var contenidoJson = contenido.toJSON();
        contenidoJson.TituloFormulario = "Editar Contenido";
        this.$el.html(this.template(contenidoJson));
        $("#Nombre").val(contenido.get('Nombre'));
        $("#Descripcion").val(contenido.get('Descripcion'));
        $("#TipoContenidoId").val(contenido.get('TipoContenidoId'));
        $("#ZonaGeograficaId").val(contenido.get('ZonaGeograficaId'));
        $("#Email").val(contenido.get('Email'));
        $("#Facebook").val(contenido.get('Facebook'));
        $("#Twitter").val(contenido.get('Twitter'));
        $("#Activo").val(contenido.get('Activo'));
        this.$el.show();
    }
});