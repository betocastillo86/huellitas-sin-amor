var AdminRouter = Backbone.Router.extend({


    //Vista actual utilizada en el sistema
    vistaActual: undefined,
    
    listarAnimalView: undefined,

    editarAnimalView: undefined,

    alertaView: undefined,

    idTipoContenidoPadre : 0,


    routes: {
        "admin/animales/listar":"listarAnimales",
        "admin/animales/editar/:id": "editarAnimal",
        "admin/animales/crear": "crearAnimal",
        "admin/fundaciones/listar": "listarFundaciones",
        "admin/fundaciones/editar/:id": "editarFundacion",
        "admin/fundaciones/crear": "crearFundacion"
    },
    initialize : function(options)
    {
        this.alertaView = new AlertView();

        
    },
    //Inicio Animales
    listarAnimales:function()
    {
        this.idTipoContenidoPadre = 2;
        this.desactivarVistaActual();
        this.listarAnimalView = new ContenidoListarView({ idTipoContenidoPadre : this.idTipoContenidoPadre, modulo : "animales" });
        this.vistaActual = this.listarAnimalView;
        //this.app.cargarFuncionesFormularioPersiana();
    },
    editarAnimal: function (id) {
       this.idTipoContenidoPadre = 2;
       this.desactivarVistaActual();
       this.editarAnimalView = new ContenidoEditarView({ id: parseInt(id), idTipoContenidoPadre: this.idTipoContenidoPadre, modulo: "animales" });
       this.vistaActual = this.editarAnimalView;
       //this.app.cargarFuncionesFormularioPersiana();
    },
    crearAnimal: function () {
        this.idTipoContenidoPadre = 2;
        this.desactivarVistaActual();
        this.editarAnimalView = new ContenidoEditarView({ id: 0, idTipoContenidoPadre: this.idTipoContenidoPadre, modulo: "animales" });
        this.vistaActual = this.editarAnimalView;
        //this.app.cargarFuncionesFormularioPersiana();
    },
    //Fin Animales
    //Inicio Fundaciones
    listarFundaciones: function () {
        this.idTipoContenidoPadre = 3;
        this.desactivarVistaActual();
        this.listarAnimalView = new ContenidoListarView({ idTipoContenidoPadre: this.idTipoContenidoPadre, modulo: "fundaciones" });
        this.vistaActual = this.listarAnimalView;
        //this.app.cargarFuncionesFormularioPersiana();
    },
    editarFundacion: function (id) {
        this.idTipoContenidoPadre = 3;
        this.desactivarVistaActual();
        this.editarAnimalView = new ContenidoEditarView({ id: parseInt(id), idTipoContenidoPadre: this.idTipoContenidoPadre, modulo: "fundaciones" });
        this.vistaActual = this.editarAnimalView;
        //this.app.cargarFuncionesFormularioPersiana();
    },
    crearFundacion: function () {
        this.idTipoContenidoPadre = 3;
        this.desactivarVistaActual();
        this.editarAnimalView = new ContenidoEditarView({ id: 0, idTipoContenidoPadre: this.idTipoContenidoPadre, modulo: "fundaciones" });
        this.vistaActual = this.editarAnimalView;
        //this.app.cargarFuncionesFormularioPersiana();
    },
    //Fin Fundaciones
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