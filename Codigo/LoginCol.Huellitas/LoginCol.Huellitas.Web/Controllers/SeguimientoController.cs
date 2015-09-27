using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginCol.Huellitas.Negocio.Extensions;
using LoginCol.Huellitas.Web.Infraestructure;

namespace LoginCol.Huellitas.Web.Controllers
{

    public class SeguimientoController : ApiController
    {
        private ContenidoNegocio _nContenido;
        private AdopcionNegocio _nAdopcion;
        private ArchivosTemporalesNegocio _nArchivosTemporales;
        
        public SeguimientoController()
        {
            _nContenido = new ContenidoNegocio();
            _nAdopcion = new AdopcionNegocio();
        }
        
        [HttpPost]
        public ResultadoOperacion Insert(SeguimientoModel model)
        {
            var respuesta = new ResultadoOperacion(){ OperacionExitosa  = false};
            if (ModelState.IsValid)
            {
                var adopcion = _nAdopcion.Obtener(model.AdopcionId);

                if (adopcion == null || !adopcion.ObtenerLlaveDeConfirmacionSeguimientoAdopcion().Equals(model.Key))
                {
                    respuesta.MensajeError = "No puedes guardar este formulario";
                }
                else
                {
                    _nAdopcion.CrearSeguimiento(model.AdopcionId, model.Observaciones, model.Imagen1, model.Imagen2);
                    respuesta.OperacionExitosa = true;
                }
            }
            else{
                respuesta.MensajeError = ModelState.ObtenerTodosLosErroresDeModelState();
            }

            return respuesta;
        }

    }
}
