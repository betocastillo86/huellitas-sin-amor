
var templateListadoContenidos = _.template($("#templateTrContenidos").html());

var ContenidoListarView = Backbone.View.extend({
    el: "#divVistaListarContenidos",

    events: {
        "click #BtnCrearContenido": "crearContenido"
    },

    lista: undefined,

    //permite controlar las redirecciones 
    modulo: undefined,

    tablaListado: undefined,

    idTipoContenidoPadre : undefined,

    initialize: function (args) {
        this.idTipoContenidoPadre = args.idTipoContenidoPadre;
        this.modulo = args.modulo;
        this.render();
    },

    render: function(){
        this.cargarContenidos();
        this.$el.show();
    },
    //Carga los contenidos dell listado
    cargarContenidos: function () {
        this.lista = new ContenidoCollection();
        //listaContenidos.on("add", this.contenidoAgregado)
        this.lista.on("sync", this.contenidosAgregados, this);
        this.lista.cargarPorPadre(this.idTipoContenidoPadre);
        //this.lista = listaContenidos;
    },
    //Después de consultar los contenidos los carga en el template
    contenidosAgregados: function (model, response, options)
    {
        
        var tbodyListado = $("#tbodyListadoContenidos");
	    
        if ($.fn.dataTable.isDataTable("#tableListadoContenidos"))
        {
            $('#tableListadoContenidos').dataTable().fnDestroy();
            tbodyListado.html("");
        }
	    
        _.each(model, function (element, index, list) {
            tbodyListado.append(templateListadoContenidos(list.at(index).toJSON()));
        });

        this.tablaListado = $('#tableListadoContenidos').dataTable(optionsDataTable);
    },
	
    crearContenido : function(){
        App_Router.navigate("/admin/"+this.modulo+"/crear", {trigger: true});
    },
    //Desactiva la vista despues
    desactivar: function () {
        this.$el.hide();
        this.undelegateEvents();
    }
});

