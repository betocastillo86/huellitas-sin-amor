var HuellasFundacionView = Backbone.View.extend({
    el: "#divHuellasRelacionadas",

    idContenido: undefined,

    vistaResulados : undefined,

    initialize: function (args)
    {

        var filtros = {
            fundacion: parseInt(args.id),
            paginaActual: -1
        };

        this.idContenido = args.id;
        this.vistaResulados = new ResultadosHuellitasView();
        this.vistaResulados.cargarContenidos(filtros);

        //var filtros = {
        //    tipo: this.obtenerCampo("tipo").valor,
        //    genero: this.obtenerCampo("genero").valor,
        //    color: this.obtenerCampo("color").valor,
        //    tamano: this.obtenerCampo("tamano").valor,
        //    edad: this.obtenerCampo("edad").valor,
        //    recomendado: this.obtenerCampo("recomendadoPara").valor,
        //    fundacion: this.obtenerCampo("fundacion").valor,
        //    zonaPadre: this.obtenerCampo("zonaPadre").valor,
        //    zona: this.obtenerCampo("zona").valor,
        //    paginaActual: -1
        //};
    }
});