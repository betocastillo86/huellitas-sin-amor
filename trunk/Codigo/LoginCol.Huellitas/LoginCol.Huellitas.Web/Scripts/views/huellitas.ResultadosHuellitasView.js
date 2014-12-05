var ResultadosHuellitasView = Backbone.View.extend({
    el: "#divResultadosBusqueda",

    events: {
        "click .siguientePagina" : "siguientePagina"
    },

    tipo : "h" , // f: Fundaciones h:Huellitas default:h

    listaContenidos: undefined,

    parametrosFiltro : undefined,

    template: _.template($("#templateResultadosBusqueda").html()),

    vistaMapa : undefined,

    initialize: function (args)
    {
        this.listaContenidos = new ContenidoCollection();

        if (args != undefined)
        {
            this.tipo = args.tipo;
        }
        

    },
    render: function ()
    {
        
        //this.$el.jscroll({ callback: "cargarContenidos", ctx: this, loadingHtml: "", debug: true });
        return this;
    },
    cargarContenidos: function (args)
    {
        //Si los argumentos de filtro no vienen toma los anteriores
        if (args != undefined)
            this.parametrosFiltro = args;

        this.parametrosFiltro.paginaActual++;

        var listaContenidos = new ContenidoCollection();
        listaContenidos.on("sync", this.mostrarContenidos, this);
        listaContenidos.cargarHuellitasPorFiltro(this.parametrosFiltro);
        //this.render();
    },
    mostrarContenidos : function(models)
    {
        var contenidos = models.toJSON();
        this.$el.append(this.template(contenidos));
        var ctx = this;

        _.each(models, function (element, index, list) {
            //si el contenido es de tipo fundacion carga el mapa
            element = list.at(index);
            if (ctx.tipo == "f") {
                //agrega el mapa con sus caracteristicas
                var mapa = new MapaView({ el: "#mapa" + element.get("ContenidoId"), 
                    latitud: parseFloat(element.obtenerValorCampo("Latitud")) , 
                    longitud: parseFloat(element.obtenerValorCampo("Longitud"))
                });
            }
        });

        //Para las fundaciones carga el scroll
        if (ctx.tipo == 'f')
            Huellitas.cargarScroll();

        this.listaContenidos.add(models);
    },
    siguientePagina: function (obj)
    {
        //Quita el botón que lanza el evento
        $(obj.currentTarget).remove();
        this.cargarContenidos();
    },
    limpiarResultados: function ()
    {
        this.$el.empty();
    }
});