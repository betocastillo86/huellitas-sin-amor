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
    public class AdminContenidoRelacionadoController : ApiController
    {
        [HttpGet]
        public List<ContenidoRelacionadoModel> Get(int idContenido, int idTipoContenido)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.ObtenerContenidosRelacionados(idContenido, (TipoRelacionEnum)idTipoContenido)
                .Select(Mapper.Map<ContenidoRelacionado, ContenidoRelacionadoModel>)
                .ToList();
        }

        [HttpPost]
        public bool Post(ContenidoRelacionado modelo)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.AgregarContenidoRelacionado(modelo);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.EliminarContenidoRelacionado(id);
        }

    }
}
