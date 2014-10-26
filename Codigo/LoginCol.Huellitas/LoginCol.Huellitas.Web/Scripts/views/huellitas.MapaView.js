var MapaView = Backbone.View.extend({
    //tagName: "div",

    propiedades: undefined,

    mapa: undefined,

    marcador: undefined,

    latlng : undefined,

    initialize: function (args)
    {
        this.setElement(args.el);
        
        this.latlng = new google.maps.LatLng(args.latitud, args.longitud);

        this.propiedades = {
            //center: new google.maps.LatLng(args.latitud, args.longitud),
            center: this.latlng,
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        this.mapa = new google.maps.Map(this.el, this.propiedades);

        this.marcador = new google.maps.Marker({
            position: this.latlng,
            map: this.mapa
        });

        this.render();
    },
    render: function ()
    {
        
        this.$el.show();
        return this;
    }

});