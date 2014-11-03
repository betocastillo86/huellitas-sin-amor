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
    public class ComentariosController : ApiController
    {
        [HttpGet]
        public List<ComentarioModel> Get(int idContenido, [FromUri] int? pagina)
        {
            ComentarioNegocio nComentarios = new ComentarioNegocio();
            int resultadosPorPagina = ParametrizacionNegocio.ComentariosPorPagina;
            return nComentarios.ObtenerComentarios(idContenido)
                .Select(Mapper.Map<Comentario, ComentarioModel>)
                .Skip(resultadosPorPagina * pagina ?? 0)
                .Take(resultadosPorPagina)
                .ToList();
        }

        [HttpPost]
        public ComentarioModel Post(ComentarioModel modelo)
        {
            ComentarioNegocio nComentario = new ComentarioNegocio();
            Comentario comentario = Mapper.Map<ComentarioModel, Comentario>(modelo);
            //modelo.ComentarioId = nComentario.AgregarComentario(comentario);
            modelo = Mapper.Map<Comentario, ComentarioModel>(nComentario.AgregarComentario(comentario));
            return modelo;
        }
    }
}
