var DetalleFundacionView = Backbone.View.extend({
    el: "#divDetalleContenido",

    contenidoId: 0,

    vistaComentarios: undefined,

    vistaImagenes: undefined,

    vistaFacebookShare: undefined,

    vistaTwitterShare: undefined,

    vistaPerrosRelacionados: undefined,

    vistaVideo: undefined,

    mapaView : undefined,

    initialize: function (args) {
        this.contenidoId = args.id;
        this.vistaImagenes = new ImagenesContenidoView({ id: args.id, el: "#divImagenesContenido" });

        this.vistaComentarios = new ComentariosView({ id: args.id, el: "#divComentarios" });
        this.vistaComentarios.on("comentarioAgregado", this.sumarComentario, this);

        this.vistaFacebookShare = new FacebookShareView({ el: "#divFacebook", url: 'http://www.huellitassinamor.com/' });
        this.vistaTwitterShare = new TwitterShareView({ el: "#divTwitter", url: 'http://www.huellitassinamor.com/', texto: 'Linda pagina de twitter' });

        
        this.vistaPerrosRelacionados = new ContenidoRelacionadoView({
            el: "#divPerrosRelacionados", 
            id: this.contenidoId, 
            tipoRelacion: Constantes.TipoRelacionFundacion,
            titulo: "NUESTRAS HUELLITAS",
            mostrarOpcionVerTodos: true,
            linkVerTodos: args.nombre + "/" + Constantes.LlaveRouterVerTodos
        });
        
        //this.vistaVideo = new VideoView({ el: "#divVideo", urlVideo: this.$("#UrlVideo").val() });
        this.mapaView = new MapaView({ el: "#mapaContenido", latitud: parseFloat($("#Latitud").val()), longitud: parseFloat($("#Longitud").val()) });


        

        this.render();
    },
    sumarComentario: function (ultimoComentario) {
        
        var objComentarios = this.$("#contarComentarios");
        var numComentarios = parseInt(objComentarios.text()) + 1;
        objComentarios.text(numComentarios);
    },
    render: function () {
        return this;
    }

});