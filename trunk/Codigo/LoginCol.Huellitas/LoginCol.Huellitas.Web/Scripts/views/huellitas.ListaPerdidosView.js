var ListaPerdidosView = Backbone.View.extend({


    template: _.template(this.$("#templateResultadosBusqueda").html()),

    models: undefined,

    opcionesFiltro: undefined,

    templateDetalle: undefined,

    vistaDetalle: undefined,



    ordenadoPor: undefined,

    events: {
        'click .cajaCaso .btn': 'cargarDetalle',
        "click .siguientePagina": "siguientePagina",
        "change #ddlOrden": "ordenar"
    },

    initialize: function (args) {

        if (args.opcionesFiltro)
            this.opcionesFiltro = args.opcionesFiltro;

        this.templateDetalle = _.template($("#templateDetallePerdido").html());

        this.models = new ContenidoCollection();
        this.models.on("sync", this.mostrarContenidos, this);

        var ctx = this;
        this.models.on("fetch", function () {
            ctx.$el.append(Huellitas.cargador);
        }, this);

        this.vistaDetalle = new DetallePerdidoView({ el: '#modalDetalleContenido' });
    },

    cargarContenidos: function (opcionesFiltro) {

        if (opcionesFiltro) {
            opcionesFiltro.tipoFiltroBase = Constantes.TipoAnimalesPerdidosPadre;
            this.opcionesFiltro = opcionesFiltro;
            this.$("#divResultadosBusqueda").empty();

            if (opcionesFiltro.orden > 0) {
                this.$("#ddlOrden").val(opcionesFiltro.orden);
                this.ordenadoPor = opcionesFiltro.orden;
            }
        }

        this.opcionesFiltro.paginaActual++;

        var listaContenidos = new ContenidoCollection();
        var ctx = this;

        this.models.cargarHuellitasPorFiltro(this.opcionesFiltro);

    },

    mostrarContenidos: function (models) {
        this.$("#divResultadosBusqueda").append(this.template(models.toJSON()));
        this.$("#divLoading").remove();
    },

    ordenar: function () {
        if (this.$("#ddlOrden").val() != "") {
            this.ordenadoPor = this.$("#ddlOrden").val();
            this.trigger("ordenar", this.ordenadoPor);
        }
        else
            return false;
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