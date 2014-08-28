
var templateListadoContenidos = _.template($("#templateTrContenidos").html());

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
    //Carga los contenidos dell listado
	cargarContenidos: function () {
	    var listaContenidos = new ContenidoCollection({ url: this.urlModelo });
        listaContenidos.on("add", this.contenidoAgregado)
        this.lista = listaContenidos.fetch({ success : this.contenidosAgregados});
	},
    //Después de consultar los contenidos los carga en el template
	contenidosAgregados: function (model, response, options)
    {
	    var tablaContenidos = $("#tbodyListadoContenidos");

	    _.each(model, function (element, index, list) {
	        tablaContenidos.append(templateListadoContenidos(list.at(index).toJSON()));
	    });

	    $('#tableListadoContenidos').dataTable(optionsDataTable);

    }
});

$(document).on("ready", function () {
    var view = new ContenidoListarView({ urlModelo : "/api/AdminAnimales" });
});