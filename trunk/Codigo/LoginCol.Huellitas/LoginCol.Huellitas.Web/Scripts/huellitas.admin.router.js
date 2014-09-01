var AdminRouter



var AdminRouter = Backbone.Router.extend({


    //Vista actual utilizada en el sistema
    vistaActual: undefined,
    
    listarAnimalView: undefined,

    editarAnimalView: undefined,


    routes: {
        "admin/animales/listar":"listarAnimales",
        "admin/animales/editar/:id": "editarAnimal",
    },
    initialize : function(options)
    {
        
    },

    //Inicio Animales
    listarAnimales:function()
    {
        this.listarAnimalView = new ContenidoListarView({ urlModelo: "/api/AdminAnimales" });
        this.vistaActual = this.listarAnimalView;
    },
    editarAnimal: function (id) {
        debugger;
       this.vistaActual.desactivar();
       this.editarAnimalView = new ContenidoEditarView({ id: parseInt(id), url: "/api/adminanimales/" + id });
       this.vistaActual = this.editarAnimalView;
    }
    //Fin Animales
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new AdminRouter();
    Backbone.history.start({ pushState: true });
});