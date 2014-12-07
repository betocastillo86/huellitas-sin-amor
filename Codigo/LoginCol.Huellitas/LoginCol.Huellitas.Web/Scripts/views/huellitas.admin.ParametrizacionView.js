var ParametrizacionView = Backbone.View.extend({
	el: "#divParametrizacion",

	model : undefined,

	events : {
		"click .table .btn-info" : "actualizarParametrizacion"
	},
	initialize: function ()
	{
		$('#tableListado').dataTable(optionsDataTable);
	},
	actualizarParametrizacion: function (obj)
	{
		var llave = $(obj.target).attr("llave");
		if (llave)
		{
			var valor = $("#value_" + llave).val();
			if (valor) {
				this.model = new ParametrizacionModel();
				this.model.once("sync", this.parametrizacionGuardada, this);
				this.model.guardar(llave, valor);
			}
			else {
				App_Router.alertaView.mostrar("Ingrese el valor de la llave");
			}
		}
	},
	parametrizacionGuardada: function (modelo)
	{
		App_Router.alertaView.mostrar("Parametrizacion Guardada");
	}
});