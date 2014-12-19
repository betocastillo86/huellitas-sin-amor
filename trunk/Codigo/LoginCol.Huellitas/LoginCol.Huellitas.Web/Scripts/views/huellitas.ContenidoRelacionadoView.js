var ContenidoRelacionadoView = Backbone.View.extend({

    contenidoPadreId: 0,

    events: {
        "click .cajaSimilar" : "direccionarContenido"
    },

    tipoRelacion: 0,

    template: _.template($("#templateContenidosRelacionados").html()),

    listaContenidos: undefined,
    
    mostrarOpcionVerTodos: false,

    linkVerTodos : undefined,

    titulo : undefined,

    initialize: function (args)
    {
       

        this.contenidoPadreId = args.id;
        this.tipoRelacion = args.tipoRelacion;
        this.titulo = args.titulo;

        if (args.mostrarOpcionVerTodos != undefined)
        {
            this.mostrarOpcionVerTodos = args.mostrarOpcionVerTodos;
        }

        if (args.linkVerTodos != undefined) {
            this.linkVerTodos = args.linkVerTodos;
        }

        this.listaContenidos = new ContenidoRelacionadoCollection();
        this.listaContenidos.on("sync", this.mostrarContenidos, this);
        this.listaContenidos.cargarContenidos(this.contenidoPadreId, this.tipoRelacion);
    },
    direccionarContenido : function(obj)
    {
        document.location.href = $(obj.target).find('a').attr('href');
    },
    mostrarContenidos : function()
    {
        this.render();
    },
    render: function ()
    {
        if (this.listaContenidos.length > 0)
        {
            this.$el.html(this.template(
            {
                Titulo: this.titulo,
                Contenidos: this.listaContenidos.toJSON(),
                VerTodos: this.mostrarOpcionVerTodos,
                LinkVerTodos: this.linkVerTodos
            }));

            $('#cbp-fwslider').cbpFWSlider();
        }


        
        return this;
    }
});