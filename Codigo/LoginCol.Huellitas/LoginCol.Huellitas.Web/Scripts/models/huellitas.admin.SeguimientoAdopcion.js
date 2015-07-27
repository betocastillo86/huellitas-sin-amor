var SeguimientoAdopcionModel = Backbone.Model.extend({
	
});

var SeguimientoAdopcionCollection = Backbone.Collection.extend({
	url: '/api/adminseguimiento',
	baseUrl: '/api/adminseguimiento',

	obtenerSeguimientosPorAdopcion: function (idAdopcion)
	{
		this.url = this.baseUrl + '/' + idAdopcion + '/all';
		this.fetch();
	}
});