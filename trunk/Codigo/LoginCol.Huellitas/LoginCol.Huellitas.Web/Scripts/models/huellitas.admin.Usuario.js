var UsuarioModel = Backbone.Model.extend({
    url: "/api/adminusuarios",
    validation: {
        Nombres: {
            required: true,
            msg: "*"
        },
        Apellidos: {
            required: true,
            msg: "*"
        },
        Correo: {
            required: true,
            pattern: "email",
            msg: "*"
        }
    },

    guardar: function (args, ctx) {
        var resultValidation = this.validate();

        if (this.isValid()) {
            this.once("sync", args.success, ctx);
            this.save();
        }
        else {
            args.invalid(resultValidation, ctx);
        }
    }
});

var UsuarioCollection = Backbone.Collection.extend({
    url : "/api/adminusuarios",
    model: UsuarioModel,

    

    obtenerExternosActivos: function ()
    {
        this.fetch({ data: $.param({ admin: false, activo: true }) });
        return this;
    }
});