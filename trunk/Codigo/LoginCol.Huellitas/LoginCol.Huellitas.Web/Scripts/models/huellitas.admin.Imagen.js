var ImagenModel = Backbone.Model.extend({
    url: "/api/adminimagenes"
});

var ImagenCollection = Backbone.Model.extend({
    url: "/api/adminimagenes",
    
    initialize : function(args){
        if(args.idContenido == undefined)
            alert("Debe cargar un idContenido padre");

        this.url = "/api/adminimagenes/"+args.idContenido;
    },

    model : ImagenModel
});