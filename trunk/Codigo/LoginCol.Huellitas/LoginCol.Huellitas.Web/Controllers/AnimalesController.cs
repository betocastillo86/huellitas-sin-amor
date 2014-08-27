

using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using AutoMapper;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AnimalesController : Controller
    {
        public ActionResult Listar()
        {
            return View("~/Views/Administracion/Animales/Index.cshtml");            
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(new ContenidosNegocio().ObtenerPorTipo(TipoContenidoEnum.Animal).Select(Mapper.Map<Contenido, ContenidoModel>).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
