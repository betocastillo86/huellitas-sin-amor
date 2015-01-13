var ListaPerdidosView =  Backbone.View.extend({


    template: _.template(this.$("#templateResultadosBusqueda").html()),

    models: undefined,

    opcionesFiltro: undefined,

    templateDetalle: undefined,

    vistaDetalle : undefined,

    events: {
        'click .cajaCaso .btn' : 'cargarDetalle'
    },

    initialize: function (args) {

        if (args.opcionesFiltro)
            this.opcionesFiltro = args.opcionesFiltro;

        this.templateDetalle = _.template($("#templateDetallePerdido").html());

        this.models = new ContenidoCollection();
        this.models.on("sync", this.mostrarContenidos, this);

        this.vistaDetalle = new DetallePerdidoView({ el: '#modalDetalleContenido' });
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
        this.vistaDetalle.cargar(parseInt($(obj.target).attr('cid')));
    }

});