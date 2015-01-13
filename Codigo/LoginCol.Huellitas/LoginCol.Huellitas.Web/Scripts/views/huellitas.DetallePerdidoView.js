var DetallePerdidoView = Backbone.View.extend({
	template :  _.template($("#templateDetallePerdido").html()),

	idContenido: 0,

    model : undefined,

	modelContenido: undefined,

    vistaSummary : undefined,

	bindings: {
	    "#CorreoElectronico": "CorreoElectronico",
	    "#Nombres": "Nombres",
	    "#Telefono": "Telefono",
	    "#Comentario": "Comentario"
	},

	events: {
		'click #btnEncontrado': 'encontrado',
		'click #btnConocido': 'conocido',
        'click #btnEnviar' : 'enviarConocido'
	},

	initialize: function (args) {
	    
	    this.modelContenido = new ContenidoModel();
	    this.vistaSummary = new SummaryView();
		
	    this.modelContenido.on('destroy', this.eliminado, this);
	},

	cargar: function (idContenido)
	{
		this.idContenido = idContenido;
		this.modelContenido.once('sync', this.mostrarDetalle, this);
		this.modelContenido.obtenerPorId(this.idContenido);
	},
	mostrarDetalle: function (model) {
	    
	    this.model = new ContactoModel();
		this.$el.html(this.template(model.toJSON()));
		this.$el.dialog({ modal: true, title: '¿Lo has visto en algún lado?' });
		this.ocultarFormulario();

		this.stickit();
		Backbone.Validation.bind(this);
	},
	eliminado: function (respuesta) {

		//respuesta = respuesta.toJSON();
		//if (respuesta.OperacionExitosa) {
		//	alert('Muchas gracias por reportar esta huellita');
		//}
		//else {
		//	alert(respuesta.MensajeError);
		//}

		alert('Muchas gracias por reportar esta huellita');
		this.cerrar();
	},
	ocultarFormulario : function()
	{
	    this.$("#datosPersona").hide();
	},
	mostrarFormulario: function () {
	    this.$("#datosPersona").show();
	},
	encontrado : function()	{
		if (confirm('Después de registrar como encontrado esta huellita será borrado de nuestra base de datos. ¿Estás seguro que lo encontraste?'))
		{
		    this.modelContenido.eliminar();
		}
	},
	conocido: function(){
	    this.mostrarFormulario();
	},
	enviarConocido: function () {

	    var observaciones = this.model.get('Comentario');
	    if(observaciones && !this.model.validate())
	    {
	        observaciones = 'CONTENIDO ENCONTRADO ' + this.idContenido + ' -> ' + observaciones;
	        this.model.set('Comentario', observaciones);
	    }
	        
	    this.model.guardar({invalid : this.errorComentario, success : this.comentarioGuardado}, this);
	    
	},
	comentarioGuardado : function(model)
	{
	    if (model.toJSON().OperacionExitosa) {
	        this.ocultarFormulario();
	        alert("Muchas gracias por reportar esta huellita, nos contactaremos lo más pronto posible contigo.");
	    }
	    else {
	        alert("No fue posible guardar tu comentario. Si deseas, puedes enviarnos un correo electrónico a redes@huellitas.social");
	    }
	},
    errorComentario: function (errores, ctx) {
        ctx.vistaSummary.mostrar(errores);
    },
	cerrar: function () {
		this.$el.dialog('close');
	},
	render: function () {
	    
	}
})