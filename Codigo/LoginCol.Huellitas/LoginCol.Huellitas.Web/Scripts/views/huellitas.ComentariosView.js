var ComentariosView = Backbone.View.extend({
    tagName: "div",

    contenidoId: undefined,

    events: {
      "click #btnGuardarComentario" : "guardarComentario"  
    },

    bindings : {
        "#UsuarioNombres": "UsuarioNombres",
        "#CorreoElectronico": "CorreoElectronico",
        "#Texto": "Texto"
    },

    template: _.template($("#templateComentarios").html()),

    listadoComentarios: undefined,

    model : undefined,

    initialize: function (args)
    {
        this.contenidoId = args.id;
        //this.el = args.el;

        //Carga los comentarios
        this.model = new ComentarioModel();
        this.listadoComentarios = new ComentarioCollection();
        this.listadoComentarios.on("sync", this.cargarComentarios, this);
        this.listadoComentarios.on("guardado", this.cargarComentarios, this);
        this.listadoComentarios.on("invalido", this.formularioInvalido, this);
        this.listadoComentarios.obtenerComentarios(this.contenidoId);
    },
    cargarComentarios: function (nuevoModelo)
    {
        if(nuevoModelo)
            this.listadoComentarios.push(nuevoModelo);

        this.render();
    },
    guardarComentario : function()
    {
        var nombre = this.$("#UsuarioNombres").val();
        var email = this.$("#CorreoElectronico").val();
        var comentario = this.$("#Texto").val();

        Huellitas.removerErroresFormulario(this);
        this.model.agregarComentario({ success : this.cargarComentarios, invalid : this.formularioInvalido }, this);
    },
    formularioInvalido : function(errores, ctx)
    {
        _.each(errores, function (error, campo) {
            ctx.$("#" + campo).addClass("invalid");
            ctx.$("#" + campo + "Error").html(error);
        });
    },
    render: function ()
    {
        this.$el.html(this.template(this.listadoComentarios.toJSON()));
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    }
});