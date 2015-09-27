var SeguimientoView = Backbone.View.extend({
	el: "#divSeguimiento",

	vistaArchivo:	undefined,
	vistaArchivo2: undefined,
	vistaSummary: undefined,

	events: {
		'click #btnGuardar': 'guardar'
	},

	bindings: {
		"#Observaciones": "Observaciones",
		"#Key" : "Key"
	},

	initialize: function (args) {
		this.model = new SeguimientoModel({ AdopcionId: parseInt(args.id), Key: this.$("#Key").val() });
		this.model.on("error", this.errorAlGuardar, this);
		this.vistaSummary = new SummaryView();


		this.vistaArchivo = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
		this.vistaArchivo.on("archivo-guardado", this.imagenGuardada, this);

		this.vistaArchivo2 = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido2", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
		this.vistaArchivo2.on("archivo-guardado", this.imagenGuardada2, this);

		this.render();
	},

	render: function () {
		this.stickit();
		Backbone.Validation.bind(this);
		return this;
	},
	imagenGuardada: function (respuesta) {
		if (respuesta.get("ArchivoId")) {
			this.model.set({ Imagen1: respuesta.get("ArchivoId") });
		}
	},
	imagenGuardada2: function (respuesta) {
		if (respuesta.get("ArchivoId")) {
			this.model.set({ Imagen2: respuesta.get("ArchivoId") });
		}
	},
	errorAlGuardar: function () {
		alert("No fue posible guardar, intenta de nuevo");
		this.$("#btnGuardar").show();
	},
	guardar: function () {
		this.$("#btnGuardar").hide();
		this.model.guardar({ success: this.contenidoGuardado, invalid: this.datosInvalidos }, this);
		
	},
	contenidoGuardado: function (respuesta, ctx) {
		if (respuesta.toJSON().OperacionExitosa) {
			this.mostrarConfirmacion();
		}
		else {
			alert(respuesta.toJSON().MensajeError);
		}
	},
	mostrarConfirmacion: function () {
		this.$("#formRegistrar").hide();
		this.$("#divMensajeConfirmacion").show();
		if (this.tipoContenido == Constantes.TipoAnimalesPerdidos)
			this.$("#msjBusco").show();
		else
			this.$("#msjEncuentro").show();
	},
	datosInvalidos: function (errores, ctx) {
		ctx.vistaSummary.mostrar(errores);
		Huellitas.marcarErroresFormulario(errores, ctx);
		ctx.$("#btnGuardar").show();
	}

});