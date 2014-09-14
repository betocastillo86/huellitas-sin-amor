using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AdminImagenesController : ApiController
    {
        [HttpGet]
        public List<ContenidoBaseModel> Get(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.ObtenerImagenes(id).Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
        }
    }
}
