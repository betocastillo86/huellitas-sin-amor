

using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using LoginCol.Huellitas.Web.Models;
using System.Collections.Generic;
namespace LoginCol.Huellitas.Web.Controllers
{
    public class ContenidosController : ApiController
    {
        
        [HttpGet]
        public List<ContenidoBaseModel> Get()
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            return nContenido.ObtenerPorTipo(4).Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
        }


        [HttpGet]
        public List<ContenidoBaseModel> Perros()
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            return nContenido.ObtenerPorTipo(4).Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
        }

    }
}
