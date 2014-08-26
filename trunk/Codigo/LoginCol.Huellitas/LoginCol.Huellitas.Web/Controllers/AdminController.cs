using LoginCol.Huellitas.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    
    public class AdministracionController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult OpcionesMenu()
        {
            List<OpcionMenu> opcionesMenu = new List<OpcionMenu>();
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 1, Nombre = "Animales", Vinculo = "/Admin/Animales" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 2, Nombre = "Fundaciones", Vinculo = "/Admin/Fundaciones" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 2, Nombre = "Usuarios", Vinculo = "/Admin/Usuarios" });
            return Json(opcionesMenu, JsonRequestBehavior.AllowGet);
        }

    }
}
