    var TwitterShareView = Backbone.View.extend({

        tagName: 'div',

        events: {
            "click a": "compartir"
        },

        template: _.template($("#templateCompartirTwitter").html()),

        url: undefined,

        texto : undefined,

        initialize: function (args) {
            this.url = args.url;
            this.texto = args.texto;
            this.render();
        },
        compartir: function () {
            window.open('https://twitter.com/intent/tweet?via=hsinhogar&source=webclient&url=' + this.url + '&text=' + this.texto + '&original_referer=' + this.url, '_blank', 'width=500, height=300');
        },
        render: function () {
            this.$el.html(this.template({Url : this.url, Texto : this.texto }));
            return this;
        }
    });