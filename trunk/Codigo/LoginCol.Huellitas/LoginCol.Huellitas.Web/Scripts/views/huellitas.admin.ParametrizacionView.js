var ParametrizacionView = Backbone.View.extend({
	el: "#divParametrizacion",

	model : undefined,

	events : {
	    "click .table .btn-info": "actualizarParametrizacion",
        "click .crear" : "crearParametrizacion"
	},
	initialize: function ()
	{
		this.$('#tableListado').dataTable(optionsDataTable);
	},
	actualizarParametrizacion: function (obj)
	{
	    var llave = $(obj.target).attr("llave");
	    var valor = undefined;
		if (llave)
		{
			valor = this.$("#value_" + llave).val();
		}

		this.guardar(llave, valor);
	},
	crearParametrizacion : function()
	{
	    var llave = this.$("#txtNombreLlave").val();
	    var valor = this.$("#txtValorLlave").val();
	    this.guardar(llave, valor);
	},
	guardar : function(llave, valor)
	{
	    if (valor && llave) {
	        this.model = new ParametrizacionModel();
	        this.model.once("sync", this.parametrizacionGuardada, this);
	        this.model.guardar(llave, valor);
	    }
	    else {
	        App_Router.alertaView.mostrar("Ingrese el valor de la llave");
	    }
	},
	parametrizacionGuardada: function (modelo)
	{
		App_Router.alertaView.mostrar("Parametrizacion Guardada");
	}
});