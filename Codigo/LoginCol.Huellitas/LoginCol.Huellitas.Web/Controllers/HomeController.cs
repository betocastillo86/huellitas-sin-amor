using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        
        public ActionResult Listar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public void Guardar(int id, ContenidoModel modelo)
        {
            string a = "";
        }


    }

    public class ContenidoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }


}
