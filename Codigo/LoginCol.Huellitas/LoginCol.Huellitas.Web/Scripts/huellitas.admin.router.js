var AdminRouter



var AdminRouter = Backbone.Router.extend({


    //Vista actual utilizada en el sistema
    vistaActual: undefined,
    
    listarAnimalView: undefined,

    editarAnimalView: undefined,

    alertaView : undefined,

    routes: {
        "admin/animales/listar":"listarAnimales",
        "admin/animales/editar/:id": "editarAnimal",
        "admin/animales/crear": "crearAnimal",
    },
    initialize : function(options)
    {
        this.alertaView = new AlertView();
    },
    //Inicio Animales
    listarAnimales:function()
    {
        this.desactivarVistaActual();
        this.listarAnimalView = new ContenidoListarView({ urlModelo: "/api/adminanimales" });
        this.vistaActual = this.listarAnimalView;
    },
    editarAnimal: function (id) {
       this.desactivarVistaActual();
       this.editarAnimalView = new ContenidoEditarView({ id: parseInt(id), url: "/api/adminanimales/" + id });
       this.vistaActual = this.editarAnimalView;
    },
    crearAnimal:  function (){
        this.desactivarVistaActual();
        this.editarAnimalView = new ContenidoEditarView({ id: 0, url: "/api/adminanimales"});
        this.vistaActual = this.editarAnimalView;
    },
    //Fin Animales
    desactivarVistaActual: function ()
    {
        if (this.vistaActual != undefined)
            this.vistaActual.desactivar();
    }
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new AdminRouter();
    Backbone.history.start({ pushState: true });
});