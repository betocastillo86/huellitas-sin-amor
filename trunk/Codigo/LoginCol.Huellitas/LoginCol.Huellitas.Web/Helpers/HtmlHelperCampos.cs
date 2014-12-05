using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperCampos
    {
        public static MvcHtmlString DropDownListCampoFor(this HtmlHelper htmlHelper, string nombreCampo, string seleccionar = "", string primeraOpcion = "-", string estilo = "")
        { 
            CampoNegocio nCampos = new CampoNegocio();
            Campo objCampo = nCampos.Obtener(nombreCampo);
            return SelectExtensions
                .DropDownList(htmlHelper,
                                nombreCampo,
                                new SelectList(objCampo.Opciones, "OpcionId", "Texto", seleccionar), primeraOpcion, new { @class = estilo });
        }
    }
}