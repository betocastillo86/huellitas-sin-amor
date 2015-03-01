var AdopcionListarView = Backbone.View.extend({

	el : "#divAdopcionesListar",

	initialize: function ()
	{
		this.$('#tableListado').dataTable(optionsDataTable);
	}
});