using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Infraestructure
{
    public class SumarVisitaAttribute : ActionFilterAttribute, IActionFilter
    {
        Lazy<ContenidoNegocio> nContenido;

        public SumarVisitaAttribute()
        {
            nContenido = new Lazy<ContenidoNegocio>();
        }
        
        
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            

        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Obtiene el id del contenido
            if (filterContext.RouteData.Values["id"] != null)
            {
                string id = filterContext.RouteData.Values["id"].ToString();

                using (var cookie = new CookiesManager(filterContext.RequestContext.HttpContext))
                {
                    //Si el contenido no ha sido visitado previamente suma la visita del contenido
                    if (cookie.AgregarContenidoVisitado(id))
                    {
                        nContenido.Value.SumarVisita(Convert.ToInt32(id));
                    }
                }

            }
        }
    }
}