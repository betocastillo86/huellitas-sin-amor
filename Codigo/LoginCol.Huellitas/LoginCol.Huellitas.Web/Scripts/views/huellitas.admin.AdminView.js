var opcionesMenu = new OpcionMenuCollection();

var AdminView = Backbone.View.extend({
    el: "body",

    initialize: function ()
    {
        opcionesMenu.on("add", this.cargarOpcionesMenu);
        opcionesMenu.fetch();
    },

    cargarOpcionesMenu: function (modelo)
    {
        var menuView = new MenuView({ model: modelo });
        $("#nav-menu-izq").append(menuView.render().$el);
    },

    //agregarMenuHeader: function (tituloMenu)
    //{
    //    var menuView = new MenuView({ className : "nav-header", model: new OpcionMenu({ EsHeader: true, Nombre: tituloMenu }) });
    //    $("#nav-menu-izq").append(menuView.render());
    //}

});


var MenuView = Backbone.View.extend({
    tagName : "li",
    template: _.template($("#templateMenuIzq").html()),

    render: function () {
        this.$el.html(this.template(this.model.toJSON()));        
        return this;
    }
});

//Se instancia la nueva vista
var adminView = new AdminView();





