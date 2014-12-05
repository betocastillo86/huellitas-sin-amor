var PerdidosView = Backbone.View.extend({
    el: "#divPerdidosGeneral",


    //buscar: Busco mi mascota -encontrar: Encontré una mascota -reportadas:Mascotas Reportadas
    opcionActual: undefined,

    model: undefined,

    //INICIO CONTROLES DE LA VISTA
    btnBusco: undefined,

    btnEncuentro: undefined,

    btnReportadas : undefined,

    formRegistrar: undefined,

    vistaZonas: undefined,

    vistaArchivo : undefined,
    //FIN CONTROLES DE LA VISTA

    events: {
        "click .nav_busca .addform": "cargarFormularioPerdido",
        "click #btnGuardar": "guardar"
    },

    bindings: {
        "#ddlZonaBarrio": "Zona",
        "#ContactoNombre" : "ContactoNombre",
        "#ContactoTelefono": "ContactoTelefono",
        "#ContactoCorreo": "ContactoCorreo",
        "#Color": "Color",
        "#Genero": "Genero",
        "#Edad": "Edad",
        "rbTipo": "Tipo",
        "#Imagen": "Imagen"
    },



    initialize: function ()
    {
        this.btnBusco = this.$("#btnBusco");
        this.btnEncuentro = this.$("#btnEncuentro");
        this.btnReportadas = this.$("#btnReportadas");
        this.formRegistrar = this.$("#formRegistrar");
        this.vistaZonas = new ZonasGeograficasView({ el: "#formRegistrar", activarBarrios: true });

        this.vistaArchivo = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
        this.vistaArchivo.on("archivo-guardado", this.imagenGuardada, this);
        
        //modelo
        this.model = new ContenidoPerdidoModel();
        

        this.render();
    },

    cargarFormularioPerdido: function (obj)
    {
        obj = $(obj.currentTarget);
        this.opcionActual = obj.attr("id");
        this.ocultarPestanas();
        this.formRegistrar.show();
    },
    ocultarPestanas: function ()
    {
        this.btnBusco.hide();
        this.btnEncuentro.hide();
        this.btnReportadas.hide();
        $("#" + this.opcionActual).show();
        $("#" + this.opcionActual).removeClass("sel");
    },
    imagenGuardada : function(respuesta)
    {
        if (respuesta.get("ArchivoId"))
            this.$("#Imagen").val(respuesta.get("ArchivoId"));
    },
    guardar : function()
    {
        //Huellitas.removerErroresFormulario();
        this.model.guardar({ success: this.contenidoGuardado, invalid: this.datosInvalidos }, this);
    },
    contenidoGuardado : function(respuesta)
    {
        debugger;
    },
    datosInvalidos : function(errores, ctx)
    {
        debugger;
        alert("Ingrese todos los datos  obligatorios del formulario");
    },
    render: function ()
    {
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    }


});