using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Infraestructure;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AdminImagenesController : ApiController
    {
        [HttpGet]
        public List<ContenidoRelacionadoModel> Get(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.ObtenerImagenes(id).Select(Mapper.Map<ContenidoRelacionado, ContenidoRelacionadoModel>).ToList();
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return contenidoNegocio.Eliminar(id);
        }


        [HttpPost]
        public ContenidoModel Post(int idContenido, ContenidoModel modelo)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            modelo.ContenidoId = contenidoNegocio.AgregarImagen(idContenido, Mapper.Map<ContenidoModel, Contenido>(modelo), SessionModel.Usuario.UsuarioId).Id;
            return modelo;
        }
        
        /// <summary>
        /// Encargada de guardar las imagenes de los contenidos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultadoOperacion>  Post(int id)
        {

            
            ResultadoOperacion respuesta = new ResultadoOperacion();

            if (!Request.Content.IsMimeMultipartContent())
            {
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = "No contiene archivos para ser cargados";
            }
            else
            {

                try
                {
                    var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
                    System.Web.Mvc.FormCollection formData = provider.FormData;
                    IList<HttpContent> fileContentList = provider.Files;
                    
                    var fileDataList = provider.GetFiles();
                    var files = await fileDataList;

                    ContenidoNegocio contenidoNegocio = new ContenidoNegocio(System.Web.HttpContext.Current.Server.MapPath("~"));
                    respuesta = contenidoNegocio.GuardarImagen(id, files.FirstOrDefault().Data);
                }
                catch (Exception e)
                {
                    LogErrores.RegistrarError(e);
                    respuesta.OperacionExitosa = false;
                    respuesta.MensajeError = "No fue posible guardar los archivos";
                }
                
            }

            return respuesta;
        }
    }

    


    
}
