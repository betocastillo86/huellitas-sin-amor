var CrearHuellitaModel =  Backbone.Model.extend(
{

	idAttribute : "ContenidoId",

	validarDueno: true,

	url : "/api/huellitas",

	initialize : function()
	{
		
	},

	validation: {
	    Nombre: {
	        required: true,
            msg: "Ingresa el nombre. Si no lo conoce ingrese N/A"
	    },
		Tipo: {
		    required: true,
            msg : "Selecciona el tipo de animal"
		},
		Edad: {
			required: true,
			msg: "Ingresa la edad aproximada",
		    //pattern: /^1?[0-9]{1}$/
            //range: [1,20]
		},
		Genero: {
		    required: true,
		    msg: "Selecciona el genero de la mascota"
		},
		Color: {
		    required: true,
		    msg: "Selecciona el color"
		},
		ZonaGeograficaId: {
		    required: true,
            pattern: "number",
            msg: "Selecciona la zona"
		},
		ContactoNombre: {
		    required: true,
		    msg: "Ingresa tu nombre o el del contacto"
		},
		ContactoTelefono: {
		    required: true,
		    msg: "Ingresa un número telefónico"
		},
		ContactoCorreo: {
			required: false,
			pattern: "email",
			msg: "Ingresa tu correo electrónico"
		},
		Imagen: {
		    required: true,
            msg : "Selecciona al menos una imagen. Recuerda que deben ser fotos de buena calidad."
		},
		/*Imagen2: {
		    required: false
		},*/
		Descripcion: {
		    required: true,
            msg : "Ingresa una breve descripción"
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
	},
	eliminar: function (id) {
	    this.set({ContenidoId : id })
	    this.destroy({wait : true});
	}
});