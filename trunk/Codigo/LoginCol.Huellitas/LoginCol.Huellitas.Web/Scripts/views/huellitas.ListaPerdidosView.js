var ListaPerdidosView = Backbone.View.extend({


    template: _.template(this.$("#templateResultadosBusqueda").html()),

    models: undefined,

    opcionesFiltro: undefined,

    templateDetalle: undefined,

    vistaDetalle: undefined,

    events: {
        'click .cajaCaso .btn': 'cargarDetalle',
        "click .siguientePagina": "siguientePagina"
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
        {
            opcionesFiltro.tipoFiltroBase = Constantes.TipoAnimalesPerdidosPadre;
            this.opcionesFiltro = opcionesFiltro;
        }
            

        this.opcionesFiltro.paginaActual++;

        this.models.cargarHuellitasPorFiltro(this.opcionesFiltro);


    },

    mostrarContenidos: function (models) {
        this.$("#divResultadosBusqueda").append(this.template(models.toJSON()));
    },


    siguientePagina: function (obj) {
        //Quita el botón que lanza el evento
        $(obj.currentTarget).remove();
        this.cargarContenidos();
    },

    cargarDetalle: function (obj) {
        var idContenido = parseInt($(obj.target).attr('cid'));
        this.vistaDetalle.cargar(idContenido);

    }

});