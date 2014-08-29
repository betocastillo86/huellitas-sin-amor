var editarAnimalView;
var vistaActual;

var AdminRouter = Backbone.Router.extend({
    routes: {
        "/animales/editar/:id" : "editarAnimal"
    },
    initialize : function(options)
    {
        debugger;
    },
    editarAnimal: function (id) {
        debugger;
        vistaActual.desactivar();
        editarAnimalView = new ContenidoEditarView({ id: id });
    }
});

$(document).on("ready", function () {
    var routerAdmin = new AdminRouter();
    Backbone.history.start({ pushState: true });
});