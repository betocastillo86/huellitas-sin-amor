var CrearHuellitaView = BaseView.extend({
    el: "#divCrearHuellita",



    model: undefined,


    ordenarPor: 0,

    //INICIO CONTROLES DE LA VISTA

    btnGuardar: undefined,

    formRegistrar: undefined,

    formFiltro: undefined,

    vistaZonas: undefined,

    vistaArchivo: undefined,

    vistaArchivo2: undefined,

    vistaResultados: undefined,

    vistaSummary: undefined,

    vistaDetalleDefecto: undefined,

    tipoContenido: undefined,
    //FIN CONTROLES DE LA VISTA

    events: {
        //"click .nav_busca .addform": "cargarFormularioPerdido",
        "click #formRegistrar [name='rbTipo']": "cambioTipo",
        'click #btnEmpezar' : 'empezar',
        "click #btnGuardar": "guardar",
    },

    bindings: {
        "#Nombre": "Nombre",
        "#ddlZonaCiudad": "ZonaGeograficaId",
        "#ContactoNombre": "ContactoNombre",
        "#ContactoTelefono": "ContactoTelefono",
        "#ContactoCorreo": "ContactoCorreo",
        "#Color": "Color",
        "#Genero": "Genero",
        "#Edad": "Edad",
        "#Descripcion": "Descripcion",
        //"#TipoId": "TipoId",
        "#Imagen": "Imagen",
        "#Imagen2": "Imagen2"
    },



    initialize: function (args) {

        this.btnGuardar = this.$("#btnGuardar");
        

        this.vistaSummary = new SummaryView();


        /*this.vistaArchivo = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
        this.vistaArchivo.on("archivo-guardado", this.imagenGuardada, this);

        this.vistaArchivo2 = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido2", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
        this.vistaArchivo2.on("archivo-guardado", this.imagenGuardada2, this);*/

        this.model = new CrearHuellitaModel();
        this.cargarFormulario();
        this.render();
    },

    render: function () {
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    },
    cargarFormulario: function (obj) {
        this.vistaZonas = new ZonasGeograficasView({ el: "#formRegistrar", activarBarrios: false });
        this.model.set({ TipoContenidoId: this.tipoContenido });
        var that = this;
        this.$(".dropzone").dropzone(
            {
                url: "/api/archivos",
                complete: function (response) {

                    var objResponse = JSON.parse(response.xhr.response);

                    var imagenes = that.model.get('Imagen');
                    if (!imagenes)
                        imagenes = new Array();

                    imagenes.push(objResponse.InformacionAdicional);


                    that.model.set('Imagen', imagenes)
                    
                }
            }
        );

    },
    empezar: function () {
        this.$('#divRecomendaciones').hide();
        this.$('#camposFormulario').show();
    },
    cambioTipo: function () {
        var tipo = parseInt(this.$("#formRegistrar input[name='rbTipo']:checked").val());
        this.model.set({ Tipo: tipo });
    },

    cambioTipoFiltro: function () {

        var tipo = parseInt(this.$("#formFiltro input[name='rbTipo']:checked").val());
        this.model.set({ Tipo: tipo });
        
    },
    
    ocultarBotonesAlGuardar : function()
    {
        //this.btnGuardar.hide();
    },
    mostrarBotonesAlGuardar : function()
    {
        this.btnGuardar.show();
    },
    guardar: function () {

        this.ocultarBotonesAlGuardar();
        this.model.set({ ZonaGeograficaId: this.$("#ddlZonaCiudad").val() });
        var errores = this.validateControls();
        
        if (this.model.isValid()) {
            this.model.guardar({ success: this.contenidoGuardado, invalid: this.datosInvalidos }, this);
        }
        else
            this.datosInvalidos(errores);
    },
    filtrarPerdidos: function () {
        if (!this.vistaResultados)
        {
            this.vistaResultados = new ListaPerdidosView({ el: "#divVistaListado" });
            this.vistaResultados.on("ordenar", this.cambiarOrden, this);
            this.vistaResultados.$el.show();
        }
            

        this.vistaResultados.cargarContenidos(this.obtenerFiltroSeleccionado());
    },
    contenidoGuardado: function (respuesta, ctx) {
        if (respuesta.toJSON().OperacionExitosa) {
            this.mostrarConfirmacion();
        }
        else {
            alert(respuesta.toJSON().MensajeError);
        }

        ctx.mostrarBotonesAlGuardar();
    },
    mostrarConfirmacion: function () {
        this.$("#camposFormulario").hide();
        this.$("#divMensajeConfirmacion").show();
    },
    datosInvalidos: function (errores) {
        this.vistaSummary.mostrar(errores);
        //Huellitas.marcarErroresFormulario(errores, ctx);
        this.mostrarBotonesAlGuardar();
    },
    mostrarInicio: function () {
        $(".nav_busca li")
            .show()
            .addClass('sel');
        $(".nav_busca form").hide();
    },
    cambiarOrden: function (nuevoOrden) {
        this.ordenarPor = parseInt(nuevoOrden);
        this.filtrarPerdidos();
    },
});