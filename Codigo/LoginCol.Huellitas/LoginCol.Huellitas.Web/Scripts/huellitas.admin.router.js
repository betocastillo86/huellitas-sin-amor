﻿var AdminRouter = Backbone.Router.extend({


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
        "admin/fundaciones/crear": "crearFundacion",
        "admin/parametrizacion": "listarParametrizacion",
        "admin/usuariosexternos": "listarUsuariosExternos",
        "admin/formulariosdetalle/:id": "editarFormulario",
        "admin/formularioslistar": "listarFormularios",
        "Admin/AdopcionesDetalle/:id": "editarAdopcion",
        "Admin/AdopcionesDetalle(/:query)": "crearAdopcion",
        "admin/adopcioneslistar" : "listarAdopciones"
       
    },
    initialize : function(options)
    {
        this.alertaView = new AlertView();
        this.initializeValidators();
    },
    initializeValidators: function ()
    {
        //jQuery.validator.methods["date"] = function (value, element) { debugger; }
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
    listarParametrizacion : function()
    {
        this.vistaActual = new ParametrizacionView();
    },
   
    //Fin Fundaciones
    //InicioFormularios
    editarFormulario: function (id) {
        this.vistaActual = new FormularioEditarView({ id: id });
    },
    listarFormularios : function()
    {
        this.vistaActual = new FormularioListarView();
    },
    //FinFundaciones

    //InicioAdopciones
    crearAdopcion: function (idFormulario) {
        this.vistaActual = new AdopcionEditarView({ fId: idFormulario });
    },
    editarAdopcion: function (id) {
        this.vistaActual = new AdopcionEditarView({ id : id});
    },
    listarAdopciones: function () {
        this.vistaActual = new AdopcionListarView();
    },
    //FinAdopciones
    //Inicio UsuariosExternos
    listarUsuariosExternos: function () {
        //debugger;
        this.vistaActual = new UsuarioExternoView();
    },
    //Fin UusariosExternos
    desactivarVistaActual: function ()
    {
        if (this.vistaActual != undefined)
            this.vistaActual.desactivar();
    }
});


var App_Router;
var App_Huellitas;

$(document).on("ready", function () {
    App_Router = new AdminRouter();
    App_Huellitas = new AppHuellitas();
    Backbone.history.start({ pushState: true });
});