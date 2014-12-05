var ArchivoModel = Backbone.Model.extend({
    url: '/api/archivos',

    idAttribute : 'ArchivoId',

    initialize: function ()
    {

    },
    guardar: function () {

        var archivo = this.get('Archivo');
        if (!archivo)
            alert("No hay campo archivo");

        this.set('NombreArchivo', this.get('Archivo').name);

        var data = new FormData();
        data.append('file', archivo);

        var context = this;

        $.ajax({
            url: context.url,
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (data) {
                //
                context.archivoGuardado(data);
            },
            error: function (data) {
                context.trigger("archivo-guardado", { OperacionExitosa : false, MensajeError : 'Error Guardando los archivos' });
            }
        });
    },
    archivoGuardado: function (respuesta)
    {
        if (respuesta.OperacionExitosa) {
            this.set( 'ArchivoId', respuesta.InformacionAdicional );
        }
        else {
            this.unset('Archivo');
            this.unset('ArchivoId');
            this.unset('NombreArchivo');
        }

        this.trigger("archivo-guardado", respuesta);
    }


});