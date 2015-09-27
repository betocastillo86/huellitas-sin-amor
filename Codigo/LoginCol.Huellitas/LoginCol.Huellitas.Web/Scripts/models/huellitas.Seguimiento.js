var SeguimientoModel =  Backbone.Model.extend(
{

	idAttribute : "SeguimientoAdopcionId",

	url: "/api/seguimiento",


	initialize : function()
	{
		
	},

	validation: {
		Imagen1: {
		    required: true,
            msg : "Selecciona una imagen preferiblemente en formato horizontal"
		},
		Imagen2: {
		    required: false
		},
		Observaciones: {
		    required: true,
            msg : "Ingresa las observaciones"
		}
	},
	guardar: function (args, ctx)
	{
	    var resultValidation = this.validate();

	    if (this.isValid()) {
	        this.once("sync", args.success, ctx);
	        this.save();
	    }
	    else {
	        args.invalid(resultValidation, ctx);
	    }
	}
});