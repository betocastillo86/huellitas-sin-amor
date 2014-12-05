using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperInputExtensions 
    {
        //public static MvcHtmlString TextBoxForM<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,  Expression<Func<TModel, TProperty>> expression)
        //{
        //    return htmlHelper.TextBoxFor(expression, new { @class = "form-control" });
        //}

        public static string Parametrizacion(this HtmlHelper htmlHelper, string llave)
        {
            return ParametrizacionNegocio.String(llave);
        }

        //public static string ObtenerCampoDeContenido(this HtmlHelper htmlHelper, ContenidoModel modelo, string llave)
        //{
        //    StringBuilder str = new StringBuilder();

        //    modelo.Campos
        //        .Where(c => c.CampoNombre.Equals(llave))
        //        .ToList()
        //        .ForEach(c => {
                    
        //            if (str.Length > 0)
        //                str.Append(", ");

        //            str.Append(c.ValorTexto);
        //        });

        //    return str.ToString();
        //}

        public static string ObtenerCampoDeContenido(this HtmlHelper htmlHelper, ContenidoListadoModel modelo, string llave)
        {
            StringBuilder str = new StringBuilder();

            modelo.Campos
                .Where(c => c.CampoNombre.Equals(llave))
                .ToList()
                .ForEach(c =>
                {

                    if (str.Length > 0)
                        str.Append(", ");
                    str.Append(c.ValorTexto);
                });

            return str.ToString();
        }


        public static MvcHtmlString DropDownListZonas(this HtmlHelper htmlHelper, int? idZonaPadre, string seleccionar = "", string primeraOpcion = "DEPARTAMENTO", string estilo = "", string id = "ZonaGeograficaId")
        {
            ZonaGeograficaNegocio nZonas = new ZonaGeograficaNegocio();
            List<ZonaGeograficalModel> zonas = nZonas.ObtenerZonasGeograficasPorPadre(!idZonaPadre.HasValue ? ParametrizacionNegocio.ZonaGeograficaPorDefecto : idZonaPadre.Value)
                .Select(Mapper.Map<ZonaGeografica, ZonaGeograficalModel>)
                .ToList();
  
            return SelectExtensions
                .DropDownList(htmlHelper,
                                id,
                                new SelectList(zonas, "ZonaGeograficaId", "Nombre", seleccionar), primeraOpcion, new { @class = estilo });
        }


    }
}