var DetalleHuellitaView = Backbone.View.extend({
    el: "#divDetalleContenido",

    vistaComentarios : undefined,

    initialize: function (args)
    {

        this.vistaComentarios = new ComentariosView({ id: args.id, el: "#divComentarios" });
        this.render();
    },

    render: function ()
    {
        return this;
    }

});