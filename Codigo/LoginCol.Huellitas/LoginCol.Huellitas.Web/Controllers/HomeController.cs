using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string queryValues)
        {
            
            return View();
        }

        public ActionResult huellitas()
        {
            return View();
        }

       // [HttpGet]
        
        //public ActionResult Listar()
        //{
        //    return View();
        //}

        //[HttpGet]
        public ActionResult Listar(int? id)
        {
            return View();
        }


        [HttpGet]
        public FileResult Imagen(string nombre, string tamano)
        { 
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return File(Server.MapPath(contenidoNegocio.ObtenerImagenPrincipal(nombre, TamanoImagenEnum.Pequeno.ToEnum(tamano)) ), "gif");
        }

        [HttpGet]
        public FileResult ImagenId(int id, string tamano)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return File(Server.MapPath(contenidoNegocio.ObtenerRutaImagenPrincipal(id, TamanoImagenEnum.Grande.ToEnum(tamano))), "gif");
        }

        

        //[HttpGet]
        //public string Comprar()
        //{
        //    List<Contenido> lista = new List<Contenido>();
        //    lista.Add(new Contenido() { Id = 1, Nombres = "A1", Descripcion = "D1" });
        //    lista.Add(new Contenido() { Id = 2, Nombres = "A2", Descripcion = "D2" });
        //    lista.Add(new Contenido() { Id = 3, Nombres = "A3", Descripcion = "D3" });

        //    return new JavaScriptSerializer().Serialize(lista.ToArray()); 
        //}





    }



}
