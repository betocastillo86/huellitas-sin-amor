var AdopcionListarView = Backbone.View.extend({
    el: "#divAdopcionesListar",

    initialize: function (args) {
        this.render();
    },
    render: function ()
    {
        this.$('#tableListado').dataTable(optionsDataTable);
        return this;
    }
});