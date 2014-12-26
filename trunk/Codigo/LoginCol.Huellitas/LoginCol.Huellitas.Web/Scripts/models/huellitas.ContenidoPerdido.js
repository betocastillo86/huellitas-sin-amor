var ContenidoPerdidoModel =  Backbone.Model.extend(
{

	idAttribute : "ContenidoId",

	validarDueno: true,

	url : "/api/perdidos",

	initialize : function()
	{
		
	},

	validation: {
	    Nombre: {
	        required: true,
            msg: "*"
	    },
		Tipo: {
			required: true
		},
		Edad: {
			required: true,
			msg: "Ingrese la edad aproximada",
		    //pattern: /^1?[0-9]{1}$/
            range: [1,20]
		},
		Genero: {
		    required: true,
		    msg: "Ingrese el genero de la mascota"
		},
		Color: {
		    required: true,
		    msg: "Ingrese el color"
		},
		ZonaGeograficaId: {
		    required: true,
            pattern: "number",
		    msg: "Ingrese la zona"
		},
		ContactoNombre: {
		    required: true,
		    msg: "Ingrese su nombre"
		},
		ContactoTelefono: {
		    required: true,
		    msg: "Ingrese número telefónico"
		},
		ContactoCorreo: {
			required: false,
			pattern: "email",
			msg: "Ingrese su correo electrónico"
		},
		Imagen: {
		    required: true,
            msg : "Una imagen para conocer más"
		},
		Descripcion: {
		    required: true,
            msg : "Ingrese una breve descripción"
		}
	},
	guardar: function (args, ctx)
	{
	    if (this.isValid()) {
	        this.once("sync", args.success, ctx);
	        this.save();
	    }
	    else {
	        args.invalid(this.validate(), ctx);
	    }
	}
});