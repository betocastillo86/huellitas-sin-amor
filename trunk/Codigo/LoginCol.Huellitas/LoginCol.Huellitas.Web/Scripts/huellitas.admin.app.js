var AppHuellitas = Backbone.Model.extend({

    elementoHtml: undefined,

    initialize : function(args)
    {
        this.elementoHtml = args.el;
    },

    deserializarFormulario: function (attributes) {

        var html = $(this.elementoHtml);
        _.chain(attributes).keys().each(function (key) {
            
            html.find(':input[name="' + key + '"]')
                .val(attributes[key]);
        });
    },

    serializarFormulario: function (modelo) {
        
        var container = $("#form1");
        var fields = {};

        if (!container.is('form')) {
            container = container.find('form');
        }

        container.each(function () {
            $.each($(this).serializeArray(), function () {

                if (this.value == "true" || this.value == "false")
                    this.value = this.value == "true";

                modelo.set(this.name, this.value);
            });
        });

        return modelo;
    },
    obtenerIdDesdeCampo: function (nombreCampo)
    {
        var partesCadena = nombreCampo.split("_");
        var id = -1;
        if (partesCadena.length > 0)
            id = parseInt(_.last(partesCadena));

        return id;
    },
    recargarValidadores: function () {
        $.validator.unobtrusive.parseDynamicContent('#form1');
    },
    mostrarAlerta: function (texto)
    {
        
    },
    consola: function (texto)
    {
        console.log(texto);
    },
    validarContenidoArchivoGeneral : function(idObj)
    {
        //var extensionesValidas = /^.*\.(jpg|JPG)$/
        var extensionesValidas = Constantes.ExtensionesImagenes;
        var obj = $("#" + idObj);
        if (!ValidarTamanoArchivo(obj, Constantes.TamanoMaximoCargaArchivos)) {
            return false;
        }

        if (!ValidarExtensionArchivo(obj, extensionesValidas)) {
            App_Router.alertaView.mostrar("Las extensiones no son validas");
            return false;
        }
    },
    cargarFuncionesFormularioPersiana: function ()
    {
        $('.btn-close').click(function (e) {
            e.preventDefault();
            $(this).parent().parent().parent().fadeOut();
        });
        $('.btn-minimize').click(function (e) {
            e.preventDefault();
            var $target = $(this).parent().parent().next('.box-content');
            if ($target.is(':visible')) $('i', $(this)).removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
            else $('i', $(this)).removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
            $target.slideToggle();
        });
        $('.btn-setting').click(function (e) {
            e.preventDefault();
            $('#myModal').modal('show');
        });
    }
});