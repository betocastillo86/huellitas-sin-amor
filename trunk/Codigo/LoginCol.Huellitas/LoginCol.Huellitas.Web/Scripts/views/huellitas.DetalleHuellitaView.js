var DetalleHuellitaView = Backbone.View.extend({
    el: "#divDetalleContenido",

    contenidoId : 0,

    vistaComentarios: undefined,

    vistaImagenes : undefined,

    vistaFacebookShare: undefined,
    
    vistaTwitterShare: undefined,

    vistaPerrosRelacionados: undefined,

    events: {
        "click #btnApadrinar" : "apadrinar"
    },

    //vistaVideo : undefined,

    initialize: function (args)
    {
        this.contenidoId = args.id;

        
        

        this.vistaComentarios = new ComentariosView({ id: args.id, el: "#divComentarios" });
        this.vistaComentarios.on("comentarioAgregado", this.sumarComentario, this);

        this.vistaFacebookShare = new FacebookShareView({ el: "#divFacebook", url: document.URL });
        this.vistaTwitterShare = new TwitterShareView({ el: "#divTwitter", url: document.URL, texto: 'Linda pagina de twitter' });
        this.vistaPerrosRelacionados = new ContenidoRelacionadoView({ el: "#divPerrosRelacionados", id: this.contenidoId, tipoRelacion: Constantes.TipoRelacionAnimalesSimilares, titulo: "ANIMALES SIMILARES" });
        
        this.vistaImagenes = new ImagenesContenidoView({ id: args.id, el: "#divImagenesContenido", urlVideo: this.$("#UrlVideo").val() });
        

        $("#divApadrinar").dialog({
            autoOpen: false,
            show: {
                effect: "blind",
                duration: 1000
            },
            hide: {
                effect: "explode",
                duration: 1000
            }
        });


        //this.vistaVideo = new VideoView({ el: "#divVideo", urlVideo: this.$("#UrlVideo").val() });
        this.render();
    },
    apadrinar: function () {
        debugger;
        this.$("#divApadrinar").dialog('open');
    },
    sumarComentario : function(ultimoComentario)
    {
        var objComentarios = this.$("#contarComentarios");
        var numComentarios = parseInt(objComentarios.text()) + 1;
        objComentarios.text(numComentarios);
    },
    render: function ()
    {
        return this;
    }

});