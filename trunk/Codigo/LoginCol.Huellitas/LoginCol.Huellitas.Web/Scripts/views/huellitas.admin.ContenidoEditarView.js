var ContenidoEditarView = Backbone.View.extend({
    el: "#divVistaEditarContenidos",

    events: {
        "change #Departamento": "cargarCiudades"
    },

    template: _.template($("#templateEditarContenidoBase").html()),

    zonasGeograficas: undefined,

    tipoContenido : undefined,

    model: undefined,
       
    initialize: function (args)
    {
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
        $("#Nombre").val(this.model.get('Nombre'));
        $("#Descripcion").val(this.model.get('Descripcion'));
        $("#TipoContenidoId").val(this.model.get('TipoContenidoId'));
        $("#ZonaGeograficaId").val(this.model.get('ZonaGeograficaId'));
        $("#Email").val(this.model.get('Email'));
        $("#Facebook").val(this.model.get('Facebook'));
        $("#Twitter").val(this.model.get('Twitter'));
        $("#Activo").val(this.model.get('Activo'));

        $("#Departamento").val(this.model.get("ZonaGeograficaZonaGeograficaPadreZonaGeograficaId"));

        this.tipoContenido.set("TipoContenidoId", this.model.get("TipoContenidoId"));
        this.tipoContenido.fetch();
        this.tipoContenido.once("change", this.cargarCamposAdicionales, this);

        this.cargarCiudades();
        
        this.$el.show();
    },
    cargarCiudades: function ()
    {
        var idZonaPadre = $("#Departamento").val();
        this.autoSeleccionarZona = true;
        $("#ZonaGeograficaId").empty();
        this.zonasGeograficas.obtenerZonasPorPadre(idZonaPadre);
    },
    mostrarCiudades: function (ciudad)
    {        
        var selected = ciudad.get("ZonaGeograficaId") == this.model.get("ZonaGeograficaId");
        $("#ZonaGeograficaId").append("<option value='" + ciudad.get("ZonaGeograficaId") + "' "+ (selected ? "selected" : "") +" >" + ciudad.get("Nombre") + "</option>");
    }
});