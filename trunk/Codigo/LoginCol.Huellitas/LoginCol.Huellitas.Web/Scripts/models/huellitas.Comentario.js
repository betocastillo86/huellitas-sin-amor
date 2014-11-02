var ComentarioModel = Backbone.Model.extend({
    url: "/api/comentarios",

    idAttribute: "ComentarioId",

    initialize : function()
    {
        
    },

    //agregarComentario: function (contenidoId, nombre, email, comentario)
    agregarComentario: function (args, ctx)
    {
        //this.set({ ContenidoId: contenidoId, UsuarioNombres: nombre, CorreoElectronico: email, Texto: comentario });
        var errores = this.validate();
        if (!errores) {
            this.once("sync", args.success, ctx);
            this.save();
        }
        else {
            args.invalid(errores, ctx);
        }
    },
    comentarioGuardado: function (modelo)
    {
        this.trigger("guardado", this);
    },
    validation: {
        CorreoElectronico: {
            required: true,
            msg: 'Ingrese correo electrónico',
            pattern : 'email'
        },
        Texto: {
            required: true,
            msg: 'Ingrese el comentario'
        },
        UsuarioNombres: {
            required: true,
            msg: 'Ingrese su nombre'
        }
    }
});

var ComentarioCollection = Backbone.Collection.extend({
    model: ComentarioModel,

    obtenerComentarios: function (contenidoId)
    {
        this.url = "/api/comentarios/cid-" + contenidoId;
        this.fetch();
        return this;
    },
    agregarComentario: function (contenidoId, nombre, email, comentario)
    {
        var modelo = new ComentarioModel();
        modelo.on("guardado", this.comentarioGuardado, this);
        modelo.on("invalido", this.comentarioInvalido, this);
        modelo.agregarComentario(contenidoId, nombre, email, comentario)
        return this;
    },
    comentarioGuardado: function (modelo)
    {
        this.add(modelo);
        this.trigger("guardado", this);
        return this;
    },
    comentarioInvalido: function (errores)
    {
        this.trigger("invalido", errores);
        return this;
    }
});