var HuellitasRouter = Backbone.Router.extend({
    vistaActual : undefined,

    routes: {
        "huellitas": "listarHuellitas",
        "huellitas/": "listarHuellitas",
        "huellitas/buscar(/t:tipo)(/g:genero)(/c:color)(/ta:tamano)(/e:edad)(/rp:recomendado)": "buscarHuellitas"
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
            vistaListarAnimales = new ListarHuellitasView({sinFiltroInicial : true});
            this.vistaActual = vistaListarAnimales;
        }

        this.vistaActual.filtrarContenidosDesdeUrl(tipo, genero, color, tamano, edad, recomendado);
    }
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new HuellitasRouter();
    Backbone.history.start({ pushState: true });
});