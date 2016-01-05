function ValidarTamanoArchivo(obj, tamanoMaximo) {

    if (obj[0].files[0].size > tamanoMaximo) {
        App_Router.alertaView.mostrar("El tamaño del arhcivo no es valido");
        obj[0].files[0] = null;
        obj[0].value = "";
        return false;
    }
    else
        return true;
}

function ValidarExtensionArchivo(obj, extensionesPermitidas)
{
    if (!extensionesPermitidas.test(obj.val())) {
        obj.val("");
        $(obj).addClass("input-validation-error");
        return false;
    }
    else {
        $(obj).removeClass("input-validation-error");
        return true;
    }
}


function MostrarCargandoTodo(mostrar)
{
    if (mostrar) {
        $("#divLoadingAll").addClass('loading');
    }
    else {
        $("#divLoadingAll").removeClass('loading');
    }
}

/*scroll*/

    
