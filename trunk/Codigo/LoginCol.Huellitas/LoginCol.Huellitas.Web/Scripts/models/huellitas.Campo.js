var CampoModel = Backbone.Model.extend({
    url: "/api/campos",

    idAttribute : "CampoId",

    obtenerPorId: function (id)
    {
        this.url = "/api/campos/" + id;
        this.set("CampoId", id);
        this.fetch();
        return this;
    }
});

var CampoCollection = Backbone.Collection.extend({
    url: "/api/campos",


});