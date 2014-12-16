using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoginCol.Huellitas.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ConsultasGeneralesAjax",
                url: "ajax{controller}/{action}/{id}",
                defaults: new { controller = "Generales", id = UrlParameter.Optional },
                constraints: new { controller = "Generales" }
            );


            #region Admin

            routes.MapRoute(name: "AdministracionIndex",
                url: "Admin/{action}",
                defaults: new { controller = "Administracion", action = "Index" },
                constraints: new { action = @"\b(?:(?!Submodulos)\w)+\b" });

            routes.MapRoute(name: "AdministracionSubmodulos",
                url: "Admin/{*queryValues}",
                defaults: new { controller = "Administracion", action = "Submodulos" },
                constraints: new { action = "(Submodulos)", queryValues = ".+" });
            
            routes.MapRoute(name: "Admin",
                url: "Admin/{controller}/{action}",
                defaults: new { controller = "Animales", action = "Index" });


            #endregion

            #region Imagenes

            routes.MapRoute(name: "ImagenesPorId",
              url: "img/{id}/{tamano}",
              defaults: new { controller = "Home", action = "ImagenId", tamano = "mini" },
              constraints: new { action = "ImagenId", controller = "Home", tamano = ("mini|medium|big"), id = @"\d+" });
            
            routes.MapRoute(name: "Imagenes",
              url: "img/{nombre}/{tamano}",
              defaults: new { controller = "Home", action = "Imagen", tamano = "mini" },
              constraints: new { action = "Imagen", controller = "Home", tamano = ("mini|medium|big"), nombre = new ContenidoRutaConstraint() });

            #endregion

            #region Front

            //routes.MapRoute(
            //    name: "BackboneDefault",
            //    url: "{*queryvalues}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    constraints: new { controller = "(Home)", queryvalues = "(Index|huellitas)" }
            //);

            routes.MapRoute(
                name: "BuscadorContenidosHuellitas",
                url: "sinhogar/buscar/{*queryValues}",
                defaults: new { controller = "Huellitas", action = "Index", queryValues = UrlParameter.Optional },
                constraints: new { controller = "(Huellitas)", action = "Index" }
            );

            routes.MapRoute(
                name: "BuscadorContenidos",
                url: "{controller}/buscar/{*queryValues}",
                defaults: new { controller = "Fundaciones", action = "Index", queryValues = UrlParameter.Optional },
                constraints: new { controller = "(Fundaciones)", action = "Index" }
            );

            routes.MapRoute(
                name: "InformacionAdopcion",
                url: "por-que-adoptar",
                defaults: new { controller = "Home", action = "Adoptar" },
                constraints: new { controller = "(Home)", action = "Adoptar" }
            );

            #region detalle Contenido

            //routes.MapRoute(
            //    name: "AdoptarHuellita",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Huellitas", action = "QuieroAdoptar" },
            //    constraints: new { controller = "Huellitas", action = "QuieroAdoptar", id = @"d\+" }
            //);
            
            routes.MapRoute(
                name: "DetalleContenidoHuellitas",
                url: "sinhogar/{id}/{nombre}",
                defaults: new { controller = "Huellitas", action = "Detalle" },
                constraints: new { controller = "(Huellitas)", action = "Detalle", id = @"\d+"}
            );

            routes.MapRoute(
                name: "DetalleContenido",
                url: "{controller}/{id}/{nombre}",
                defaults: new { controller = "Fundaciones", action = "Detalle" },
                constraints: new { controller = "(Fundaciones)", action = "Detalle", id = @"\d+" }
            );

            routes.MapRoute(
                name: "MostrarContenidosRelacionados",
                url: "{controller}/{id}/{nombre}/" + ParametrizacionNegocio.LlaveRouterVerTodos,
                defaults: new { controller = "Fundaciones", action = "ContenidosRelacionados", queryValues = UrlParameter.Optional },
                constraints: new { controller = "(Fundaciones)", action = "ContenidosRelacionados", id = @"\d+" }
            );

            routes.MapRoute(
                name: "QuieroAdoptar",
                url: "sinhogar/{id}/{nombre}/" + ParametrizacionNegocio.LlaveRouterQuieroAdoptar,
                defaults: new { controller = "Huellitas", action = "QuieroAdoptar", queryValues = UrlParameter.Optional },
                constraints: new { controller = "(Huellitas)", action = "QuieroAdoptar", id = @"\d+" }
            );

            routes.MapRoute(
                name: "HomeHuellitas",
                url: "sinhogar",
                defaults: new { controller = "Huellitas", action = "Index" },
                constraints: new { controller = "(Huellitas)", action = "Index" }
            );

            #endregion

            


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            #endregion

            
        }
    }
}