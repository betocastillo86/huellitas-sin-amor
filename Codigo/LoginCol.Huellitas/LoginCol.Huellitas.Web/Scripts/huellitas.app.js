var Huellitas = {
    
    obtenerNombreFuncion: function (fn)
    {
        return fn.toString().match(/function ([^\(]+)/)[1];
    },
    removerErroresFormulario: function (ctx)
    {
        _.each(ctx.$(".invalid"), function (obj) {
            $(obj).removeClass("invalid")
        });
    }

};