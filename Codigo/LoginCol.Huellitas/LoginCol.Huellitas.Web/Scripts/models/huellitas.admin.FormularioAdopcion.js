var FormularioAdopcionModel = Backbone.Model.extend({
    url: "/api/adminadopciones",

    idAttribute : "FormularioAdopcionId",

    guardar: function ()
    {
        this.save();
    },
    enviarConfirmacion: function ()
    {
        this.url = "/api/adminadopciones?enviarCorreo=true";
        this.save({ data: $.param({ enviarCorreo: true }) });
    }
});

var FormularioAdopcionCollection = Backbone.Collection.extend({
    url: "/api/adminadopciones",
    model: FormularioAdopcionModel
});