using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Negocio.Directorios;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Infraestructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class ArchivosController : ApiController
    {
       
        
        [HttpPost]
        public async Task<ResultadoOperacion> Post()
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

                    if (files.FirstOrDefault().Size <= ParametrizacionNegocio.TamanoMaximoCargaArchivos)
                    {
                        var nArchivosTemporales = new ArchivosTemporalesNegocio();
                        respuesta = nArchivosTemporales.GuardarArchivoTemporal(files.FirstOrDefault().Data, Path.GetExtension(files.FirstOrDefault().FileName));
                    }
                    else
                    {
                        respuesta.OperacionExitosa = false;
                        respuesta.MensajeError = "El archivo sobrepasa el tamaño valido";
                    }

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
