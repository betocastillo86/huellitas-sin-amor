var ContenidoPerdidoModel =  Backbone.Model.extend(
{

	idAttribute : "ContenidoId",

	validarDueno: true,

	url : "/api/perdidos",

	initialize : function()
	{
		
	},

	validation: {
		Tipo: {
			required: true
		},
		Edad: {
			required: true,
			msg: "Ingrese la edad aproximada",
			pattern: /^1?[0-9]{1}$/
		},
		Genero: {
			required : true
		},
		Color: {
			required : true
		},
		Zona: {
		    required: true
		},
		ContactoNombre: {
			required: true
		},
		ContactoTelefono: {
			required : true
		},
		ContactoCorreo: {
			required: false,
			pattern : "email"
		},
		Imagen: {
		    required:true
		}
	},
	guardar: function (args, ctx)
	{
	    if (this.isValid()) {
	        this.once("sync", args.success, this, ctx);
	        this.save();
	    }
	    else {
	        args.invalid(this.validate(), ctx);
	    }
	}
});