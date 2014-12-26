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

    vistaArchivo: undefined,

    tipoContenido : undefined,
    //FIN CONTROLES DE LA VISTA

    events: {
        //"click .nav_busca .addform": "cargarFormularioPerdido",
        "click #btnBusco": "cargarFormularioPerdido",
        "click #btnEncuentro" :"cargarFormularioEncontrado",
        "click [name='rbTipo']" : "cambioTipo",
        "click #btnGuardar": "guardar"
    },

    bindings: {
        "#Nombre" : "Nombre",
        "#ddlZonaBarrio": "ZonaGeograficaId",
        "#ContactoNombre" : "ContactoNombre",
        "#ContactoTelefono": "ContactoTelefono",
        "#ContactoCorreo": "ContactoCorreo",
        "#Color": "Color",
        "#Genero": "Genero",
        "#Edad": "Edad",
        "#Descripcion": "Descripcion",
        //"#TipoId": "TipoId",
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

        this.model = new ContenidoPerdidoModel();
        
        this.render();
    },

    cargarFormularioPerdido : function(obj)
    {

        this.tipoContenido = Constantes.TipoAnimalesPerdidos;
        this.cargarFormulario(obj);
    },
    cargarFormularioEncontrado: function (obj) {
        this.tipoContenido = Constantes.TipoAnimalesEncontrados;
        this.cargarFormulario(obj);
    },
    cargarFormulario: function (obj)
    {
        obj = $(obj.currentTarget);
        this.model.set({ TipoContenidoId: this.tipoContenido });
        this.cambioTipo();
        this.opcionActual = obj.attr("id");
        this.ocultarPestanas();
        this.formRegistrar.show();
    },

    cambioTipo: function () {
        this.model.set({ Tipo: parseInt(this.$("input[name='rbTipo']:checked").val()) });
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
        {
            this.model.set({ Imagen: respuesta.get("ArchivoId") });
            //this.$("#Imagen").val(respuesta.get("ArchivoId"));
        }
            
    },
    guardar : function()
    {
        this.model.set({ ZonaGeograficaId: this.$("#ddlZonaBarrio").val() });
        this.model.guardar({ success: this.contenidoGuardado, invalid: this.datosInvalidos }, this);
    },
    contenidoGuardado: function (respuesta, ctx)
    {
        if (respuesta.toJSON().OperacionExitosa) {
            this.mostrarConfirmacion();
        }
        else {
            alert(respuesta.toJSON().MensajeError);
        }
    },
    mostrarConfirmacion : function()
    {
        $("#camposFormulario").hide();
        $("#divMensajeConfirmacion").show();
        if (this.tipoContenido == Constantes.TipoAnimalesPerdidos)
            $("#msjBusco").show();
        else
            $("#msjEncuentro").show();
    },
    datosInvalidos : function(errores, ctx)
    {
        Huellitas.marcarErroresFormulario(errores, ctx);
    },
    render: function ()
    {
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    }


});