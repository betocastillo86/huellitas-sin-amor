var ImagenesContenidoView =  Backbone.View.extend({

    tagName: "div",

    events: {
        "click .imagenAdicional" : "mostrarImagen"
    },

    listaImagenes : undefined,

    contenidoId: 0,

    template : _.template($("#templateImagenesContenido").html()),

    initialize: function (args)
    {
        this.contenidoId = args.id;
        this.listaImagenes = new ImagenCollection({ idContenido : args.id});
        this.cargarImagenes();
    },
    cargarImagenes: function ()
    {
        this.listaImagenes.on("sync", this.mostrarImagenes, this);
        this.listaImagenes.obtenerImagenes(this.contenidoId);
    },
    mostrarImagenes: function ()
    {
        //carga un objeto para ser enviado al template
        var contenido = { ContenidoId: this.contenidoId, Imagenes: this.listaImagenes.toJSON() };
        this.$el.html(this.template(contenido));
    },
    mostrarImagen : function(obj)
    {
        var idImagen = $(obj.currentTarget).attr("contenidoId");
        this.$("#imagenPrincipal").attr("src", "/img/" + idImagen + "/medium");
         
    },
    render: function ()
    {
        return this;
    }

});