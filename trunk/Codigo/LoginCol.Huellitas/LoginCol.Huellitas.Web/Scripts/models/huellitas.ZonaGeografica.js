var ZonaGeograficaModel = Backbone.Model.extend({
	url : "/ajaxgenerales/zonasgeograficas"
});

var ZonaGeograficaCollection = Backbone.Collection.extend({
	url: "/ajaxgenerales/zonasgeograficas",
	obtenerZonasPorPadre: function (idPadre)
	{
	    this.url = "/ajaxgenerales/zonasgeograficas/" + idPadre;
		this.fetch();
		return this;
	}
});