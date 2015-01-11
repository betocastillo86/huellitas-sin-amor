var SummaryView = Backbone.View.extend({
    
    el : '#divSummary',

    template: _.template($("#templateSummary").html()),

    mensajeInformativo: 'Para poder enviar el formulario, ingrese los siguientes datos:',

    titulo : 'Campos faltantes',

    initialize: function (args) {
        if(args)
        {
            if(args.titulo)
                this.titulo = args.titulo;
            if (args.mensajeInformativo)
                this.mensajeInformativo = args.mensajeInformativo;
        }
    },
    mostrar: function (errores) {
        this.$el.html(this.template({ errores: errores , mensaje : this.mensajeInformativo, titulo : this.titulo }));
        this.$el.dialog({ modal : true });
    }
});