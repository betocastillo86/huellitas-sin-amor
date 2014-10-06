var ContenidosRelacionadosView = Backbone.View.extend({

    el: "#divContenidosRelacionados",

    template: _.template($("#templateContenidosRelacionados").html()),

    idContenido: undefined,

    lista: undefined,

    templateFilaContenido: undefined,

    agregarContenidoView: undefined,

    app : undefined,

    initialize: function (args) {
        this.idContenido = args.id;
        this.lista = new ContenidoRelacionadoCollection();
        this.lista.on("add", this.mostrarFilaContenido, this);
        this.lista.on("remove", this.contenidoRelacionadoEliminado, this);
        this.templateFilaContenido = _.template($("#templateTrContenidoRelacionado").html());
        this.agregarContenidoView = new AgregarContenidoRelacionadoView({ id: args.id, parent: this, callback: "cargarContenidosRelacionadosPorTipo" });
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

    callback : undefined,

    events: {
        "click #BtnGuardarContenidoRelacionado" : "guardarContenidoRelacionado",
        "change #Relacionados_TiposContenido": "cargarContenidosPorTipo"
    },

    initialize: function (args) {
        if (args != undefined)
        {
            if(args.id != undefined)
                this.idContenido = args.id;

            if (args.parent != undefined)
                this.parent = args.parent;

            if (args.callback != undefined)
                this.callback = args.callback;
        }
            
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
        var tipoContenidoSeleccionado = $("#Relacionados_TiposContenido").val();
        this.listaContenidosFiltrados = new ContenidoCollection({ url: "" });
        $("#Relacionados_Contenidos").empty();
        this.listaContenidosFiltrados.on("add", this.agregarContenidoALista, this);
        this.listaContenidosFiltrados.cargarPorTipo(tipoContenidoSeleccionado);
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
    contenidoGuardado : function()
    {
        Backbone.trigger('contenido-relacionado-agregado');
        this.cerrar();
    }
});
