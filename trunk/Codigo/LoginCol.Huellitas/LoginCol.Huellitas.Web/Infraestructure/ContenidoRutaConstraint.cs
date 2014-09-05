using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace LoginCol.Huellitas.Web.Infraestructure
{
    public class ContenidoRutaConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values["nombre"] != null)
            {
                Contenido contenido = new ContenidoNegocio().ObtenerPorNombre(values["nombre"].ToString(), true);
                return true;
            }
            else
                return false;
        }
    }
}