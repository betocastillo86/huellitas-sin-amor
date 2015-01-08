var ListaPerdidosView =  Backbone.View.extend({


    template: _.template(this.$("#templateResultadosBusqueda").html()),

    models: undefined,

    opcionesFiltro: undefined,

    templateDetalle : undefined,

    events: {
        'click .cajaCaso .btn' : 'cargarDetalle'
    },

    initialize: function (args) {

        if (args.opcionesFiltro)
            this.opcionesFiltro = args.opcionesFiltro;

        this.templateDetalle = _.template($("#templateDetallePerdido").html());

        this.models = new ContenidoCollection();
        this.models.on("sync", this.mostrarContenidos, this);
    },

    cargarContenidos: function (opcionesFiltro) {


        if (opcionesFiltro)
            this.opcionesFiltro = opcionesFiltro;

        opcionesFiltro.tipoFiltroBase = Constantes.TipoAnimalesPerdidosPadre;

        this.models.cargarHuellitasPorFiltro(opcionesFiltro);

    },

    mostrarContenidos: function (models) {
        this.$("#divResultadosBusqueda").html(this.template(models.toJSON()));
    },

    cargarDetalle: function (obj)
    {
        var idContenido = parseInt($(obj.target).attr('cid'));
        var contenidoModel = new ContenidoModel();
        contenidoModel.on('sync', this.mostrarDetalle, this);
        contenidoModel.obtenerPorId(idContenido);
    },

    mostrarDetalle: function (model) {
        this.$("#modalDetalleContenido").html(this.templateDetalle(model.toJSON()));
        this.$("#modalDetalleContenido").dialog();
    }

    
});