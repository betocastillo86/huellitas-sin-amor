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

    serializarFormulario: function () {
        
        var container = $("#form1");
        var fields = {};

        if (!container.is('form')) {
            container = container.find('form');
        }

        container.each(function () {
            $.each($(this).serializeArray(), function () {
                fields[this.name] = this.value;
            });
        });

        return fields;
    }
});