var UsuarioRelacionadoModel = Backbone.Model.extend({
    idAttribute: "UsuarioContenidoId",

    url: "/api/adminusuariorelacionado",

    guardar: function (idContenido, idUsuario, idTipoRelacion, success) {
        this.set({ ContenidoId: idContenido, UsuarioId: idUsuario, TipoRelacionId: idTipoRelacion });
        this.save();
    },
    eliminar: function (idUsuarioContenido) {
        this.url = "/api/adminusuariorelacionado/" + idUsuarioContenido;
        this.set({ UsuarioContenidoId: idUsuarioContenido })
        this.destroy({ wait: true });
    }
});

var UsuarioRelacionadoCollection = Backbone.Collection.extend({

    model: UsuarioRelacionadoModel,

    cargarContenidos: function (idContenido, idTipoRelacion) {
        this.url = "/api/adminusuariorelacionado/cid-" + idContenido + "/" + idTipoRelacion;
        this.fetch();
    }
});