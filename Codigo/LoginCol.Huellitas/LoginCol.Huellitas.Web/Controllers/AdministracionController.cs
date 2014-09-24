using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    
    public class AdministracionController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string queryValues)
        {
            //Vista que va cargar dependiendo de la URL
            string vista = "Index";

            string[] partesUrl = queryValues.Split(new char[] { '/' });

            object modelo = null;

            switch (string.Format("{0}/{1}", partesUrl[0], partesUrl[1]))
            {
                case "animales/listar":
                case "animales/editar":
                case "animales/crear":
                    vista = "Animales/Index.cshtml";
                    ListarContenidoModel modeloAnimales = new ListarContenidoModel() { PrefijoAcciones = "animales" };
                    modeloAnimales.Contenido.Departamentos = new ZonaGeograficaNegocio().ObtenerZonasGeograficasPorPadre(Convert.ToInt32(ConfigurationManager.AppSettings["IdZonaGeograficaDefecto"]));
                    
                    modeloAnimales.Contenido.TiposDeContenido = new TipoContenidoNegocio().ObtenerPorPadre((int)TipoContenidoEnum.Animal);
                    modeloAnimales.Contenido.TiposRelacionContenido = new TipoContenidoNegocio().ObtenerTiposDeRelacionContenido((int)TipoContenidoEnum.Animal);
                    modelo = modeloAnimales;
                    break;
                default:
                    modelo = new ListarContenidoModel();
                    break;
            }

            return View(string.Format("~/Views/Administracion/{0}", vista), modelo);
        }

        [HttpGet]
        public JsonResult OpcionesMenu()
        {
            List<OpcionMenu> opcionesMenu = new List<OpcionMenu>();
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 1, Nombre = "Animales", Vinculo = "/admin/animales/listar" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 2, Nombre = "Fundaciones", Vinculo = "/Admin/Fundaciones/Listar" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 2, Nombre = "Usuarios", Vinculo = "/Admin/Usuarios/Listar" });
            return Json(opcionesMenu, JsonRequestBehavior.AllowGet);
        }


    }
}
