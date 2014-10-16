//var ListarHuellitasView = Backbone.View.extend({
var ListarHuellitasView = BaseView.extend({
    el: "#divListarHuellitas",

    //templateName: "huellitas-listar",

    vistaResultados : undefined,

    initialize: function ()
    {
        this.vistaResultados = new ResultadosHuellitasView();
        this.vistaResultados.cargarContenidos();

        //var that = this;

        //TemplateManager.get(this.templateName, function (tmp) {
        //    //var html = tmp(that.model.toJSON());
        //    //that.$el.html(html);
        //    that.template = tmp;
        //    that.render();
        //});

        // this.cargarFiltros();

    },
    render: function ()
    {
        //this.$el.html(this.template());
        //return this;
    },
    cargarFiltros: function()
    {
        //this.cargarGeneros();
    },
    cargarGeneros: function ()
    {
        //if (this.listaGeneros == undefined)
        //{
        //    this.listaGeneros = new CampoModel();
        //    this.listaGeneros.on("sync", this.mostrarGeneros, this);
        //    this.listaGeneros.obtenerPorId(Constantes.CampoGeneroId);
        //}
    },
    mostrarGeneros: function ()
    {
        //$("#ddlGenero").empty();
        //$("#ddlGenero").append("<option>-</option>");

        //_.each(this.listaGeneros.get("CampoOpciones"), function (element, index, list) {
        //    $("#ddlGenero").append("<option value='" + element.OpcionId + "' >" + element.Texto + "</option>");
        //});
    }
    
});