var ZonasGeograficasView = Backbone.View.extend({

    activarBarrios: false,

    zonasGeograficasCollection: undefined,

    opcionActual: undefined,

    idDepartamento: undefined,

    idCiudad: undefined,

    idBarrio : undefined,

    labelCiudad: "CIUDAD",

    labelBarrio: "BARRIO",

    labelDepartamento: "DEPARTAMENTO",

    ddlDepartamento: undefined,

    ddlCiudad: undefined,

    ddlBarrio : undefined,

    events: {
        "change #ddlZonaDepartamento": "cargarCiudades",
        "change #ddlZonaCiudad": "cargarBarrios"
    },

    initialize: function (args)
    {
        if(args.activarBarrios != undefined)
            this.activarBarrios = args.activarBarrios;


        if (args.idDepartamento)
            this.idDepartamento = args.idDepartamento;

        if (args.idCiudad)
            this.idCiudad = args.idCiudad;

        if (args.idBarrio)
            this.idBarrio = args.idBarrio;

        this.ddlDepartamento = this.$("#ddlZonaDepartamento");
        this.ddlCiudad = this.$("#ddlZonaCiudad");

        if (this.activarBarrios)
        {
            this.ddlBarrio = this.$("#ddlZonaBarrio");
        }

        this.zonasGeograficasCollection = new ZonaGeograficaCollection();
        this.zonasGeograficasCollection.on("sync", this.mostrarHijos, this);
        this.cargarDepartamentos();
    },
    cargarDepartamentos: function () {
        this.opcionActual = "departamentos";
        this.zonasGeograficasCollection.obtenerZonasPorPadre(Constantes.ZonaGeograficaPorDefecto);
    },
    cargarCiudades: function (obj) {
        var idDepartamento = isNaN(obj) ? $(obj.target).val() : obj ;
        this.opcionActual = "ciudades";
        this.zonasGeograficasCollection.obtenerZonasPorPadre(idDepartamento);
    },
    cargarBarrios: function (obj) {
        //Si no tiene activado los barrios no continua
        if (!this.activarBarrios)
            return;
        this.opcionActual = "barrios";
        this.zonasGeograficasCollection.obtenerZonasPorPadre($(obj.target).val());
    },
    mostrarHijos: function (hijos)
    {

        
        var ddl = undefined;
        var texto = "";
        var selected = undefined;
        //Metodo callback para continuar cargando los demás combos
        var continuarCargando;
        

        if (this.opcionActual == "ciudades")
        {
            ddl = this.ddlCiudad;
            texto = this.labelCiudad;
            selected = this.idCiudad;

            if (selected)
                continuarCargando = "cargarBarrios";
        }
        else if (this.opcionActual == "barrios") {
            ddl = this.ddlBarrio;
            texto = this.labelBarrio;
            selected = this.idBarrio;
        }
        else {
            texto = this.labelDepartamento;
            ddl = this.ddlDepartamento;
            selected = this.idDepartamento;
            //Si tiene una ciudad debe continuar cargando
            if (selected)
                continuarCargando = "cargarCiudades";
                
        }

        ddl.empty();
        ddl.append("<option>" + texto + "</option>");
        
        _.each(hijos.toJSON(), function (zona) {
            var textoSelected = selected == zona.ZonaGeograficaId ? "selected" : "";

            ddl.append("<option value='" + zona.ZonaGeograficaId + "' "+textoSelected+">" + zona.Nombre + "</option>");
        });

        //Si debe continuar cargando ejecuta la siguiente funcion
        if (continuarCargando)
            this[continuarCargando](selected);
    }
});