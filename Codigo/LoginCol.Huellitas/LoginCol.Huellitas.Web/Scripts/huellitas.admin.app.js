var AppHuellitas = Backbone.Model.extend({

    elementoHtml: undefined,

    parametrizacionDataTableMin : {
        'paging': true,
        'pageLength': 5,
        'language':
            {
                'search': 'Buscar por nombre: '
            },
        'sPaginationType': 'bootstrap',
        "aaSorting": []
    },

    initialize : function(args)
    {
        if(args)
            this.elementoHtml = args.el;
    },
    marcarErroresFormulario: function (errores, ctx) {
        this.removerErroresFormulario(ctx);
        _.each(errores, function (error, campo) {
            ctx.$("#" + campo).addClass("invalid");
            ctx.$("#" + campo + "Error").html(error);
        });
    },
    removerErroresFormulario: function (ctx) {

        _.each(ctx.$(".invalid"), function (obj) {
            $(obj).removeClass("invalid");
        });

        _.each(ctx.$("span[id*='Error']"), function (obj) {
            //ctx.$("#" + campo + "Error").html("");
            $(obj).html("");
        });

    },
    limpiarFormulario: function (ctx, campos) {
        _.each(campos, function (campo) {
            ctx.$("#" + campo).val("");
        });
    },
    deserializarFormulario: function (attributes) {

        var html = $(this.elementoHtml);
        _.chain(attributes).keys().each(function (key) {
            
            var obj = html.find(':input[name="' + key + '"]')
                .val(attributes[key]);

            if (obj.attr("type") == "checkbox")
            {
                obj.prop("checked", attributes[key]);
            }
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

