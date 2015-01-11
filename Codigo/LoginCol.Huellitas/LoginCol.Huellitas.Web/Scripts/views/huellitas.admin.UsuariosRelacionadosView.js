var UsuariosRelacionadosView = Backbone.View.extend({

    el: "#divUsuariosRelacionados",

    template: _.template($("#templateUsuariosRelacionados").html()),

    idContenido: undefined,


    lista: undefined,

    templateFilaContenido: undefined,

    agregarContenidoView: undefined,

    app: undefined,



    initialize: function (args) {
        this.idContenido = args.id;
        
        this.lista = new UsuarioRelacionadoCollection();
        this.lista.on("add", this.mostrarFilaContenido, this);
        this.lista.on("remove", this.contenidoRelacionadoEliminado, this);
        this.templateFilaContenido = _.template($("#templateTrUsuarioRelacionado").html());
        this.agregarContenidoView = new AgregarUsuarioRelacionadoView({ id: args.id, idTipoContenido : args.idTipoContenido, parent: this, callback: "cargarContenidosRelacionadosPorTipo" });
        this.app = new AppHuellitas({ el: this.el });

        this.listenTo(Backbone, 'usuario-relacionado-agregado', this.cargarContenidosRelacionadosPorTipo, this);

        this.render();
        //this.delegate
    },

    render: function () {
        this.$el.html(this.template());
        this.$el.show();
    },
    events: {
        "change #TipoRelacionUsuario": "cargarContenidosRelacionadosPorTipo",
        "click #BtnMostrarAgregarTipoContenido": "mostrarVentanaAgregarContenido",
        "click [id^='EliminarContenidoRelacionado_']" : "eliminarContenidoRelacionado"
    },

    cargarContenidosRelacionadosPorTipo: function () {
        var tipoRelacionContenido = this.$("#TipoRelacionUsuario").val();
        

        if (tipoRelacionContenido != "")
        {
            this.$("#divFilasContenidosRelacionados").empty();
            //debugger;
            this.lista.reset();

            this.lista.cargarContenidos(this.idContenido, tipoRelacionContenido);
        }
        
    },
    mostrarFilaContenido: function (model) {
        this.$("#divFilasContenidosRelacionados").append(this.templateFilaContenido(model.toJSON()));
    },
    //Fin tipos de contenido
    mostrarVentanaAgregarContenido: function () {
        this.agregarContenidoView.mostrar();
    },
    eliminarContenidoRelacionado: function (context)
    {
        if (confirm("¿Está seguro de eliminar este contenido relacionado?"))
        {
            var objTarget = $(context.target);
            var idContenidoRelacionado = objTarget.attr("id").split('_')[1];
            //var idTipoRelacion = $("#TipoRelacionContenido").val();
            var contenidoRelacionado = this.lista.findWhere({ UsuarioContenidoId: parseInt(idContenidoRelacionado) });
            contenidoRelacionado.eliminar(idContenidoRelacionado);
            this.contenidoRelacionadoEliminado(contenidoRelacionado);
        }        
    },
    desactivar : function()
    {
        this.$el.empty();
        this.undelegateEvents();
    },
    contenidoRelacionadoEliminado: function (model)
    {
        this.app.consola("Eliminado contenido relacionado " + model.get("ContenidoRelacionadoId"));
        $("#trContenidoRelacionado_" + model.get("ContenidoRelacionadoId")).remove();
    }
});

