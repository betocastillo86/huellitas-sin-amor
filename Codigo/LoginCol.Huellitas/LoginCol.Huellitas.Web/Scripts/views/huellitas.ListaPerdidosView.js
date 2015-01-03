var ListaPerdidosView =  Backbone.View.extend({


    template: _.template(this.$("#templateResultadosBusqueda").html()),

    models: undefined,

    opcionesFiltro: undefined,

    initialize: function (args) {

        if (args.opcionesFiltro)
            this.opcionesFiltro = args.opcionesFiltro;

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
    }

    
});