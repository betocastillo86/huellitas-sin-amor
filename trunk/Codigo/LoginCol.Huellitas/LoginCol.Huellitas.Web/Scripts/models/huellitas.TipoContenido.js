var TipoContenidoModel = Backbone.Model.extend({
    url: "/ajaxgenerales/tipocontenido",
    defaults: {
        "TipoContenidoId": "0"
    },
    initialize: function () {
        this.on("change:TipoContenidoId", this.cargarTipoContenido);
    },
    cargarTipoContenido: function () {

        if (this.get("TipoContenidoId") != null)
        {
            this.url = "/ajaxgenerales/TipoContenido/" + this.get("TipoContenidoId");
            this.fetch();
        }
        
    }
});

var TipoContenidoCollection = Backbone.Collection.extend({
    model: TipoContenidoModel,

    cargarTodos: function () {
        this.url = "/ajaxgenerales/TiposContenidos/";
        this.fetch();
        return this;
    }

});