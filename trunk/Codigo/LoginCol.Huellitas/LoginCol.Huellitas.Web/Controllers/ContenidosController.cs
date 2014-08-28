

using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using LoginCol.Huellitas.Web.Models;
namespace LoginCol.Huellitas.Web.Controllers
{
    public class ContenidosController : ApiController
    {
        ////
        //// GET: /Contenidos/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public HttpResponseMessage Get()
        {
            //return Request.CreateResponse(HttpStatusCode.OK, new ContenidosNegocio().ObtenerPorTipo(TipoContenidoEnum.Animal).Select(Mapper.Map<Contenido, ContenidoModel>).ToList());
            return null;
        }

    }
}
