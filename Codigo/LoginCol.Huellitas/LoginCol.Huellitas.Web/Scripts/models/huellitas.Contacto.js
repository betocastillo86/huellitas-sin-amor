var ContactoModel = Backbone.Model.extend({
    url: "api/contacto",
    validation: {
        CorreoElectronico: {
            required : true,
            msg : 'Ingrese correo electrónico',
            pattern : 'email'
        },

        Nombres: {
            required: true,
            msg : 'Ingrese los nombres'
        },

        Telefono: {
            required: false
        },

        Comentario: {
            required: true,
            msg : 'Ingrese el comentario'
        }
    },
    guardar: function (args, ctx) {
        var errores = this.validate();
        if (!errores) {
            this.once("sync", args.success, ctx);
            this.save();
        }
        else {
            args.invalid(errores, ctx);
        }
    }
});

var ContactoCollection = Backbone.Collection.extend({
    model : ContactoModel
});