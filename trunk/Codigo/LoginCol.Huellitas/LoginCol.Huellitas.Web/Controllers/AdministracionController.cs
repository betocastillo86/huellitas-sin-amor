using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Infraestructure;
using LoginCol.Huellitas.Web.Models;
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
        [HttpGet]
        [Authorize]
        public ActionResult Submodulos(string queryValues)
        {
            string vista = "Index";
            string[] partesUrl = queryValues.ToLower().Split(new char[] { '/' });
            object modelo = null;

            switch (string.Format("{0}/{1}", partesUrl[0], partesUrl[1]))
            {
                case "animales/listar":
                case "animales/editar":
                case "animales/crear":
                    vista = "Contenido/Index.cshtml";
                    ListarContenidoModel modeloAnimales = new ListarContenidoModel() { PrefijoAcciones = "animales", Titulo = "Administración de Animales" };
                    modeloAnimales.Contenido.Departamentos = new ZonaGeograficaNegocio().ObtenerZonasGeograficasPorPadre(Convert.ToInt32(ConfigurationManager.AppSettings["IdZonaGeograficaDefecto"]));
                    modeloAnimales.Contenido.TiposDeContenido = new TipoContenidoNegocio().ObtenerPorPadre((int)TipoContenidoEnum.Animal);
                    modeloAnimales.Contenido.TiposRelacionContenido = new TipoContenidoNegocio().ObtenerTiposDeRelacionContenido((int)TipoContenidoEnum.Animal);
                    modelo = modeloAnimales;
                    break;
                case "fundaciones/listar":
                case "fundaciones/editar":
                case "fundaciones/crear":
                    vista = "Contenido/Index.cshtml";
                    ListarContenidoModel modeloFundaciones = new ListarContenidoModel() { PrefijoAcciones = "fundaciones", Titulo = "Administración de Fundaciones" };
                    modeloFundaciones.Contenido.Departamentos = new ZonaGeograficaNegocio().ObtenerZonasGeograficasPorPadre(Convert.ToInt32(ConfigurationManager.AppSettings["IdZonaGeograficaDefecto"]));
                    modeloFundaciones.Contenido.TiposDeContenido = new TipoContenidoNegocio().ObtenerPorPadre((int)TipoContenidoEnum.Fundacion);
                    modeloFundaciones.Contenido.TiposRelacionContenido = new TipoContenidoNegocio().ObtenerTiposDeRelacionContenido((int)TipoContenidoEnum.Fundacion);
                    modelo = modeloFundaciones;
                    break;
                default:
                    modelo = new ListarContenidoModel();
                    break;
            }

            return View(string.Format("~/Views/Administracion/{0}", vista), modelo);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Index(LoginModel modelo)
        {
            if (this.ModelState.IsValid)
            {
                Autenticacion objAutenticacion = new Autenticacion();
                if (objAutenticacion.AutenticarUsuario(modelo.Usuario, modelo.Clave, true))
                {
                    return Redirect("/admin/animales/listar");
                    //return RedirectToAction("Index", new { queryValues = "animales/listar" });
                }
                else
                {
                    modelo.Error = "Valide las credenciales de nuevo";
                }
            }

            return View(modelo);
        }

        public ActionResult Salir()
        {
            Autenticacion.CerrarSesion();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult OpcionesMenu()
        {
            List<OpcionMenu> opcionesMenu = new List<OpcionMenu>();
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 1, Nombre = "Animales", Vinculo = "/admin/animales/listar" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 2, Nombre = "Fundaciones", Vinculo = "/admin/fundaciones/listar" });
            return Json(opcionesMenu, JsonRequestBehavior.AllowGet);
        }


    }
}
