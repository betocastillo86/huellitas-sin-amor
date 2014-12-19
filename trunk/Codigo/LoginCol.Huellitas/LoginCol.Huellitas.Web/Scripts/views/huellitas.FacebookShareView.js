var FacebookShareView = Backbone.View.extend({

    tagName: 'div',

    events: {
            "click a" : "compartir"
    },

    template: _.template($("#templateCompartirFacebook").html()),

    url : undefined,

    initialize: function (args)
    {
        this.url = args.url;
        this.render();
    },
    compartir : function()
    {
        window.open('https://www.facebook.com/sharer/sharer.php?u='+this.url, '_blank', 'width=550, height=400');
    },
    render: function ()
    {
        this.$el.html(this.template(this.url));
        return this;
    }
});