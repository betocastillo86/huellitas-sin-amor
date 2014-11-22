using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AdminUsuarioRelacionadoController : ApiController
    {
        [HttpGet]
        public List<UsuarioRelacionadoModel> Get(int idContenido, int idTipoContenido)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.ObtenerUsuariosRelacionados(idContenido, idTipoContenido)
                .Select(Mapper.Map<UsuarioContenido, UsuarioRelacionadoModel>)
                .ToList();
        }

        [HttpPost]
        public ResultadoOperacion Post(UsuarioContenido modelo)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.AgregarUsuarioRelacionado(modelo);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.EliminarUsuarioRelacionado(id);
        }
    }
}
