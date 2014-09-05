var TamanoImagen = {
	pequena : "mini",
	mediana : "medium",
	grande : "large"
}

var ImagenContenidoView = Backbone.View.extend({

	tagName: "img",

	idContenido: undefined,

	tamano : "mini",

	initialize: function (args)
	{
		this.idContenido = args.id;

		if (args.tamano != undefined)
			this.tamano = args.tamano;

		this.render();
	},

	render: function ()
	{
		var urlImagen = "/img/"+this.idContenido+"/"+this.tamano
		this.$el.attr("src", urlImagen);
	}


});