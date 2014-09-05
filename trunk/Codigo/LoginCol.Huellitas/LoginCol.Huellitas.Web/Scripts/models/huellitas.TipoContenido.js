var TipoContenidoModel = Backbone.Model.extend({
    url: "/ajaxgenerales/tipocontenido",
    defaults: {
        "TipoContenidoId": "0"
    },
    initialize: function () {
        this.on("change:TipoContenidoId", this.cargarTipoContenido);
    },
    cargarTipoContenido: function () {

        this.url = "/ajaxgenerales/TipoContenido/" + this.get("TipoContenidoId");
        this.fetch();


    }
});

var TipoContenidoCollection = Backbone.Model.extend({
    model: TipoContenidoModel

});