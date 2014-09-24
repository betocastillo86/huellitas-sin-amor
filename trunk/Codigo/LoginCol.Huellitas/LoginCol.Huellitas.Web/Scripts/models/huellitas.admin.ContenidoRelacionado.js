var ContenidoRelacionadoModel = Backbone.Model.extend({
    idAttribute : "ContenidoRelacionadoId",

    url: "/api/admincontenidorelacionado",

    guardar: function (idContenido, idContenidoHijo, idTipoRelacion)
    {
        this.set({ ContenidoId: idContenido, ContenidoHijoId: idContenidoHijo, TipoRelacionContenidoId: idTipoRelacion })
        this.save();
    },
    eliminar: function (idContenido, idContenidoHijo, idTipoRelacion)
    {
        this.set({ ContenidoId: idContenido, ContenidoHijoId: idContenidoHijo, TipoRelacionContenidoId: idTipoRelacion })
        this.destroy({wait:true});
    }
});

var ContenidoRelacionadoCollection = Backbone.Collection.extend({

    model: ContenidoRelacionadoModel,

    cargarContenidos: function (idContenido, idTipoRelacion)
    {
        this.url = "/api/admincontenidorelacionado/cid-" + idContenido + "/" + idTipoRelacion;
        this.fetch();
    }
});