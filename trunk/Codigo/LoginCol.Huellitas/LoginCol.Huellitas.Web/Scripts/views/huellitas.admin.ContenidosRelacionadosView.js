var ContenidosRelacionadosView = Backbone.View.extend({

    el: "#divContenidosRelacionados",

    template: _.template($("#templateContenidosRelacionados").html()),

    idContenido: undefined,


    lista: undefined,

    templateFilaContenido: undefined,

    agregarContenidoView: undefined,

    app: undefined,



    initialize: function (args) {
        this.idContenido = args.id;
        
        this.lista = new ContenidoRelacionadoCollection();
        this.lista.on("add", this.mostrarFilaContenido, this);
        this.lista.on("remove", this.contenidoRelacionadoEliminado, this);
        this.templateFilaContenido = _.template($("#templateTrContenidoRelacionado").html());
        this.agregarContenidoView = new AgregarContenidoRelacionadoView({ id: args.id, idTipoContenido : args.idTipoContenido, parent: this, callback: "cargarContenidosRelacionadosPorTipo" });
        this.app = new AppHuellitas({ el: this.el });

        this.listenTo(Backbone, 'contenido-relacionado-agregado', this.cargarContenidosRelacionadosPorTipo, this);

        this.render();
        //this.delegate
    },

    render: function () {
        this.$el.html(this.template());
        this.$el.show();
    },
    events: {
        "change #TipoRelacionContenido": "cargarContenidosRelacionadosPorTipo",
        "click #BtnMostrarAgregarTipoContenido": "mostrarVentanaAgregarContenido",
        "click [id^='EliminarContenidoRelacionado_']" : "eliminarContenidoRelacionado"
    },

    cargarContenidosRelacionadosPorTipo: function () {
        var tipoRelacionContenido = $("#TipoRelacionContenido").val();
        

        if (tipoRelacionContenido != "")
        {
            $("#divFilasContenidosRelacionados").empty();
            //debugger;
            this.lista.reset();

            this.lista.cargarContenidos(this.idContenido, tipoRelacionContenido);
        }
        
    },
    mostrarFilaContenido: function (model) {
        $("#divFilasContenidosRelacionados").append(this.templateFilaContenido(model.toJSON()));
    },
    //Fin tipos de contenido
    mostrarVentanaAgregarContenido: function () {
        this.agregarContenidoView.mostrar();
    },
    eliminarContenidoRelacionado: function (context)
    {
        if (confirm("¿Está seguro de eliminar este contenido relacionado?"))
        {
            var objTarget = $(context.target);
            var idContenidoRelacionado = objTarget.attr("id").split('_')[1];
            //var idTipoRelacion = $("#TipoRelacionContenido").val();
            var contenidoRelacionado = this.lista.findWhere({ ContenidoRelacionadoId: parseInt(idContenidoRelacionado) });
            contenidoRelacionado.eliminar(idContenidoRelacionado);
        }        
    },
    desactivar : function()
    {
        this.$el.empty();
        this.undelegateEvents();
    },
    contenidoRelacionadoEliminado: function (model)
    {
        this.app.consola("Eliminado contenido relacionado " + model.get("ContenidoRelacionadoId"));
        $("#trContenidoRelacionado_" + model.get("ContenidoRelacionadoId")).remove();
    }
});

