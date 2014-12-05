var HuellitasRouter = Backbone.Router.extend({
    vistaActual : undefined,

    routes: {
        "": "home",
        "/": "home",
        "huellitas": "listarHuellitas",
        "huellitas/": "listarHuellitas",
        "huellitas/buscar(/t:tipo)(/g:genero)(/c:color)(/ta:tamano)(/e:edad)(/rp:recomendado)(/f:fundacion)(/zh:zona)(/zp:zonaPadre)": "buscarHuellitas",
        "huellitas/:id/:nombre": "detalleHuellita",
        "fundaciones" : "listarFundaciones",
        "fundaciones/": "listarFundaciones",
        "fundaciones/buscar(/z:zona)": "buscarFundaciones",
        "fundaciones/:id/:nombre": "detalleFundacion",
        "home/perdidos" : "inicioPerdidos"
    },

    home : function()
    {
        $('#cbp-fwslider').cbpFWSlider();
    },

    listarHuellitas: function ()
    {
        var vistaListarAnimales = new ListarHuellitasView();
        // $("#divMainContentBackbone").html(vistaListarAnimales.$el.html());
        this.vistaActual = vistaListarAnimales;
    },

    buscarHuellitas: function (tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre)
    {
        var vistaListarAnimales = undefined;
        if (this.vistaActual == undefined)
        {
            //inicializa la vista pero pasa parametro para no cargar los contenidos
            vistaListarAnimales = new ListarHuellitasView({ cargar: false, zona : zona, zonaPadre : zonaPadre });
            this.vistaActual = vistaListarAnimales;
        }

        this.vistaActual.filtrarContenidosDesdeUrl(tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre);
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
    },
    detalleFundacion: function (id, nombre)
    {
        var vistaDetalleFundacion = new DetalleFundacionView({ id: id });
        this.vistaActual = vistaDetalleFundacion;
    },
    inicioPerdidos: function ()
    {
        var vistaPerdidos = new PerdidosView();
        this.vistaActual = vistaPerdidos;
    },
    navegar: function (url, opt)
    {
        this.navigate(url.replace(" ", "-"), opt);
    }
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new HuellitasRouter();
    Backbone.history.start({ pushState: true });
});