var ListarFundacionesView = Backbone.View.extend({

	el : "#divListarFundaciones",

	events :{
		//"change #ddlZonaGeograficaPadre" : "cargarCiudades",
		"click #btnBuscar" : "filtrarFundaciones"
	},

	ddlZonaGeografica : undefined, 

	vistaResultados: undefined,

	vistaZonas: undefined,

	initialize: function (args) {
	    this.ddlZonaGeografica = this.$("#ddlZonaCiudad");
	    this.vistaResultados = new ResultadosHuellitasView({tipo:"f"});
	    this.vistaZonas = new ZonasGeograficasView({ el: "#formBusqueda" });

	    if (args != undefined) {
	        if (args.cargar != undefined && args.cargar)
	            this.vistaResultados.cargarContenidos(this.obtenerFiltroSeleccionado());
	    }
	    else {
	        //por defecto carga los resultados cuando no viene el parametro
	        this.vistaResultados.cargarContenidos(this.obtenerFiltroSeleccionado());
	    }
	},

	render: function () {
	    return;
	},

	//cargarCiudades : function(obj)
	//{
	//	var zonasGeograficas = new ZonaGeograficaCollection();
	//	zonasGeograficas.on("sync", this.mostrarCiudades, this);
	//	zonasGeograficas.obtenerZonasPorPadre($(obj.target).val());
	//},

	//mostrarCiudades : function(ciudades)
	//{
	//	var ddl = this.ddlZonaGeografica;
	//	ddl.empty();
	//	ddl.append("<option>CIUDAD</option>");
	//	_.each(ciudades.toJSON(), function(ciudad){
	//		ddl.append("<option value='"+ciudad.ZonaGeograficaId+"'>"+ciudad.Nombre+"</option>");
	//	});
	//},

	obtenerCampo : function(campo)
	{
		switch (campo) {
            case "zona":
                var campo = this.$("#ddlZonaCiudad :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            default:
                return 0;
        }

	},

	obtenerFiltroSeleccionado : function()
	{
	    var filtro = {
	        zona: this.obtenerCampo("zona").valor,
	        tipoPadre: Constantes.TipoContenidoFundaciones,
            orden : 0,
	        paginaActual: -1
	    };
		return filtro;
	},

	filtrarFundaciones : function()
	{
		var filtro = this.obtenerFiltroSeleccionado();
		var url = "";
        if (this.obtenerCampo("zona").valor > 0)
            url += "/z" + this.obtenerCampo("zona").valor + "_" + this.obtenerCampo("zona").texto;

        if (url != "")
        {
            url = "/fundaciones/buscar" + url;
            App_Router.navigate(url, { trigger: false });
        }

        this.vistaResultados.limpiarResultados();
        this.vistaResultados.cargarContenidos(filtro);
	},

	filtrarContenidosDesdeUrl: function (zona) {
	    var filtros = {
	        zona: zona == undefined ? 0 : parseInt(zona.split("_")[0]),
	        tipoPadre: Constantes.TipoContenidoFundaciones,
	        paginaActual: -1
	    };

	    if (filtros.zona > 0)
	        this.ddlZonaGeografica.val(filtros.zona);
	    
	    this.vistaResultados.cargarContenidos(filtros);
	}

});