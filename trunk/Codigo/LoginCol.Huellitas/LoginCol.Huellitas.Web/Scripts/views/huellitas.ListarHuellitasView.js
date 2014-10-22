//var ListarHuellitasView = Backbone.View.extend({
var ListarHuellitasView = Backbone.View.extend({
    el: "#divListarHuellitas",

    events : {
        "click #btnBuscar" : "filtrarContenidos"
    },

    obtenerCampo: function(campo)
    {
        switch (campo) {
            case "tipo":
                var tipo = this.$("input[name='rbTipo']:checked").attr("value")
                return tipo == undefined ? 0 : parseInt(tipo);
            case "genero":
                var genero = this.$("#ddlGenero").val();
                return isNaN(genero) ? 0 : parseInt(genero);
            case "color":
                var color = this.$("#ddlColor").val();
                return isNaN(color) ? 0 : parseInt(color);
            case "tamano":
                var tamano = this.$("#ddlTamano").val();
                return isNaN(tamano) ? 0 : parseInt(tamano);
            case "edad":
                var edad = this.$("#ddlEdad").val();
                return isNaN(edad) ? 0 : parseInt(edad);
            case "recomendadoPara":
                var recomendadoPara = "";
                _.each($("input[name='recomendadoPara']:checked"), function (element) { recomendadoPara += recomendadoPara.length == 0 ? element.value : "," + element.value; });
                return recomendadoPara;
            default:
                return 0;
        }
    },

    vistaResultados : undefined,

    initialize: function ()
    {
        this.vistaResultados = new ResultadosHuellitasView();
        this.vistaResultados.cargarContenidos();
        this.render();
    },
    render: function ()
    {
        return this;
    },
    filtrarContenidos: function ()
    {
        var filtros = {
            tipo: this.obtenerCampo("tipo"),
            genero: this.obtenerCampo("genero"),
            color: this.obtenerCampo("color"),
            tamano: this.obtenerCampo("tamano"),
            edad: this.obtenerCampo("edad"),
            recomendado: this.obtenerCampo("recomendadoPara")
        };

        this.vistaResultados.cargarContenidos(filtros);
    }
    
});