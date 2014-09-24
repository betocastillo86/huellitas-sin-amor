var ContenidosRelacionadosView = Backbone.View.extend({

    el: "#divContenidosRelacionados",

    template: _.template($("#templateContenidosRelacionados").html()),

    idContenido: undefined,

    lista: undefined,

    templateFilaContenido: undefined,

    agregarContenidoView: undefined,

    initialize: function (args) {
        this.idContenido = args.id;
        this.lista = new ContenidoRelacionadoCollection();
        this.lista.on("add", this.mostrarFilaContenido, this);
        this.lista.on("remove", this.contenidoRelacionadoEliminado, this);
        this.templateFilaContenido = _.template($("#templateTrContenidoRelacionado").html());
        this.agregarContenidoView = new AgregarContenidoRelacionadoView({ id: args.id });

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
        $("#divFilasContenidosRelacionados").empty();
        //debugger;
        this.lista.reset();
        
        this.lista.cargarContenidos(this.idContenido, tipoRelacionContenido);
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
        var idContenidoRelacionado = $(context.target).attr("id").split('_')[1];
        var idTipoRelacion = $("#TipoRelacionContenido").val();
        var contenidoRelacionado = this.lista.findWhere({ ContenidoId: parseInt(idContenidoRelacionado) });
        debugger;
        contenidoRelacionado.eliminar(this.idContenido, idContenidoRelacionado, idTipoRelacion);
    },
    contenidoRelacionadoEliminado: function (model)
    {
        alert("eliminado");
    }
});

var AgregarContenidoRelacionadoView = Backbone.View.extend({
    idContenido : undefined,

    el: "#divAgregarContenidoRelacionado",

    template : _.template($("#templateAgregarContenidoRelacionado").html()),

    events: {
        "click #BtnGuardarContenidoRelacionado" : "guardarContenidoRelacionado",
        "change #Relacionados_TiposContenido": "cargarContenidosPorTipo"
    },

    initialize: function (args) {
        if (args != undefined && args.id != undefined)
            this.idContenido = args.id;

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
            var idContenidoRelacionado = $("#Relacionados_Contenidos").val();
            var tipoRelacion = $("#Relacionados_TipoRelacionContenido").val();
            modelo.guardar(this.idContenido, idContenidoRelacionado, tipoRelacion);
        }
    },
});