var AgregarContenidoRelacionadoView = Backbone.View.extend({
    idContenido : undefined,

    el: "#divAgregarContenidoRelacionado",

    template: _.template($("#templateAgregarContenidoRelacionado").html()),

    parent: undefined,

    callback: undefined,

    listaTipoRelaciones: undefined,

    tipoRelacionContenido : undefined,

    idTipoContenido: undefined,

    events: {
        "click #BtnGuardarContenidoRelacionado" : "guardarContenidoRelacionado",
        //"change #Relacionados_TiposContenido": "cargarContenidosPorTipo"
        "change #Relacionados_TipoRelacionContenido": "cargarContenidosPorTipo"
        
    },

    initialize: function (args) {
        if (args != undefined)
        {
            if(args.id != undefined)
                this.idContenido = args.id;

            if (args.idTipoContenido != undefined)
                this.idTipoContenido = args.idTipoContenido;

            if (args.parent != undefined)
                this.parent = args.parent;

            if (args.callback != undefined)
                this.callback = args.callback;
        }


        this.listaTipoRelaciones = new TipoRelacionContenidoCollection();
        this.listaTipoRelaciones.on("sync", this.mostrarTiposDeRelaciones, this);
        //Carga los tipos de relacion
        this.listaTipoRelaciones.obtenerPorTipoContenido(this.idTipoContenido);
            
        this.render();
    },

    render: function ()
    {
        this.$el.html(this.template({}));
        this.cargarTiposContenido();
    },
    mostrar : function()
    {
        this.$el.modal('show');
    },
    cerrar: function () {
        this.$el.modal('hide');
    },

    //Inicio TIPOS DE CONTENIDO
    listaTiposContenidos: undefined,
    cargarTiposContenido: function () {
        this.listaTiposContenidos = new TipoContenidoCollection();
        //$("#Relacionados_TiposContenido").empty();
        $("#Relacionados_TiposContenido").append("<option value='-1'>-</option>");

        this.listaTiposContenidos.on("add", this.agregarTipoContenidoALista, this);
        this.listaTiposContenidos.cargarTodos();
        //this.delegateEvents({ "change #Relacionados_TiposContenido": "cargarContenidosPorTipo" });
    },
    agregarTipoContenidoALista: function (model) {
        $("#Relacionados_TiposContenido").append("<option value='" + model.get("TipoContenidoId") + "'>" + model.get("Nombre") + "</option>");
    },
    //fin TIPOS DE CONTENIDO
    //Inicio FILTRAR POR TIPO DE CONTENIDO
    listaContenidosFiltrados: undefined,
    cargarContenidosPorTipo: function () {
        //var tipoContenidoSeleccionado = $("#Relacionados_TiposContenido").val();
        this.tipoRelacionContenido = this.listaTipoRelaciones.findWhere({ TipoRelacionContenidoId: parseInt($("#Relacionados_TipoRelacionContenido").val()) });
        this.listaContenidosFiltrados = new ContenidoCollection({ url: "" });
        $("#Relacionados_Contenidos").empty();
        this.listaContenidosFiltrados.on("add", this.agregarContenidoALista, this);
        //Despues de seleccionar el tipo de relacion, se cargan los contenidos que corresponden al tipo de contenido del tipo de relacion
        this.listaContenidosFiltrados.cargarPorTipo(this.tipoRelacionContenido.get("TipoContenidoId"));
    },
    agregarContenidoALista: function (model) {
        $("#Relacionados_Contenidos").append("<option value='" + model.get("ContenidoId") + "'>" + model.get("Nombre") + "</option>");
    },
    //Fin FILTRAR POR TIPO DE CONTENIDO
    guardarContenidoRelacionado: function () {
        if ($("#Relacionados_Contenidos").val() != "")
        {
            var modelo = new ContenidoRelacionadoModel();
            modelo.on("sync", this.contenidoGuardado, this);
            var idContenidoRelacionado = $("#Relacionados_Contenidos").val();
            var tipoRelacion = $("#Relacionados_TipoRelacionContenido").val();
            modelo.guardar(this.idContenido, idContenidoRelacionado, tipoRelacion);
        }
    },
    mostrarTiposDeRelaciones: function () {
        var ddlTipoRelacion = $("#Relacionados_TipoRelacionContenido");
        ddlTipoRelacion.empty();
        ddlTipoRelacion.append("<option value=''>-</option>");
        _.each(this.listaTipoRelaciones, function (element, index, list) {
            element = list.at(index);
            ddlTipoRelacion.append("<option value='"+element.get("TipoRelacionContenidoId")+"'>"+element.get("Nombre")+"</option>");
        });
    },
    contenidoGuardado : function(respuesta)
    {
        if (respuesta.get("OperacionExitosa")) {
            Backbone.trigger('contenido-relacionado-agregado');
            this.cerrar();
        }
        else {
            App_Router.alertaView.mostrar(respuesta.get("MensajeError"));
        }

        
    }
});
