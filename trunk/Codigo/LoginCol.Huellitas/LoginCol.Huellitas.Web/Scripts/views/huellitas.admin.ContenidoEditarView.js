var ContenidoEditarView = Backbone.View.extend({
    el: "#divVistaEditarContenidos",

    events: {
        "change #ZonaGeograficaZonaGeograficaPadreZonaGeograficaId": "cargarCiudades",
        "click #GuardarContenido" : "guardarContenido"
    },

    template: _.template($("#templateEditarContenidoBase").html()),

    zonasGeograficas: undefined,

    tipoContenido : undefined,

    model: undefined,

    app: undefined,
       
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
        //if (App_Router.listarAnimalView == undefined || App_Router.listarAnimalView.lista == undefined) {
        //    this.model.set("ContenidoId", id);
        //    this.model.fetch();
        //}
        //else {
        //    this.model = App_Router.listarAnimalView.lista.get(id);
        //    this.mostrarContenido();
        //}
        this.model.set("ContenidoId", id);
        this.model.fetch();

        
        
    },
    mostrarContenido: function ()
    {
        var contenidoJson = this.model.toJSON();
        contenidoJson.TituloFormulario = "Editar Contenido";
        this.$el.html(this.template(contenidoJson));

        this.app.deserializarFormulario(this.model.attributes);
        $("#imgPrincipalContenido").html((new ImagenContenidoView({ id : this.model.get("Nombre")})).el);
           
        this.tipoContenido.set("TipoContenidoId", this.model.get("TipoContenidoId"));
        //this.tipoContenido.fetch();
        this.tipoContenido.once("change", this.cargarCamposAdicionales, this);

        this.cargarCiudades();

        this.$el.show();
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
    //Fin Campos adicionales
    guardarContenido: function ()
    {
        this.serializarFormulario();
    }

});