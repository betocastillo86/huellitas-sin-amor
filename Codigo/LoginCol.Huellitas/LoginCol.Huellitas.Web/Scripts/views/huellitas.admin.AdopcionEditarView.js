var AdopcionEditarView = Backbone.View.extend({
    el: "#formAdopcion",

    id: 0,

    edit : false,

    templateSeguimientos : undefined, 

    initialize: function (args) {
        //Si viene Id se encuentra editando
        this.edit = args.id != undefined;
        this.id = args.id;
        this.cargarControles();
    },

    cargarControles: function () {
        //La fecha es solo para la creación
        if (!this.edit)
            this.$("#FechaAdopcion").datepicker({ maxDate: '0d', changeYear: true, changeMonth: true });
        else
        {
            this.templateSeguimientos = _.template($("#templateSeguimientos").html());
            this.cargarSeguimientos();
        }
    },
    cargarSeguimientos: function () {
        var seguimientosCollection = new SeguimientoAdopcionCollection();
        seguimientosCollection.on("sync", this.mostrarSeguimientos, this);
        seguimientosCollection.obtenerSeguimientosPorAdopcion(this.id);
    },
    mostrarSeguimientos: function (seguimientos)
    {
        this.$("#divSeguimientos").html(this.templateSeguimientos(seguimientos.toJSON()));
    }
});