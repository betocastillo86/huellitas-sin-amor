var AgregarUsuarioRelacionadoView = Backbone.View.extend({
    idContenido: undefined,

    el: "#divAgregarUsuarioRelacionado",

    template: _.template($("#templateAgregarUsuarioRelacionado").html()),

    templateListaUsuarios : undefined, 

    parent: undefined,

    callback: undefined,

    listaTipoRelaciones: undefined,

    listaUsuariosRelacionados : undefined,

    listaUsuariosDisponibles : undefined,

    tipoRelacionContenido: undefined,

    idTipoContenido: undefined,

    tablaListado : undefined,

    events: {
        "change #Relacionados_TipoRelacionContenido": "cargarUsuariosPorTipo",
        "click #tableUsuariosARelacionar .btn": "guardarUsuarioRelacionado"
    },

    initialize: function (args) {
        if (args != undefined) {
            if (args.id != undefined)
                this.idContenido = args.id;

            if (args.idTipoContenido != undefined)
                this.idTipoContenido = args.idTipoContenido;

            if (args.parent != undefined)
                this.parent = args.parent;

            if (args.callback != undefined)
                this.callback = args.callback;
        }


        this.listaTipoRelaciones = new TipoRelacionContenidoCollection();

        //Carga los usuarios que se pueden escoger
        this.listaUsuariosDisponibles = new UsuarioCollection();
        this.listaUsuariosDisponibles.obtenerExternosActivos();
        

        this.templateListaUsuarios = _.template($("#templateTrUsuarioAAgregar").html());

        this.listaUsuariosRelacionados = new UsuarioRelacionadoCollection();
        this.listaUsuariosRelacionados.cargarContenidos(this.idContenido, 0);

        this.render();
    },
    render: function () {
        this.$el.html(this.template({}));
        this.cargarTiposContenido();
    },
    mostrar: function () {
        this.$el.modal('show');
    },
    cerrar: function () {
        this.$el.modal('hide');
    },
    //Inicio TIPOS DE CONTENIDO
    listaTiposContenidos: undefined,
    cargarTiposContenido: function () {
        this.listaTiposContenidos = new TipoContenidoCollection();
        //$("#Relacionados_TiposContenido").empty();
        this.$("#Relacionados_TiposContenido").append("<option value='-1'>-</option>");

        this.listaTiposContenidos.on("add", this.agregarTipoContenidoALista, this);
        this.listaTiposContenidos.cargarTodos();
        //this.delegateEvents({ "change #Relacionados_TiposContenido": "cargarContenidosPorTipo" });
    },
    agregarTipoContenidoALista: function (model) {
        this.$("#Relacionados_TiposContenido").append("<option value='" + model.get("TipoContenidoId") + "'>" + model.get("Nombre") + "</option>");
    },
    //fin TIPOS DE CONTENIDO
    //Inicio FILTRAR POR TIPO DE CONTENIDO
    cargarUsuariosPorTipo: function () {

        var tipoRelacion = this.$("#Relacionados_TipoRelacionContenido").val();
        var usuariosParaMostrar = new Array();

        var ctx = this;

        _.each(this.listaUsuariosDisponibles.toJSON(), function (element, index) {
            
            //Si ell usuario no esta en la lista de los relacionados lo separa para mostrar
            if (ctx.listaUsuariosRelacionados.where({ TipoRelacionId: parseInt(tipoRelacion), UsuarioId: element.UsuarioId }).length == 0)
            {
                usuariosParaMostrar.push(element);
            }
        });

        
        if ($.fn.dataTable.isDataTable("#tableUsuariosARelacionar")) {
            this.tablaListado.fnClearTable();
            this.tablaListado.fnDestroy();
        }

        this.$("#tableUsuariosARelacionar tbody").html(this.templateListaUsuarios(usuariosParaMostrar));

        this.tablaListado = $("#tableUsuariosARelacionar").dataTable(App_Huellitas.parametrizacionDataTableMin);
    },
    //Fin FILTRAR POR TIPO DE CONTENIDO
    guardarUsuarioRelacionado: function (obj) {
        if (confirm("¿Está seguro de relacionar el usuario con el contenido?"))
        {
            var idUsuario = parseInt($(obj.target).attr("uid"));
            var idTipoRelacion = this.$("#Relacionados_TipoRelacionContenido").val();

            var modelo = new UsuarioRelacionadoModel();
            modelo.on("sync", this.contenidoGuardado, this);
            modelo.guardar(this.idContenido, idUsuario, idTipoRelacion);
        }
    },
    contenidoGuardado: function (respuesta) {
        if (respuesta.get("OperacionExitosa")) {
            this.listaUsuariosRelacionados.add(respuesta);
            this.cargarUsuariosPorTipo();
            Backbone.trigger('usuario-relacionado-agregado');
            this.cerrar();
        }
        else {
            App_Router.alertaView.mostrar(respuesta.get("MensajeError"));
        }
    }
});
