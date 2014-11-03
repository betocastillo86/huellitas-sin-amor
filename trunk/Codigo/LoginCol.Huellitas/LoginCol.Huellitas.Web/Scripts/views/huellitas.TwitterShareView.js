    var TwitterShareView = Backbone.View.extend({

        tagName: 'div',

        template: _.template($("#templateCompartirTwitter").html()),

        url: undefined,

        texto : undefined,

        initialize: function (args) {
            this.url = args.url;
            this.texto = args.texto;
            this.render();
        },
        render: function () {
            this.$el.html(this.template({Url : this.url, Texto : this.texto }));
            return this;
        }
    });