var InfoAdoptarView = Backbone.View.extend({
    initialize: function (args)
    {
        this.render();
    },
    render: function ()
    {
        this.$('#cbp-fwslider').cbpFWSlider();
        return this;
    }
});