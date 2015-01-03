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

    tamanoArchivo : 0,

	//Todas las extensiones validas
	extensionesPermitidas: /./,

	mostrarAlerta: true,

	autoCarga : true,

	mensajeErrorTamano: "El tamano no es valido. ",

	mensajeErrorExtension: "La extensión no es valida",

	extension: undefined,

	mostrarCargando: true,

	htmlCargando: "<div class='barraCargador' style='background-color:red;width:{width};height:20px'></div>",

    timeoutCargador : undefined,

    //INICIO Controles Vista

    cargador : undefined,

    //FIN Controles Vista

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
			    this.cargarArchivo(elemento);
			}
			else {
                
			}
		}
		
	},
	cargarArchivo: function (elemento) {
	    this.model = new ArchivoModel();
	    this.model.on("archivo-guardado", this.archivoGuardado, this);
	    this.model.on("archivo-eliminado", this.archivoEliminado, this);
	    this.model.set({ Archivo: elemento[0].files[0] });
	    this.model.guardar();
	    this.mostrarCargador();
	},
    //INICIO Cargador
	mostrarCargador : function(){
	    ctx = this;
	    this.$("#inputArchivo").hide();
	    this.cargador.show();
	    this.cargador.html(this.htmlCargando.replace('{width}', '0%'));
	    this.timeoutCargador = setInterval(function () { ctx.actualizarCargador(ctx); }, 1000);
	},
	actualizarCargador: function (ctx) {
        //La tasa es de 50kb por segundo
	    var kbPorSegundo = 50;
        //Tasa que debe incrementar en porcentaje dependiendo del tamaño del archivo
	    var tasaIncremento = kbPorSegundo * 100 / (ctx.tamanoArchivo / 1000);
        //Tamaño actual del div cargado
	    var tamanoActual = (100 * parseInt(ctx.cargador.find('.barraCargador').css('width'))) / parseInt(ctx.cargador.width());
	    if (tamanoActual > 100)
	        tamanoActual = 0;

	    tamanoActual += tasaIncremento;
        //reemplaza el valor
	    //this.cargador.find('.barraCargador').html(ctx.htmlCargando.replace('{width}', tamanoActual + '%'));
	    ctx.cargador.find('.barraCargador').css('width', tamanoActual + '%');
	},
	ocultarCargador: function()
	{
	    this.cargador.hide();
	    this.cargador.css('width', '0%');
	    clearInterval(this.timeoutCargador);
	},
    //FIN Cargador
	render: function ()
	{
		this.$el.html(this.template({name : this.name}));
		this.cargador = this.$(".cargandoArchivo");
		return this;
	},
	validarTamano : function (obj) {

	    if (obj[0].files[0].size > this.tamanoMaximo) {
	        obj[0].files[0] = null;
	        return false;
	    }
	    else
	    {
	        this.tamanoArchivo = obj[0].files[0].size;
	        return true;
	    }
			
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
	        this.$(".cargandoArchivo").hide();
	        this.$("#divNombreArchivo").show();
	        this.$("#divNombreArchivo a").html(this.model.get("NombreArchivo"));
	        this.trigger("archivo-guardado", this.model);
	    }
	    else {
	        this.$("#inputArchivo").show();
	        alert("Error guardando el archivo");
	    }

	    this.ocultarCargador();
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
