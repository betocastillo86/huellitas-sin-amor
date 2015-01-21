var TablaBasicaModel = Backbone.Model.extend({
    url : '/api/tablasbasicas'
});

var TablaBasicaCollection = Backbone.Collection.extend({
    model: TablaBasicaModel,

    url : '/api/tablasbasicas',

    razasPerros: function ()
    {
        return this.porTabla(Constantes.RazasPerros);
    },

    razasGatos: function () {
       return this.porTabla(Constantes.RazasGatos);
    },

    porTabla: function (id)
    {
        this.fetch({ data: $.param({ id: id }) });
        return this;
    }
});