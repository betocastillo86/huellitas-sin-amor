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

            routes.MapRoute(name: "AdministracionIndex",
                url: "Admin/{action}",
                defaults: new { controller = "Administracion", action = "Index" },
                constraints: new { action = "(OpcionesMenu)" });

            routes.MapRoute(name: "AdministracionSubmodulos",
                url: "Admin/{*queryValues}",
                defaults: new { controller = "Administracion", action = "Index" },
                constraints: new { action = "(Index)" });

            routes.MapRoute(name: "Admin",
                url: "Admin/{controller}/{action}",
                defaults: new { controller = "Animales", action = "Index" });

            routes.MapRoute(name: "ImagenesPorId",
              url: "img/{id}/{tamano}",
              defaults: new { controller = "Home", action = "ImagenId", tamano = "mini" },
              constraints: new { action = "ImagenId", controller = "Home", tamano = ("mini|medium|big"), id = @"\d+" });
            
            routes.MapRoute(name: "Imagenes",
              url: "img/{nombre}/{tamano}",
              defaults: new { controller = "Home", action = "Imagen", tamano = "mini" },
              constraints: new { action = "Imagen", controller = "Home", tamano = ("mini|medium|big"), nombre = new ContenidoRutaConstraint() });

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = "(Home)" }
            );
        }
    }
}