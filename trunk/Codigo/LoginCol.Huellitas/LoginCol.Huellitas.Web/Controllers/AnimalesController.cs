

using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using LoginCol.Huellitas.Web.Models;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AnimalesController : ApiController
    {

        [HttpGet]
        public List<ContenidoModel> Get()
        {
            return new ContenidosNegocio().ObtenerPorTipo(TipoContenidoEnum.Animal).Select(Mapper.Map<Contenido, ContenidoModel>).ToList();
            //return new ContenidosNegocio().ObtenerPorTipo(TipoContenidoEnum.Animal);
        }
    }
}
