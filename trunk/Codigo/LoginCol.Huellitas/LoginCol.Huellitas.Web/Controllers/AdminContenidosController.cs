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
    public class AdminContenidosController : ApiController
    {
        [HttpGet]
        public List<ContenidoBaseModel> Get(int idTipoContenido, bool esPadre)
        {
            List<Contenido> lista = new ContenidoNegocio()
                .ObtenerPorTipo(idTipoContenido, esPadre);
            return lista.Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
        }

        [HttpGet]
        public ContenidoModel Get(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            ContenidoModel modelo = Mapper.Map<Contenido, ContenidoModel>(contenidoNegocio.Obtener(id));
            return modelo;
        }

        [HttpPut]

        public ResultadoOperacion Put(int id, ContenidoModel modelo)
        {

            Contenido contenido = Mapper.Map<ContenidoModel, Contenido>(modelo);
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            //actualiza los campos con el id del contenido
            contenido.Campos.Each(_ => _.ContenidoId = id);

            ResultadoOperacion respuesta = contenidoNegocio.Actualizar(contenido);
            return respuesta;
        }

        [HttpPost]
        public ResultadoOperacion Post(ContenidoModel modelo)
        {
            modelo.Campos.RemoveAll(c => string.IsNullOrEmpty(c.Valor));
            Contenido contenido = Mapper.Map<ContenidoModel, Contenido>(modelo);



            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            ResultadoOperacion respuesta = contenidoNegocio.Crear(contenido, SessionModel.Usuario.UsuarioId);
            return respuesta;
        }
    }
}
