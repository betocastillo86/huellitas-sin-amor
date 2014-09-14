
var templateListadoContenidos = _.template($("#templateTrContenidos").html());

var ContenidoListarView = Backbone.View.extend({
    el: "#divVistaListarContenidos",

    events: {
        "click #BtnCrearContenido": "crearContenido"
    },

    lista: undefined,

    urlModelo: undefined,

    tablaListado : undefined,

    initialize: function (args) {

        if (args.urlModelo == undefined)
            alert("definir la url del modelo");
        else
            this.urlModelo = args.urlModelo;

        this.render();
    },

    render: function(){
        this.cargarContenidos();
        this.$el.show();
    },
    //Carga los contenidos dell listado
    cargarContenidos: function () {
        this.lista = new ContenidoCollection({ url: this.urlModelo });
        //listaContenidos.on("add", this.contenidoAgregado)
	    
        this.lista.fetch({ success: this.contenidosAgregados });
        //this.lista = listaContenidos;
    },
    //Después de consultar los contenidos los carga en el template
    contenidosAgregados: function (model, response, options)
    {
        var tbodyListado = $("#tbodyListadoContenidos");
	    
        if ($.fn.dataTable.isDataTable("#tableListadoContenidos"))
        {
            this.tablaListado.fnDestroy();
            tbodyListado.html("");
        }
	    
        _.each(model, function (element, index, list) {
            tbodyListado.append(templateListadoContenidos(list.at(index).toJSON()));
        });

        this.tablaListado = $('#tableListadoContenidos').dataTable(optionsDataTable);
    },
	
    crearContenido : function(){
        App_Router.navigate("/admin/animales/crear", {trigger: true});
    },
    //Desactiva la vista despues
    desactivar: function () {
        this.$el.hide();
        this.undelegateEvents();
    }
});

