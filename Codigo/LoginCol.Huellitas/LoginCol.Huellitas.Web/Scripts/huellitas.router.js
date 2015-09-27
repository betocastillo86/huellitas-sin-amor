var HuellitasRouter = Backbone.Router.extend({
    vistaActual : undefined,

    routes: {
        "": "home",
        "/": "home",
        "sinhogar": "listarHuellitas",
        "sinhogar/": "listarHuellitas",
        "sinhogar/buscar(/t:tipo)(/g:genero)(/c:color)(/ta:tamano)(/e:edad)(/rp:recomendado)(/f:fundacion)(/zh:zona)(/zp:zonaPadre)(/n_:nombre)(/o:orden)": "buscarHuellitas",
        "sinhogar/:id/:nombre": "detalleHuellita",
        "sinhogar/:id/:nombre/quiero-adoptar": "adoptarHuellita",
        "fundaciones" : "listarFundaciones",
        "fundaciones/": "listarFundaciones",
        "fundaciones/buscar(/z:zona)": "buscarFundaciones",
        "fundaciones/:id/:nombre": "detalleFundacion",
        "fundaciones/:id/:nombre/ver-todos" : "huellasDeFundacion",
        "perros-gatos-perdidos(/:id)": "inicioPerdidos",
        "por-que-adoptar": "porqueAdoptar",
        "seguimiento/:id(/*urlPath)" : "seguimiento"
    },

    home : function()
    {
        var vistaHome = new HomeView();
        this.vistaActual = vistaHome;
    },

    listarHuellitas: function ()
    {
        var vistaListarAnimales = new ListarHuellitasView();
        // $("#divMainContentBackbone").html(vistaListarAnimales.$el.html());
        this.vistaActual = vistaListarAnimales;
    },

    buscarHuellitas: function (tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre, nombre, orden)
    {
        var vistaListarAnimales = undefined;
        if (this.vistaActual == undefined)
        {
            //inicializa la vista pero pasa parametro para no cargar los contenidos
            vistaListarAnimales = new ListarHuellitasView({ cargar: false, zona : zona, zonaPadre : zonaPadre });
            this.vistaActual = vistaListarAnimales;
        }

        this.vistaActual.filtrarContenidosDesdeUrl(tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre, nombre, orden);
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
    adoptarHuellita : function(id, nombre)
    {
        var vistaAdoptar = new AdoptarView({ id: id });
        this.vistaActual = vistaAdoptar;
    },
    detalleFundacion: function (id, nombre)
    {
        var vistaDetalleFundacion = new DetalleFundacionView({ id: id, nombre : nombre });
        this.vistaActual = vistaDetalleFundacion;
    },
    huellasDeFundacion : function(id)
    {
        var vistaHuellasFundacion = new HuellasFundacionView({ id : id });
        this.vistaActual = vistaHuellasFundacion;
    },
    inicioPerdidos: function (id)
    {
        var vistaPerdidos = new PerdidosView({ id : id});
        this.vistaActual = vistaPerdidos;
    },
    seguimiento: function (id) {
        var vistaSeguimiento = new SeguimientoView({ id: id });
        this.vistaActual = vistaSeguimiento;
    },
    porqueAdoptar : function()
    {
        var vistaAdoptar = new InfoAdoptarView({ el: "#divInfoAdoptar" });
        this.vistaActual = vistaAdoptar;
    },
    navegar: function (url, opt)
    {
        this.navigate(url.replace(/ /g, "-"), opt);
    }
});


