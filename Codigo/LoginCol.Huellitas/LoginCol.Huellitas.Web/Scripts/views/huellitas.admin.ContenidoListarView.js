
var ContenidoListarView = Backbone.View.extend({
	el: "#appAdminContent",

	lista: undefined,

	urlModelo: undefined,

	initialize: function (args) {

		if (args.urlModelo == undefined)
			alert("definir la url del modelo");
		else
			this.urlModelo = args.urlModelo;

		this.render();
		//this.cargarContenidos();
	},

	render: function(){
		this.cargarContenidos();
	},

	cargarContenidos: function () {
		
		var listaContenidos = new ContenidoCollection({ url : this.urlModelo});
		this.lista = listaContenidos.fetch();

		_.each(this.lista, function (element, index, list) {
			$("#tbodyListadoContenidos").append(_.template("#templateTrContenidos").html());
		})

	}
});