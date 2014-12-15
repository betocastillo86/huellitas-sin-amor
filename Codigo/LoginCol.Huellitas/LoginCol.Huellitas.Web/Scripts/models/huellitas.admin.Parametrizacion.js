var ParametrizacionModel = Backbone.Model.extend({

    idAttribute: 'Llave',

    url: "/api/parametrizacion",

    guardar: function (llave, valor)
    {
        this.set("Llave", llave);
        this.set("Valor", valor);
        this.save();
    }
});
