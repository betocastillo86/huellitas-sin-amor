var HuellitasRouter = Backbone.Router.extend({
    vistaActual : undefined,

    routes: {
        "huellitas": "listarHuellitas",
        "huellitas/": "listarHuellitas",
        "huellitas/:id/:nombre": "detalleHuellita",
        "huellitas/buscar(/t:tipo)(/g:genero)(/c:color)(/ta:tamano)(/e:edad)(/rp:recomendado)": "buscarHuellitas",
        "fundaciones" : "listarFundaciones",
        "fundaciones/": "listarFundaciones",
        "fundaciones/buscar(/z:zona)": "buscarFundaciones"
    },

    listarHuellitas: function ()
    {
        var vistaListarAnimales = new ListarHuellitasView();
        // $("#divMainContentBackbone").html(vistaListarAnimales.$el.html());
        this.vistaActual = vistaListarAnimales;
    },

    buscarHuellitas: function (tipo, genero, color, tamano, edad, recomendado)
    {
        var vistaListarAnimales = undefined;
        if (this.vistaActual == undefined)
        {
            //inicializa la vista pero pasa parametro para no cargar los contenidos
            vistaListarAnimales = new ListarHuellitasView({ cargar: false });
            this.vistaActual = vistaListarAnimales;
        }

        this.vistaActual.filtrarContenidosDesdeUrl(tipo, genero, color, tamano, edad, recomendado);
    },
    listarFundaciones: function ()
    {
        var vistaListarFundaciones = new ListarFundacionesView();
        this.vistaActual = vistaListarFundaciones;
        
    },
    buscarFundaciones: function (zona)
    {
        var vistaListarFundaciones = new ListarFundacionesView({ cargar: false });
        this.vistaActual = vistaListarFundaciones;
        vistaListarFundaciones.filtrarContenidosDesdeUrl(zona);
    },
    detalleHuellita: function (id, nombre)
    {
        var vistaDetalleContenido = new DetalleHuellitaView({ id: id });
        this.vistaActual = vistaDetalleContenido;
    }
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new HuellitasRouter();
    Backbone.history.start({ pushState: true });
});