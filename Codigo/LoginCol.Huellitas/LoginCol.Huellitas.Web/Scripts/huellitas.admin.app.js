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
    }
});