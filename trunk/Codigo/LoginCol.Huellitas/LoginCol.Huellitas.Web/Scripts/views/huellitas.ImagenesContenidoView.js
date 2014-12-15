var ImagenesContenidoView =  Backbone.View.extend({

    tagName: "div",

    events: {
        //"click .imagenAdicional" : "mostrarImagen"
        "click .imagenAdicional": "mostrarImagen",
        "click #btnVideo": "mostrarVideo"
    },

    listaImagenes : undefined,

    contenidoId: 0,

    urlVideo : undefined,

    template : _.template($("#templateImagenesContenido").html()),

    initialize: function (args)
    {
        
        this.contenidoId = args.id;
        
        if (args.urlVideo)
            this.urlVideo = args.urlVideo;

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
        var contenido = { ContenidoId: this.contenidoId, Imagenes: this.listaImagenes.toJSON(), UrlVideo : this.urlVideo };
        this.$el.html(this.template(contenido));
        
        Huellitas.cargarScroll();
        this.render();
        return this;
    },
    mostrarImagen : function(obj)
    {
        this.cerrarVideo();
        var idImagen = $(obj.target).attr("contenidoId");
        this.$("#imagenPrincipal").attr("src", "/img/" + idImagen + "/big");
    },
    mostrarVideo: function () {
        $("#divPlayerVideo").show();
        $("#imagenPrincipal").hide();
    },
    cerrarVideo: function () {
        $("#divPlayerVideo").hide();
        $("#imagenPrincipal").show();

    },
    render: function ()
    {
        if (!this.urlVideo) {
            this.$("#btnVideo").hide();
        }

        return this;
    }

});