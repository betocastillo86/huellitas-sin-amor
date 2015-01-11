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
        "change #Destacado" : "destacarContenido",
        "click #VerGaleriaContenido": "verGaleria"
    },

    template: _.template($("#templateEditarContenidoBase").html()),

    zonasGeograficas: undefined,

    tipoContenido : undefined,

    model: undefined,

    app: undefined,

    galeriaView: undefined,

    vistaSubirArchivo : undefined,

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
    mostrarContenido: function ()
    {
        var contenidoJson = this.model.toJSON();
        contenidoJson.TituloFormulario = "Editar Contenido";
        
        this.$el.html(this.template(contenidoJson));

        this.app.deserializarFormulario(this.model.attributes);
        this.cargarImagenPrincipal();
           
        

        this.cambiarTipoContenido();
        

        this.cargarCiudades();

        this.vistaSubirArchivo = new SubirArchivoView({ name: "archivo", el: "#divArchivoContenidoCargado", extensionesPermitidas: Constantes.ExtensionesImagenes, tamanoMaximo: Constantes.TamanoMaximoCargaArchivos });
        this.vistaSubirArchivo.on("archivo-guardado", this.imagenGuardada, this);

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
        var camposAdicionalesTipo = this.tipoContenido.get("Campos");

        _.each(this.model.get("Campos"), function (element, index, list) {
            
            var tipo = _.findWhere(camposAdicionalesTipo, { CampoId: element.CampoId }).CampoTipoDato;

            //Si es de seleccion multiple checkea los valores
            if (tipo == 6) {
                var inputCampoAdicional = $("input[name='idCampoAdicionalMultiple_"+element.CampoId+"'][value='" + element.Valor + "']");
                inputCampoAdicional.prop("checked", true);
            }
            if (tipo == 2)
            {
                var inputCampoAdicional = $("#idCampoAdicional_" + element.CampoId);
                inputCampoAdicional.prop("checked", element.Valor == "true");
            }
            else {
                element = list[index];
                var inputCampoAdicional = $("#idCampoAdicional_" + element.CampoId);
                inputCampoAdicional.val(element.Valor);
            }

            
        });
    },
    obtenerCamposAdicionales: function () {

        var camposAdicionales = new Array();

        var app = this.app;

        _.each($("#divCamposAdicionales :input"), function (element, index, list) {
            element = $(list[index]);

            //busca el id del campo
            var idCampo = app.obtenerIdDesdeCampo(element.attr("id"));

            var guardarCampo = true;

            //Si el de opcion multiple se debe validar si el elmento está checkeado para agregarlo o no
            if (element.attr("id").indexOf('Multiple') > 0) {
                guardarCampo = element.is(":checked");
            }
            else {
                if (element.attr("type") == "checkbox")
                {
                    element.val(element.is(":checked") ? "true" : "false");
                }
            }

            if (guardarCampo)
            {
                camposAdicionales.push({ CampoId: idCampo, Valor: element.val() });
            }
            

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
                if (input.name == "Activo")
                    input.value = input.value == "true";

                if (input.name == "Destacado")
                    input.value = input.value == "true";

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
            this.app.consola("Galeria de Contenido creada");
            this.galeriaView = new GaleriaContenidoView({ id: id });

            this.app.consola("Vista Contenidos Relacionados creada");
            this.contenidosRelacionadosView = new ContenidosRelacionadosView({ id: id, idTipoContenido: this.model.get('TipoContenidoId') });

            this.app.consola("Vista Usuarios Relacionados creada");
            this.contenidosRelacionadosView = new UsuariosRelacionadosView({ id: id, idTipoContenido: this.model.get('TipoContenidoId') });
        }
        
    },
    activarContenido : function()
    {
        $("#Activo").val($("#Activo:checked").length > 0);
    },
    destacarContenido: function () {
        $("#Destacado").val($("#Destacado:checked").length > 0);
    },
    verGaleria : function(){
        this.galeriaView.mostrar();
    },

    //Desactiva la vista despues
    desactivar: function () {
        document.location.href = "/admin/" + this.modulo + "/listar";
    },

    //INICIO Guardar Imagenes
    imagenGuardada: function (respuesta) {
        if (respuesta.get("ArchivoId")) {
            this.model.set({ Imagen: respuesta.get("ArchivoId") });
            this.$("#ArchivoId").val(respuesta.get("ArchivoId"));
            //this.$("#Imagen").val(respuesta.get("ArchivoId"));
        }
        else {
            App_Router.alertaView.mostrar("Error guardando la imagen", "Error");
        }
    }
    //FIN GuardarImagenes


});