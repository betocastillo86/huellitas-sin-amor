var SubirArchivoView = Backbone.View.extend({

	tagName: "input",

	events: {
	    "change input[type='file']": "validarArchivo",
	    "click #divNombreArchivo a" : "eliminarArchivo"
	},

	template : _.template($("#templateCargaArchivo").html()),

	tamanoMaximo: 100,

	name: undefined,

    model : undefined,

	//Todas las extensiones validas
	extensionesPermitidas: /./,

	mostrarAlerta: true,

	autoCarga : true,

	mensajeErrorTamano: "El tamano no es valido. ",

	mensajeErrorExtension: "La extensión no es valida",

    extension : undefined, 

	attributes: 
	{
		'type' : 'file'
	},
	initialize: function (args)
	{
		//Carga el nombre del control
		this.name = args.name;

		if (args.id)
			this.$el.attr('id', args.id);
		if (args.tamanoMaximo)
			this.tamanoMaximo = args.tamanoMaximo;
		if (args.extensionesPermitidas)
			this.extensionesPermitidas = args.extensionesPermitidas;
		if (args.mensajeErrorTamano)
			this.mensajeErrorTamano = args.mensajeErrorTamano;
		if (args.mensajeErrorExtension)
			this.mensajeErrorExtension = args.mensajeErrorExtension;
		if (args.mostrarAlerta != undefined)
			this.mostrarAlerta = args.mostrarAlerta;


		this.render();
	},
	validarArchivo : function(obj)
	{
		var elemento = $(obj.target);
		var tamanoValido = this.validarTamano(elemento);
		var extensionValida = this.validarExtension(elemento);

		if (!tamanoValido)
		{
			this.trigger("error-tamano");
			elemento.val("");
		}

		if (!extensionValida)
		{
			this.trigger("error-extension");
			elemento.val("");
		}
			
		if (!tamanoValido || !extensionValida) {
			if (this.mostrarAlerta) {
				var error = "";
				if (!tamanoValido)
					error = this.mensajeErrorTamano;

				if (!extensionValida)
					error += this.mensajeErrorExtension;

				if (error.length > 0)
					alert(error);
			}
		}
		else {
			if (this.autoCarga) {
			    this.model = new ArchivoModel();
			    this.model.on("archivo-guardado", this.archivoGuardado, this);
			    this.model.on("archivo-eliminado", this.archivoEliminado, this);
			    this.model.set({ Archivo: elemento[0].files[0] });
			    this.model.guardar();
			}
			else {
                
			}
		}
		
	},
	render: function ()
	{
		this.$el.html(this.template({name : this.name}));

		return this;
	},
	validarTamano : function (obj) {

		if (obj[0].files[0].size > this.tamanoMaximo) {
			obj[0].files[0] = null;
    		return false;
		}
		else
			return true;
	},
	validarExtension : function(obj)
	{
		if (!this.extensionesPermitidas.test(obj.val())) {
			return false;
		}
		else {
		    var regexNombre = Constantes.ExtensionesImagenes.exec(obj.val());
		    this.extension = regexNombre[regexNombre.length - 1];
			return true;
		}
	},
	archivoGuardado: function (respuesta)
	{
	    if (respuesta.OperacionExitosa) {
	        this.$("#inputArchivo").hide();
	        this.$("#divNombreArchivo").show();
	        this.$("#divNombreArchivo a").html(this.model.get("NombreArchivo"));
	        this.trigger("archivo-guardado", this.model);
	    }
	    else {
	        alert("Error guardando el archivo");
	    }
	},
	eliminarArchivo: function ()
	{
	    if (confirm("¿Está seguro de eliminar este archivo?"))
	    {
	        this.model.eliminar();
	    }
	},
	archivoEliminado: function (respuesta)
	{
        
	}


});
