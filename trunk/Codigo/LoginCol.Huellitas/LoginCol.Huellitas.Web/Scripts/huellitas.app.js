var Huellitas = {
    
    obtenerNombreFuncion: function (fn)
    {
        return fn.toString().match(/function ([^\(]+)/)[1];
    },
    removerErroresFormulario: function (ctx)
    {
        
        _.each(ctx.$(".invalid"), function (obj) {
            $(obj).removeClass("invalid");
        });

        _.each(ctx.$("span[id*='Error']"), function (obj) {
            //ctx.$("#" + campo + "Error").html("");
            $(obj).html("");
        });

    },
    marcarErroresFormulario: function (errores, ctx)
    {
        this.removerErroresFormulario(ctx);
        _.each(errores, function (error, campo) {
            ctx.$("#" + campo).addClass("invalid");
            ctx.$("#" + campo + "Error").html(error);
        });
    },
    limpiarFormulario : function(ctx, campos)
    {
        _.each(campos, function (campo) {
            ctx.$("#" + campo).val("");
        });
    },
    cargarScroll: function () {

        $.mCustomScrollbar.defaults.theme = "light-2"; //set "light-2" as the default theme

        $(".demo-y").mCustomScrollbar();

        $(".demo-x").mCustomScrollbar({
            axis: "x",
            advanced: { autoExpandHorizontalScroll: true }
        });

        $(".demo-yx").mCustomScrollbar({
            axis: "yx"
        });

        $(".scrollTo a").click(function (e) {
            e.preventDefault();
            var $this = $(this),
                rel = $this.attr("rel"),
                el = rel === "content-y" ? ".demo-y" : rel === "content-x" ? ".demo-x" : ".demo-yx",
                data = $this.data("scroll-to"),
                href = $this.attr("href").split(/#(.+)/)[1],
                to = data ? $(el).find(".mCSB_container").find(data) : el === ".demo-yx" ? eval("(" + href + ")") : href,
                output = $("#info > p code"),
                outputTXTdata = el === ".demo-yx" ? data : "'" + data + "'",
                outputTXThref = el === ".demo-yx" ? href : "'" + href + "'",
                outputTXT = data ? "$('" + el + "').find('.mCSB_container').find(" + outputTXTdata + ")" : outputTXThref;
            $(el).mCustomScrollbar("scrollTo", to);
            output.text("$('" + el + "').mCustomScrollbar('scrollTo'," + outputTXT + ");");
        });

    },
    //Toma una variable de la ruta armada en backbone y obtiene el valor INT, separador (_)
    //Ejemplo 2_Bogota toma unicamente el 2
    obtenerValorRutaBackboneInt: function (variable)
    {
        return variable == undefined ? 0 : parseInt(variable.split("_")[0]);
    },
    //De un listado de campos de un contenido, retorna el valor
    obtenerValorCampo : function(nombreCampo, campos)
    {
        var valor;

        if (nombreCampo == "Edad")
        {
            var edad = _.findWhere(campos, { CampoId: Constantes.CampoEdadId });
            if (edad == undefined)
                edad = "";
            else if (edad.Valor == 0)
                edad = "Menos de un año";
            else if (edad.Valor == 1)
                edad = "1 año";
            else
                edad = edad.Valor + " años";

            valor = edad;
        }
        else if (nombreCampo == "Raza")
        {
            var raza = _.findWhere(campos, { CampoId: Constantes.CampoRazaId })
            valor = raza == undefined ? "" : raza.ValorTexto;
        }

        return valor;
    },

    soloNumeros : function(evt){
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    },

    alerta : function(element)
    {
        element.dialog({

        });
    },
    init : function()
    {
        $("input[customval='int']").on("keypress", this.soloNumeros);
        $("input[customval='nokeypress']").on("keypress", function () { return false; });
    },

    

    cargador: "<div align=center id='divLoading'><img src='/images/cargar.gif'></div>"

};


var App_Router;

$(document).on("ready", function () {
    App_Router = new HuellitasRouter();
    Backbone.history.start({ pushState: true });

    //inicia la app y los metodos que corren por defecto
    Huellitas.init();
});

_.each(["Model", "Collection"], function (name) {
    // Cache Backbone constructor.
    var ctor = Backbone[name];
    // Cache original fetch.
    var fetch = ctor.prototype.fetch;

    // Override the fetch method to emit a fetch event.
    ctor.prototype.fetch = function () {
        
        // Trigger the fetch event on the instance.
        this.trigger("fetch", this);

        // Pass through to original fetch.
        return fetch.apply(this, arguments);
    };
});


