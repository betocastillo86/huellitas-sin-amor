var ContenidoEditarView = Backbone.View.extend({
    el: "#divVistaEditarContenidos",

    url: "/api/admincontenidos/",

    events: {
        "change #ZonaGeograficaZonaGeograficaPadreZonaGeograficaId": "cargarCiudades",
        "click #GuardarContenido": "guardarContenido",
        "click #BtnCancelarEdicion": "desactivar",
        "click #BtnCrearContenido": "crearContenido",
        "change #TipoContenidoId": "cambiarTipoContenido",
        "change #Activo": "activarContenido",
        "click #VerGaleriaContenido": "verGaleria",
        "click #BtnGuardarImagen": "guardarImagen",
        "change #fileInput": "validarContenidoArchivo",
        

    },

    template: _.template($("#templateEditarContenidoBase").html()),

    zonasGeograficas: undefined,

    tipoContenido : undefined,

    model: undefined,

    app: undefined,

    galeriaView: undefined,

    //permite controlar las redirecciones 
    modulo : undefined,

    contenidosRelacionadosView: undefined,

    initialize: function (args)
    {
        this.app = new AppHuellitas({ el : this.el });

        if (this.$el == undefined)
            this.$el = $(this.el);

        this.modulo = args.modulo;

        this.zonasGeograficas = new ZonaGeograficaCollection();
        this.zonasGeograficas.on("add", this.mostrarCiudades, this);

        this.model = new ContenidoModel();
        this.model.on("sync", this.mostrarContenido, this);

        this.tipoContenido = new TipoContenidoModel();

        this.render(args);
    },
    render : function(args)
    {
        this.cargarContenido(args.id);
        this.$el.show();
        return this;
    },
    cargarContenido: function (id)
    {
        if (id > 0) {
            this.model.cargar(id);
            //this.model.set("ContenidoId", id);
            //this.model.fetch();
        }
        else {
            this.mostrarContenido();
        }
    },

    validarContenidoArchivo : function()
    {
        return this.app.validarContenidoArchivoGeneral("fileInput");
    },
    mostrarContenido: function ()
    {
        var contenidoJson = this.model.toJSON();
        contenidoJson.TituloFormulario = "Editar Contenido";
        
        this.$el.html(this.template(contenidoJson));

        this.app.deserializarFormulario(this.model.attributes);
        this.cargarImagenPrincipal();
           
        
        ////En los casos de creación no carga los campos adicionales desde el comienzo
        //if (this.model.get("ContenidoId") != "0")
        //{
        //    //this.tipoContenido.set("TipoContenidoId", this.model.get("TipoContenidoId"));
            
        //    //this.tipoContenido.once("change", this.cargarCamposAdicionales, this);
            this.cambiarTipoContenido();
        //}

        this.cargarCiudades();

        this.$el.show();
        this.app.cargarFuncionesFormularioPersiana();
        this.app.recargarValidadores();
        this.activarFuncionesEdicion(parseInt(this.model.get("ContenidoId")));
    },
    cargarImagenPrincipal: function()
    {
        $("#imgPrincipalContenido").html((new ImagenContenidoView({ id: this.model.get("ContenidoId"), evitarCache : true })).el);
    },
    //Ciudades
    cargarCiudades: function ()
    {
        this.app.consola("Carga las ciudades por padre");
        var idZonaPadre = $("#ZonaGeograficaZonaGeograficaPadreZonaGeograficaId").val();
        this.autoSeleccionarZona = true;
        $("#ZonaGeograficaId").empty();
        this.zonasGeograficas.obtenerZonasPorPadre(idZonaPadre);
    },
    mostrarCiudades: function (ciudad)
    {        
        var selected = ciudad.get("ZonaGeograficaId") == this.model.get("ZonaGeograficaId");
        $("#ZonaGeograficaId").append("<option value='" + ciudad.get("ZonaGeograficaId") + "' "+ (selected ? "selected" : "") +" >" + ciudad.get("Nombre") + "</option>");
    },
    //Fin ciudades
    //CamposAdicionales
    cambiarTipoContenido: function () {
        this.tipoContenido.set("TipoContenidoId", $("#TipoContenidoId").val());
        this.tipoContenido.once("change", this.cargarCamposAdicionales, this);
    },
    cargarCamposAdicionales: function () {
        this.app.consola("Carga los campos adicionales cargarCamposAdicionales");
        var templateAdicional = _.template($("#templateCampoAdicional").html());
        var divCamposAdicionales = $("#divCamposAdicionales");
        divCamposAdicionales.empty();

        _.each(this.tipoContenido.get("Campos"), function (element, index, list) {
            var obj = list[index];
            divCamposAdicionales.append(templateAdicional(obj));
        });

        this.mostrarCamposAdicionales();
    },
    mostrarCamposAdicionales: function () {
        
        _.each(this.model.get("Campos"), function (element, index, list) {
            element = list[index];
            var inputCampoAdicional = $("#idCampoAdicional_" + element.CampoId);
            inputCampoAdicional.val(element.Valor);
        });
    },
    obtenerCamposAdicionales: function () {

        var camposAdicionales = new Array();

        var app = this.app;

        _.each($("#divCamposAdicionales :input"), function (element, index, list) {
            element = list[index];
            camposAdicionales.push({ CampoId: app.obtenerIdDesdeCampo(element.id), Valor: $(element).val() });
        });

        return camposAdicionales;

    },
    //Fin Campos adicionales
    guardarContenido: function ()
    {
        if (this.$el.validate().form()) {
            this.model = this.app.serializarFormulario(this.model);
            this.model.set("Campos", this.obtenerCamposAdicionales());

            var values = {};
            _.each($('#form1').serializeArray(), function (input) {
                values[input.name] = input.value;
            })

            this.model.on("sync", this.contenidoGuardado, this);
            this.model.save();
            
        }
        else {
            App_Router.alertaView.mostrar("Revisar los campos obligatorios");
        }
    },
    contenidoGuardado : function(model, response, options){
        
        if (response.OperacionExitosa) {
            App_Router.alertaView.mostrar("Operación exitosa");
            //App_Router.navigate("admin/"+this.modulo+"/listar", { trigger: true });
            this.desactivar();
        }
        else {
            App_Router.alertaView.mostrar("Ha ocurrido un error:"+response.MensajeError);
        }
        
    },
    //Cuando está creando no permite realizar algunas acciones
    activarFuncionesEdicion : function(id)
    {
        if (id > 0) {
            $("#divImagenPrincipal").show();
            $("#VerGaleriaContenido").show();
            

            this.app.consola("Galeria de Contenido creada");
            this.galeriaView = new GaleriaContenidoView({ id: id });

            this.app.consola("Galeria de Contenidos Relacionados creada");
            this.contenidosRelacionadosView = new ContenidosRelacionadosView({ id: id });
        }
        else {
            $("#divImagenPrincipal").hide();
            $("#VerGaleriaContenido").hide();
        }
    },
    activarContenido : function()
    {
        $("#Activo").val($("#Activo:checked").length > 0);
    },
    verGaleria : function(){
        this.galeriaView.mostrar();
    },

    //Desactiva la vista despues
    desactivar: function () {
        //debugger;
        
        App_Router.navigate("admin/"+this.modulo+"/listar", { trigger: true });
        $("#imgPrincipalContenido").empty();
        if(this.contenidosRelacionadosView != undefined) this.contenidosRelacionadosView.desactivar();
        this.$el.hide();
        this.undelegateEvents();
        //this.remove();
    },

    //INICIO Guardar Imagenes
    guardarImagen : function()
    {
        
        if ($("#fileInput")[0].files.length == 1) {
            var imagen = new ImagenModel();
            this.listenTo(imagen,"imagen-guardada-ok", this.imagenGuardarOk);
            this.listenTo(imagen,"imagen-guardada-error", this.imagenGuardarError);
            imagen.set({ ContenidoId: this.model.get("ContenidoId") });
            this.app.consola("Antes de guardar imagen");
            imagen.guardarEnDisco($("#fileInput"));
        }
        else {
            $("#fileInput").addClass("field-validation-error");
        }
        
    },
    imagenGuardarOk : function()
    {
        App_Router.alertaView.mostrar("Imagen guardada correctamente");
        this.cargarImagenPrincipal();
    },
    imagenGuardarError : function()
    {
        App_Router.alertaView.mostrar("Error guardando la imagen", "Error");
    }
    //FIN GuardarImagenes


});