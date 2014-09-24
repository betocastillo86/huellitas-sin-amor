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
        public List<ContenidoBaseModel> Get(int idContenido, int idTipoContenido)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.ObtenerContenidosRelacionados(idContenido, (TipoRelacionEnum)idTipoContenido)
                .Select(Mapper.Map<Contenido, ContenidoBaseModel>)
                .ToList();
        }

        [HttpPost]
        public bool Post(ContenidoRelacionado modelo)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.AgregarContenidoRelacionado(modelo);
        }

        [HttpDelete]
        public bool Delete(ContenidoRelacionado modelo)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            modelo = contenidoNegocio.ObtenerContenidoRelacionado(modelo.ContenidoId, modelo.ContenidoHijoId, modelo.ContenidoRelacionadoId);
            return contenidoNegocio.EliminarContenidoRelacionado(modelo);
        }

    }
}
