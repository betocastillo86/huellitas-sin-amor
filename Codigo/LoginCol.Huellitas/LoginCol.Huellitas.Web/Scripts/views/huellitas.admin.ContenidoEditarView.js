var ContenidoEditarView = Backbone.View.extend({
    el: "#divVistaEditarContenidos",

    events: {
        "change #ZonaGeograficaZonaGeograficaPadreZonaGeograficaId": "cargarCiudades",
        "click #GuardarContenido": "guardarContenido",
        "click #BtnCancelarEdicion": "desactivar",
        "click #BtnCrearContenido": "crearContenido",
        "change #TipoContenidoId": "cambiarTipoContenido",
        "change #Activo": "activarContenido",
        "clicl #VerGaleriaContenido": "verGaleria",
    },

    template: _.template($("#templateEditarContenidoBase").html()),

    zonasGeograficas: undefined,

    tipoContenido : undefined,

    model: undefined,

    app: undefined,

    galeriaView : undefined,

    initialize: function (args)
    {
        this.app = new AppHuellitas({ el : this.el });

        if (args.url != undefined)
            this.url = args.url;

        if (this.$el == undefined)
            this.$el = $(this.el);

        this.zonasGeograficas = new ZonaGeograficaCollection();
        this.zonasGeograficas.on("add", this.mostrarCiudades, this);

        this.model = new ContenidoModel({ url: this.url });
        this.model.on("change:Nombre", this.mostrarContenido, this);


        this.app.consola("Galeria de Contenido creada");
        this.galeriaView = new GaleriaContenidoView({ id : args.id });
        
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
            this.model.set("ContenidoId", id);
            this.model.fetch();
        }
        else {
            this.mostrarContenido();
        }
    },
    mostrarContenido: function ()
    {
        var contenidoJson = this.model.toJSON();
        contenidoJson.TituloFormulario = "Editar Contenido";
        
        this.$el.html(this.template(contenidoJson));

        this.app.deserializarFormulario(this.model.attributes);
        $("#imgPrincipalContenido").html((new ImagenContenidoView({ id : this.model.get("Nombre")})).el);
           
        
        ////En los casos de creación no carga los campos adicionales desde el comienzo
        //if (this.model.get("ContenidoId") != "0")
        //{
        //    //this.tipoContenido.set("TipoContenidoId", this.model.get("TipoContenidoId"));
            
        //    //this.tipoContenido.once("change", this.cargarCamposAdicionales, this);
            this.cambiarTipoContenido();
        //}

        this.cargarCiudades();

        this.$el.show();
        this.app.recargarValidadores();
    },
    //Ciudades
    cargarCiudades: function ()
    {
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
            this.model.save({}, {success : this.contenidoGuardado });
            
        }
        else {
            App_Router.alertaView.mostrar("Revisar los campos obligatorios");
        }
    },
    contenidoGuardado : function(model, response, options){
        
        if (response.OperacionExitosa) {
            App_Router.alertaView.mostrar("Operación exitosa");
            App_Router.navigate("admin/animales/listar", { trigger: true });
        }
        else {
            App_Router.alertaView.mostrar("Ha ocurrido un error:"+response.MensajeError);
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
        this.$el.hide();
        this.undelegateEvents();
        //this.remove();
    }

});