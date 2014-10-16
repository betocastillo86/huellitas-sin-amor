var HuellitasRouter = Backbone.Router.extend({
    vistaActual : undefined,

    routes: {
         "huellitas" : "listarHuellitas"
    },

    listarHuellitas: function ()
    {
        var vistaListarAnimales = new ListarHuellitasView();
       // $("#divMainContentBackbone").html(vistaListarAnimales.$el.html());
        this.vistaActual = vistaListarAnimales;
    }
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new HuellitasRouter();
    Backbone.history.start({ pushState: true });
});