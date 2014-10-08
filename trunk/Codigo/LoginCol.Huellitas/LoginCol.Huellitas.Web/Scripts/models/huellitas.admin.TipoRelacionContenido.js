var TipoRelacionContenidoModel = Backbone.Model.extend({
    
});

var TipoRelacionContenidoCollection = Backbone.Collection.extend({
    model: TipoRelacionContenidoModel,

    obtenerPorTipoContenido: function (idTipoContenido) {
        this.url = "/ajaxgenerales/tiposrelacionesportipocontenido/" + idTipoContenido;
        this.fetch();
        return this;
    }
});