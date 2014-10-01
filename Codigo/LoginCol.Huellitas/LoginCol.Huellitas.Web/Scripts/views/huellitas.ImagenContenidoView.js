var TamanoImagen = {
	pequena : "mini",
	mediana : "medium",
	grande : "large"
}

var ImagenContenidoView = Backbone.View.extend({

	tagName: "img",

	idContenido: undefined,

	tamano: "mini",

    evitarCache : false,

	initialize: function (args)
	{
		this.idContenido = args.id;

		if (args.tamano != undefined)
		    this.tamano = args.tamano;

		if (args.evitarCache != undefined)
		    this.evitarCache = args.evitarCache;

		this.render();
	},

	render: function ()
	{
	    var cache = "";
	    if (this.evitarCache)
	        cache = "?cache="+Math.random();

	    var urlImagen = "/img/" + this.idContenido + "/" + this.tamano + cache;
		this.$el.attr("src", urlImagen);
	}


});