﻿var Huellitas = {
    
    obtenerNombreFuncion: function (fn)
    {
        return fn.toString().match(/function ([^\(]+)/)[1];
    },
    removerErroresFormulario: function (ctx)
    {
        _.each(ctx.$(".invalid"), function (obj) {
            $(obj).removeClass("invalid")
        });
    },
    marcarErroresFormulario: function (errores, ctx)
    {
        _.each(errores, function (error, campo) {
            ctx.$("#" + campo).addClass("invalid");
            ctx.$("#" + campo + "Error").html(error);
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
    }

};