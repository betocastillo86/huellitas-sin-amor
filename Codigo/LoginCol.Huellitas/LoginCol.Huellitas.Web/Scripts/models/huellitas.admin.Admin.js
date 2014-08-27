var OpcionMenu = Backbone.Model.extend({
	
});


var OpcionMenuCollection = Backbone.Collection.extend({
	model: OpcionMenu,
	url: "/Admin/OpcionesMenu",
	initialize: function () {
		console.log("Creada instancia de OpcionMenuCollection");
	}

});