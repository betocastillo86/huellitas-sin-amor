var PerdidosView = Backbone.View.extend({
    el: "#divPerdidosGeneral",


    //buscar: Busco mi mascota -encontrar: Encontré una mascota -reportadas:Mascotas Reportadas
    opcionActual: undefined,

    model: undefined,

    listaRazasPerros: undefined,

    listaRazasGatos: undefined,

    ordenarPor: 0,

    //INICIO CONTROLES DE LA VISTA
    btnBusco: undefined,

    btnEncuentro: undefined,

    btnReportadas: undefined,

    ddlRaza : undefined,

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
        "click #btnBusco": "cargarFormularioPerdido",
        "click #btnEncuentro": "cargarFormularioEncontrado",
        "click #btnReportadas": "cargarFormularioFiltro",
        "click #formRegistrar [name='rbTipo']": "cambioTipo",
        "click #formFiltro [name='rbTipo']": "cambioTipoFiltro",
        "click #btnGuardar": "guardar",
        "click #btnFiltrar": "filtrarPerdidos",
        "click .volver" : 'mostrarInicio'
    },

    bindings: {
        "#Nombre": "Nombre",
        "#ddlZonaBarrio": "ZonaGeograficaId",
        "#ContactoNombre": "ContactoNombre",
        "#ContactoTelefono": "ContactoTelefono",
        "#ContactoCorreo": "ContactoCorreo",
        "#Color": "Color",
        "#Genero": "Genero",
        "#Edad": "Edad",
        "#Descripcion": "Descripcion",
        //"#TipoId": "TipoId",
        "#Imagen": "Imagen",
        "#Imagen2": "Imagen2",
        "#formRegistrar #ddlRaza": "Raza"
    },



    initialize: function (args) {
        this.btnBusco = this.$("#btnBusco");
        this.btnEncuentro = this.$("#btnEncuentro");
        this.btnReportadas = this.$("#btnReportadas");
        this.formRegistrar = this.$("#formRegistrar");
        this.formFiltro = this.$("#formFiltro");

        this.$("#FechaRegistro").datepicker({maxDate : 0});

        this.vistaSummary = new SummaryView();

        if (args)
        {
            if (args.id)
            {
                this.vistaDetalleDefecto = new DetallePerdidoView({ el: '#modalDetalleContenido' })
                this.vistaDetalleDefecto.cargar(args.id);
            }
        }
        

        this.vistaArchivo = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
        this.vistaArchivo.on("archivo-guardado", this.imagenGuardada, this);

        this.vistaArchivo2 = new SubirArchivoView({ name: "archivo", el: "#divArchivoPerdido2", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
        this.vistaArchivo2.on("archivo-guardado", this.imagenGuardada2, this);

        this.cargarRazas();

        this.model = new ContenidoPerdidoModel();

        this.render();
    },

    render: function () {
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    },
    cargarFormularioPerdido: function (obj) {

        this.tipoContenido = Constantes.TipoAnimalesPerdidos;
        this.cargarFormulario(obj);
    },
    cargarFormularioEncontrado: function (obj) {
        this.tipoContenido = Constantes.TipoAnimalesEncontrados;
        this.cargarFormulario(obj);
    },
    cargarFormularioFiltro: function (obj) {
        this.vistaZonas = new ZonasGeograficasView({ el: "#formFiltro", activarBarrios: true });
        obj = $(obj.currentTarget);
        this.opcionActual = obj.attr("id");
        this.ocultarPestanas();
        this.formFiltro.show();
        this.filtrarPerdidos();
    },
    cargarFormulario: function (obj) {
        this.vistaZonas = new ZonasGeograficasView({ el: "#formRegistrar", activarBarrios: true });
        obj = $(obj.currentTarget);
        this.model.set({ TipoContenidoId: this.tipoContenido });
        //this.cambioTipo();
        this.opcionActual = obj.attr("id");
        this.ocultarPestanas();
        this.formRegistrar.show();
    },

    cargarRazas : function()
    {
        this.listaRazasPerros = new TablaBasicaCollection();
        this.listaRazasPerros.razasPerros();

        this.listaRazasGatos = new TablaBasicaCollection();
        this.listaRazasGatos.razasGatos();
    },

    cambioTipo: function () {
        var tipo = parseInt(this.$("#formRegistrar input[name='rbTipo']:checked").val());
        this.model.set({ Tipo: tipo });
        var ddl = this.$("#formRegistrar #ddlRaza");
        this.cargarRazasPorTipo(tipo, ddl);
        
    },

    cambioTipoFiltro: function () {

        var tipo = parseInt(this.$("#formFiltro input[name='rbTipo']:checked").val());
        this.model.set({ Tipo: tipo });
        var ddl = this.$("#formFiltro #ddlRaza");
        this.cargarRazasPorTipo(tipo, ddl);
        
    },
    cargarRazasPorTipo: function (tipo, ddl) {
        
        var lista;
        
        if (tipo == Constantes.TipoPerro)
            lista = this.listaRazasPerros;
        else
            lista = this.listaRazasGatos;

        
        ddl.empty();
        ddl.append("<option>RAZA</option>")
        _.each(lista.toJSON(), function (element, index) {
            ddl.append("<option value='" + element.DatoTablaBasicaId + "'>" + element.Valor + "</option>");
        });

        ddl.show();
    },
    ocultarPestanas: function () {
        this.btnBusco.hide();
        this.btnEncuentro.hide();
        this.btnReportadas.hide();
        $("#" + this.opcionActual).show();
        $("#" + this.opcionActual).removeClass("sel");
    },
    imagenGuardada: function (respuesta) {
        if (respuesta.get("ArchivoId")) {
            this.model.set({ Imagen: respuesta.get("ArchivoId") });
        }
    },
    imagenGuardada2: function (respuesta) {
        if (respuesta.get("ArchivoId")) {
            this.model.set({ Imagen2: respuesta.get("ArchivoId") });
        }
    },
    guardar: function () {
        this.model.set({ ZonaGeograficaId: this.$("#ddlZonaBarrio").val() });
        this.model.set({ Raza: this.$("#formRegistrar #ddlRaza").val() });
        this.model.guardar({ success: this.contenidoGuardado, invalid: this.datosInvalidos }, this);
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
    },
    mostrarConfirmacion: function () {
        this.$("#camposFormulario").hide();
        this.$("#divMensajeConfirmacion").show();
        if (this.tipoContenido == Constantes.TipoAnimalesPerdidos)
            this.$("#msjBusco").show();
        else
            this.$("#msjEncuentro").show();
    },
    datosInvalidos: function (errores, ctx) {
        ctx.vistaSummary.mostrar(errores);
        Huellitas.marcarErroresFormulario(errores, ctx);
    },
    mostrarInicio: function () {
        $(".nav_busca li")
            .show()
            .addClass('sel');
        $(".nav_busca form").hide();
    },
    obtenerCampo: function (campo) {
        
        switch (campo) {
            case "tipoPerdido":
                var tipo = this.$("#formFiltro input[name='rbTipo']:checked").attr("value")
                return { valor: (tipo == undefined ? 0 : parseInt(tipo)), texto: "" };
            case "genero":
                var campo = this.$("#formFiltro #Genero :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "color":
                var campo = this.$("#formFiltro #Color :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "zonaPadre":
                var campo = this.$("#formFiltro #ddlZonaCiudad :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "zona":
                var campo = this.$("#formFiltro #ddlZonaBarrio :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "nombre":
                var campo = this.$("#formFiltro #Nombre");
                return { valor: campo.val(), texto: campo.val() };
            case "raza":
                var campo = this.$("#formFiltro #ddlRaza");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "fechaDesde":
                var campo = this.$("#formFiltro #FechaRegistro");
                return { valor: campo.val(), texto: campo.val() };
            default:
                return 0;
        }
    },
    cambiarOrden: function (nuevoOrden) {
        this.ordenarPor = parseInt(nuevoOrden);
        this.filtrarPerdidos();
    },
    obtenerFiltroSeleccionado: function () {
        var filtros = {
            tipoPerdido: this.obtenerCampo("tipoPerdido").valor,
            genero: this.obtenerCampo("genero").valor,
            color: this.obtenerCampo("color").valor,
            zonaPadre: this.obtenerCampo("zonaPadre").valor,
            zona: this.obtenerCampo("zona").valor,
            nombre: this.obtenerCampo("nombre").valor,
            raza: this.obtenerCampo("raza").valor,
            fechaDesde : this.obtenerCampo("fechaDesde").valor,
            esTipoPadre: true,
            orden: this.ordenarPor,
            paginaActual: -1
        };
        return filtros;
    }


});