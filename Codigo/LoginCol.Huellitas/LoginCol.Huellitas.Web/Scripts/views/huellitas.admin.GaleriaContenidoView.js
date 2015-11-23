var GaleriaContenidoView = Backbone.View.extend({
    el: "#divImagenesContenido",

    url: "/api/adminimagenes",

    events: {
        "click #BtnMostrarAgregarImagenContenido": "mostrarFormularioImagenNueva",
        "click #BtnGuardarImagenContenido": "agregarImagen",
        "change #archivoImagenAdicional": "validarContenidoArchivo"
    },

    idContenidoPadre: undefined,

    lista: undefined,

    template: _.template($("#templateImagenesContenido").html()),

    templateFila: undefined,

    app: undefined,

    //alertaView: undefined,

    initialize: function (args) {
        if (args.id == undefined)
            alert("falta definir el id");

        $("#ulImagenes").empty();

        //this.alertaView = new AlertHtmlView();
        this.idContenidoPadre = args.id;

        this.templateFila = _.template($("#templateFilaImagenContenido").html());

        this.lista = new ImagenCollection({ idContenido: args.id });

        this.app = new AppHuellitas({ el: this.el });

        this.cargarArrastrar();

        this.render();
    },
    render: function () {
        this.lista.on("add", this.imagenAgregada, this);
        this.lista.on("sync", this.cargarPropiedadesGaleria, this);
        this.lista.fetch();
    },
    cargarArrastrar: function () {

        var that = this;
        $(".dropzone").dropzone(
            {
                url: "/admin/RelacionarImagen/" + this.idContenidoPadre,
                complete: function () {
                    if (this.getUploadingFiles().length === 0 && this.getQueuedFiles().length === 0) {
                        that.lista.fetch();
                    }
                }
            }
        );
    },
    recargarImagenes: function () {

        $("#Nombre-Imagen").val("");
        $("#Descripcion-Imagen").val("");
        $("#Archivo-Imagen").val("");

        $("#ulImagenes").empty();
        this.lista.fetch();
        //this.cargarPropiedadesGaleria();
    },
    imagenAgregada: function (model) {
        $("#ulImagenes").append(this.templateFila(model.toJSON()));
    },
    mostrar: function () {
        this.$el.modal('show');
        //this.alertaView.mostrar(this.$el.html(), "Imagenes Relacionadas");
        //this.cargarPropiedadesGaleria();
        this.delegateEvents();
    },
    agregarImagen: function () {
        var imagenNueva = new ImagenModel();
        this.listenTo(imagenNueva, "imagen-guardada-ok", this.recargarImagenes);
        imagenNueva.set({ Nombre: $("#Nombre-Imagen").val(), Descripcion: $("#Descripcion-Imagen").val() });
        imagenNueva.crear(this.idContenidoPadre, $("#archivoImagenAdicional"));
    },
    eliminarImagen: function (id) {
        var model = this.lista.findWhere({ ContenidoRelacionadoId: id });
        if (model != undefined)
            this.lista.eliminar(model);
    },
    validarContenidoArchivo: function () {
        return this.app.validarContenidoArchivoGeneral("archivoImagenAdicional");
    },
    cargarPropiedadesGaleria: function () {
        //gallery controls container animation
        $('ul.gallery li').hover(function () {
            $('img', this).fadeToggle(1000);
            $(this).find('.gallery-controls').remove();
            $(this).append('<div class="well gallery-controls">' +
                '<p><a href="#" class="gallery-edit btn"><i class="glyphicon glyphicon-edit"></i></a> <a href="#" class="gallery-delete btn"><i class="glyphicon glyphicon-remove"></i></a></p>' +
                '</div>');
            $(this).find('.gallery-controls').stop().animate({ 'margin-top': '-1' }, 400);
        }, function () {
            $('img', this).fadeToggle(1000);
            $(this).find('.gallery-controls').stop().animate({ 'margin-top': '-30' }, 200, function () {
                $(this).remove();
            });
        });

        var vista = this;
        //gallery image controls example
        //gallery delete
        $('.thumbnails').on('click', '.gallery-delete', function (e) {
            e.preventDefault();
            //get image id
            //alert($(this).parents('.thumbnail').attr('id'));
            var idImagen = $(this).parents('.thumbnail').attr('id').split("-")[1];
            vista.eliminarImagen(parseInt(idImagen));

            $(this).parents('.thumbnail').fadeOut();
        });
        //gallery edit
        $('.thumbnails').on('click', '.gallery-edit', function (e) {
            e.preventDefault();
            //get image id
            //alert($(this).parents('.thumbnail').attr('id'));
        });

        //gallery colorbox
        $('.thumbnail a').colorbox({
            rel: 'thumbnail a',
            transition: "elastic",
            maxWidth: "95%",
            maxHeight: "95%",
            slideshow: true
        });

        //gallery fullscreen
        $('#toggle-fullscreen').button().click(function () {
            var button = $(this), root = document.documentElement;
            if (!button.hasClass('active')) {
                $('#thumbnails').addClass('modal-fullscreen');
                if (root.webkitRequestFullScreen) {
                    root.webkitRequestFullScreen(
                        window.Element.ALLOW_KEYBOARD_INPUT
                    );
                } else if (root.mozRequestFullScreen) {
                    root.mozRequestFullScreen();
                }
            } else {
                $('#thumbnails').removeClass('modal-fullscreen');
                (document.webkitCancelFullScreen ||
                    document.mozCancelFullScreen ||
                    $.noop).apply(document);
            }
        });
    },
    mostrarFormularioImagenNueva: function () {
        $("#divImagenesFormulario").show();
        $("#BtnMostrarAgregarImagenContenido").hide();
    },
    ocultar: function () {
        this.$el.modal('hide');
        //this.alertaView.ocultar();
    },
    desactivar: function () {
        this.$el.hide();
        this.undelegateEvents();

    }
});