var ResultadosHuellitasView = Backbone.View.extend({
    el: "#divResultadosBusqueda",

    events: {
        "click .siguientePagina": "siguientePagina",
        "change #ddlOrden" : "ordenar"
    },

    tipo : "h" , // f: Fundaciones h:Huellitas default:h

    listaContenidos: undefined,

    parametrosFiltro : undefined,

    template: _.template($("#templateResultadosBusqueda").html()),

    ordenadoPor: undefined,

    vistaMapa : undefined,

    initialize: function (args)
    {
        this.listaContenidos = new ContenidoCollection();

        if (args != undefined)
        {
            this.tipo = args.tipo;
        }
    },
    ordenar : function()
    {
        if (this.$("#ddlOrden").val() != "") {
            this.ordenadoPor = this.$("#ddlOrden").val();
            this.trigger("ordenar", this.ordenadoPor);
        }
        else
            return false;
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
        {
            this.parametrosFiltro = args;

            if (args.orden > 0) {
                this.$("#ddlOrden").val(args.orden);
                this.ordenadoPor = args.orden;
            }
        }
            

        this.parametrosFiltro.paginaActual++;

        var listaContenidos = new ContenidoCollection();
        var ctx = this;

        listaContenidos.on("fetch", function () {
            ctx.$el.append(Huellitas.cargador);
        }, this);

        listaContenidos.on("sync", this.mostrarContenidos, this);
        listaContenidos.cargarHuellitasPorFiltro(this.parametrosFiltro);
        //this.render();
    },
    mostrarContenidos : function(models)
    {
        var contenidos = models.toJSON();
        //this.$el.html(this.$el.html().replace(Huellitas.cargador, ""));
        this.$("#divLoading").remove();
        this.$(".listadoContenidos").append(this.template(contenidos));
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

        this.trigger('cargado');

        this.listaContenidos.add(models);
    },
    siguientePagina: function (obj)
    {
        //Quita el botón que lanza el evento
        $(obj.currentTarget).remove();
        this.$('br:last').remove();
        this.cargarContenidos();
    },
    limpiarResultados: function ()
    {
        this.$(".listadoContenidos").empty();
    }
});