var FacebookShareView = Backbone.View.extend({

    tagName: 'div',

    template: _.template($("#templateCompartirFacebook").html()),

    url : undefined,

    initialize: function (args)
    {
        this.url = args.url;
        this.render();
    },
    render: function ()
    {
        this.$el.html(this.template(this.url));
        return this;
    }
});