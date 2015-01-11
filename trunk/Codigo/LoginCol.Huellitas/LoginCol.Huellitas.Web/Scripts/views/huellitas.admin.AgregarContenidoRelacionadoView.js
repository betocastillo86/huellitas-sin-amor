var AgregarContenidoRelacionadoView = Backbone.View.extend({
    idContenido: undefined,

    el: "#divAgregarContenidoRelacionado",

    template: _.template($("#templateAgregarContenidoRelacionado").html()),

    parent: undefined,

    callback: undefined,

    listaTipoRelaciones: undefined,

    tipoRelacionContenido: undefined,

    idTipoContenido: undefined,

    listaContenidosExistentes : undefined,

    templateFilaContenido: undefined,

    events: {
        "change #Relacionados_TipoRelacionContenido": "cargarContenidosPorTipo",
        "click #tableContenidosARelacionar .btn": "agregarContenidoRelacionado"
    },

    initialize: function (args) {
        if (args != undefined) {
            if (args.id != undefined)
                this.idContenido = args.id;

            if (args.idTipoContenido != undefined)
                this.idTipoContenido = args.idTipoContenido;

            if (args.parent != undefined)
                this.parent = args.parent;

            if (args.callback != undefined)
                this.callback = args.callback;
        }

        //Carga los contenidos existentes para controlar repetidos
        this.listaContenidosExistentes = new ContenidoRelacionadoCollection();
        this.listaContenidosExistentes.cargarContenidos(this.idContenido, 0);

        this.listaTipoRelaciones = new TipoRelacionContenidoCollection();
        this.listaTipoRelaciones.on("sync", this.mostrarTiposDeRelaciones, this);
        //Carga los tipos de relacion
        this.listaTipoRelaciones.obtenerPorTipoContenido(this.idTipoContenido);
        this.templateFilaContenido = _.template($("#templateTrContenidoAAgregar").html());

        this.render();
    },

    render: function () {
        this.$el.html(this.template({}));
    },
    mostrar: function () {
        this.$el.modal('show');
    },
    cerrar: function () {
        this.$el.modal('hide');
    },

    //Inicio FILTRAR POR TIPO DE CONTENIDO
    listaContenidosFiltrados: undefined,
    cargarContenidosPorTipo: function () {
        //Limpia la tabla de los contenidos
        

        this.tipoRelacionContenido = this.listaTipoRelaciones.findWhere({ TipoRelacionContenidoId: parseInt($("#Relacionados_TipoRelacionContenido").val()) });
        this.listaContenidosFiltrados = new ContenidoCollection({ url: "" });
        
        this.listaContenidosFiltrados.on("sync", this.agregarContenidosALista, this);
        //Despues de seleccionar el tipo de relacion, se cargan los contenidos que corresponden al tipo de contenido del tipo de relacion
        this.listaContenidosFiltrados.cargarPorTipo(this.tipoRelacionContenido.get("TipoContenidoId"));
    },
    tablaListado : undefined, 
    agregarContenidosALista: function (models) {

        
        if ($.fn.dataTable.isDataTable("#tableContenidosARelacionar")) {
            this.tablaListado.fnClearTable();
            this.tablaListado.fnDestroy();
        }

        var ctx = this;
        _.each(models.toJSON(), function (element, index) {
            if (element.ContenidoId != ctx.idContenido && !ctx.existeContenido(element.ContenidoId)) {
                $("#tableContenidosARelacionar tbody").append(ctx.templateFilaContenido(element));
            }
        });

        this.tablaListado = $("#tableContenidosARelacionar").dataTable(App_Huellitas.parametrizacionDataTableMin);
            
    },
    //Fin FILTRAR POR TIPO DE CONTENIDO
    mostrarTiposDeRelaciones: function () {
        var ddlTipoRelacion = $("#Relacionados_TipoRelacionContenido");
        ddlTipoRelacion.empty();
        ddlTipoRelacion.append("<option value=''>-</option>");
        _.each(this.listaTipoRelaciones, function (element, index, list) {
            element = list.at(index);
            ddlTipoRelacion.append("<option value='" + element.get("TipoRelacionContenidoId") + "'>" + element.get("Nombre") + "</option>");
        });
    },
    agregarContenidoRelacionado: function (obj) {
        
        
        if (confirm("¿Está seguro agregar este contenido relacionado?")) {

            var objTarget = $(obj.target);
            var idContenidoRelacionado = objTarget.attr("id").split('_')[1];

            //var idTipoRelacion = $("#TipoRelacionContenido").val();
            var modelo = new ContenidoRelacionadoModel();
            modelo.on("sync", this.contenidoGuardado, this);
            var tipoRelacion = $("#Relacionados_TipoRelacionContenido").val();
            modelo.guardar(this.idContenido, idContenidoRelacionado, tipoRelacion);
        }
    },
    obtenerContenidoDeExistentes : function(idContenido)
    {
        var contenido;

        _.each(this.listaContenidosExistentes, function (element, index, list) {
            element = list.at(index);
            if (element.get("ContenidoHijo").ContenidoId == idContenido) {
                contenido = element;
                return;
            }
        });

        return contenido;
    },
    existeContenido : function(idContenidoNuevo)
    {
        return this.obtenerContenidoDeExistentes(idContenidoNuevo) != undefined;
    },
    eliminarDeExistentes: function (idContenido) {
        var contenido = this.obtenerContenidoDeExistentes(idContenido);
        this.listaContenidosExistentes.remove(contenido);
        this.cargarContenidosPorTipo();
    },
    contenidoGuardado: function (respuesta) {
        this.listaContenidosExistentes.add({ ContenidoHijo: { ContenidoId: parseInt(respuesta.get('ContenidoHijoId')) } })
        this.cargarContenidosPorTipo();
        Backbone.trigger('contenido-relacionado-agregado');
        App_Router.alertaView.mostrar("Operación exitosa");
    }
});