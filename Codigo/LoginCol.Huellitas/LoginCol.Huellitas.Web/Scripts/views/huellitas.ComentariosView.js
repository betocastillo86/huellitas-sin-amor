var ComentariosView = Backbone.View.extend({
    tagName: "div",

    contenidoId: undefined,

    events: {
        "click #btnGuardarComentario": "guardarComentario",
        "click #btnSiguientePagina": "siguientePagina"
    },

    bindings : {
        "#UsuarioNombres": "UsuarioNombres",
        "#CorreoElectronico": "CorreoElectronico",
        "#Texto": "Texto"
    },

    template: _.template($("#templateComentarios").html()),

    listadoComentarios: undefined,

    model: undefined,

    paginaActual : 0,

    initialize: function (args)
    {
        this.contenidoId = args.id;
        //this.el = args.el;

        this.iniciarModelo();
        //inicializa la lista de la vista
        this.listadoComentarios = new ComentarioCollection();
        
        this.consultarComentarios();
        
    },
    consultarComentarios : function()
    {
        //Carga los comentarios del contenido
        //this.listadoComentarios = new ComentarioCollection();
        //this.listadoComentarios.on("sync", this.cargarComentarios, this);
        //this.listadoComentarios.obtenerComentarios(this.contenidoId, this.paginaActual);
        var comentarios = new ComentarioCollection();
        comentarios.on("sync", this.cargarComentarios, this);
        comentarios.obtenerComentarios(this.contenidoId, this.paginaActual);
    },
    iniciarModelo: function ()
    {
        //Carga los comentarios
        this.model = new ComentarioModel();
        this.model.set({ ContenidoId: this.contenidoId, ComentarioId: undefined });
        this.$("#UsuarioNombres").val("");
        this.$("#CorreoElectronico").val("");
        this.$("#Texto").val("");
    },
    cargarComentarios: function (nuevoModelo)
    {
        if (nuevoModelo)
        {
            //Si es una colección agrega todo el listado, sino solo el que se acaba de crear
            if (nuevoModelo instanceof ComentarioCollection)
                this.listadoComentarios.add(nuevoModelo.models);
            else
            {
                alert("Quitar trigger del metodo guardarComentario");
                this.trigger("comentarioAgregado", nuevoModelo);
                this.listadoComentarios.push(nuevoModelo);
            }
                
            
            this.iniciarModelo();
        }

        this.render();
    },
    guardarComentario : function()
    {
        var nombre = this.$("#UsuarioNombres").val();
        var email = this.$("#CorreoElectronico").val();
        var comentario = this.$("#Texto").val();
        
        Huellitas.removerErroresFormulario(this);
        this.model.agregarComentario({ success: this.cargarComentarios, invalid: this.formularioInvalido }, this);
        this.trigger("comentarioAgregado", "");
        
    },
    formularioInvalido : function(errores, ctx)
    {
        _.each(errores, function (error, campo) {
            ctx.$("#" + campo).addClass("invalid");
            ctx.$("#" + campo + "Error").html(error);
        });
    },
    siguientePagina : function(obj)
    {
        this.$(obj.currentTarget).remove();
        this.paginaActual++;
        this.consultarComentarios();
    },
    render: function ()
    {
        this.$el.html(this.template(this.listadoComentarios.toJSON()));
        this.stickit();
        Backbone.Validation.bind(this);
        return this;
    }
});