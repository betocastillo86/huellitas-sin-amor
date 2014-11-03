var VideoView = Backbone.View.extend({
    tagName: "div",

    events: {
        "click #btnVideo": "mostrarVideo",
        "click #btnCerrarVideo" : "cerrarVideo"
    },

    template : _.template($("#templateVideo").html()),

    urlVideo : undefined,

    initialize: function (args)
    {
        this.urlVideo = args.urlVideo;

        this.render();
    },
    
    mostrarVideo : function()
    {
        $("#divPlayerVideo").show();
    },
    cerrarVideo : function()
    {
        $("#divPlayerVideo").hide();
    },
    render: function ()
    {
        if (this.urlVideo)
        {
            this.$el.html(this.template({ UrlVideo: this.urlVideo }));
            this.$("#btnVideo").show();
        }

        return this;
    }

});