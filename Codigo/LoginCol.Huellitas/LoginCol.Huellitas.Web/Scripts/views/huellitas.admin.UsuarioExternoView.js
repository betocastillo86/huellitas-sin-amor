var UsuarioExternoView = Backbone.View.extend({
    el: '#divUsuariosExternos',

    model: undefined,

    events: {
        'click #BtnCrearUsuario': 'habilitarCreacion',
        'click #BtnGuardar' : 'guardarUsuario'
    },
    bindings: {
        "#Nombres": "Nombres",
        '#Apellidos': 'Apellidos',
        '#Correo' : 'Correo'
    },
    
    initialize: function (args) {
        this.model = new UsuarioModel();
        this.render();
    },
    render: function () {
        
        this.deshabilitarCreacion();
        this.$("#tableListado").dataTable(optionsDataTable);
        
        this.stickit();
        Backbone.Validation.bind(this);
    },
    habilitarCreacion: function () {
        this.$('.crearUsuario').show();
    },
    deshabilitarCreacion: function () {
        this.$('.crearUsuario').hide();
    },

    guardarUsuario : function(){
        this.model.guardar({ success : this.usuarioGuardado, invalid : this.datosInvalidos }, this);
    },
    usuarioGuardado: function (model) {
        var respuesta = model.toJSON();
        if (respuesta.OperacionExitosa) {
            App_Router.alertaView.mostrar("Operacion Exitosa");
            this.deshabilitarCreacion();
        }
        else {
            App_Router.alertaView.mostrar("Se ha presentado un error, intente de nuevo");
        }
    },

    datosInvalidos: function (errores, ctx) {
        debugger;
        App_Huellitas.marcarErroresFormulario(errores, ctx);
        //App_Huellitas.limpiarFormulario(ctx, errores);
    }


});