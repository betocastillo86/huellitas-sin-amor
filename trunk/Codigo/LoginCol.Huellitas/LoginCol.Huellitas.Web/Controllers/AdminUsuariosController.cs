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
    public class AdminUsuariosController : ApiController
    {
        [HttpGet]
        public List<UsuarioModel> Get([FromUri] FiltroApiUsuarios filtro)
        {
            var nUsuario = new UsuarioNegocio();

            return nUsuario.ObtenerUsuarios(filtro.activo, filtro.admin, null)
                .Select(Mapper.Map<Usuario,UsuarioModel>)
                .ToList();
        }

        [HttpPost]
        public ResultadoOperacion Post(UsuarioModel modelo)
        {
            var nUsuario = new UsuarioNegocio();
            var usuario = Mapper.Map<UsuarioModel, Usuario>(modelo);
            usuario.Activo = true;
            return nUsuario.Crear(usuario);
        }
        
    }

    public class FiltroApiUsuarios
    {
        public bool? admin { get; set; }
        public bool? activo { get; set; }
    }
}
