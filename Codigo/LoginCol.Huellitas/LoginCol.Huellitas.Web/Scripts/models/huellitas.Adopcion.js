var AdopcionModel = Backbone.Model.extend({
    validation: {
        Nombres: {
            required:true
        },

        Ciudad: {
            required:true
        },

        Direccion: {
            required:true
        },

        Celular: {
            required: true
        },

        Correo: {
            required:true
        }
    }
});