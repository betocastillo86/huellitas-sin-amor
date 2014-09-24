var ImagenModel = Backbone.Model.extend({
    url: "/api/adminimagenes",
    idAttribute: "ContenidoId",
    eliminar: function ()
    {
        this.url = "/api/adminimagenes/" + this.get("ContenidoId");
        this.destroy();
    }
});

var ImagenCollection = Backbone.Collection.extend({
    url: "/api/adminimagenes",
    
    initialize : function(args){
        if(args.idContenido == undefined)
            alert("Debe cargar un idContenido padre");

        this.url = "/api/adminimagenes/"+args.idContenido;
    },

    eliminar : function(modelo)
    {
        modelo.eliminar();
    },

    model : ImagenModel
});