using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Models;
using LoginCol.Huellitas.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    
    public class AdminAdopcionesController : ApiController
    {

        
        /// <summary>
        /// Actualiza los datos de un formulario de adopción. Inicialmente la funcionalidad solo aplica apra envio de correos
        /// </summary>
        /// <param name="modelo">Modelo de formulario de adopción con los datos a atualizar</param>
        /// <param name="enviarCorreo">variable por URL que valida si se debe enviar el correo o no</param>
        /// <returns>Resultado de operación con toda la información</returns>
        [HttpPut]
        public ResultadoOperacion Put(FormularioAdopcionModelBase modelo, [FromUri] bool enviarCorreo = false)
        {
            ResultadoOperacion respuesta = new ResultadoOperacion();
            
            var nAdopciones = new FormularioAdopcionNegocio();
            
            //Por ahora solo funciona para envío de correos y se hace la actualización interna
            if(enviarCorreo)
            {
                respuesta = nAdopciones.EnviarRespuestaAdopcion(modelo.FormularioAdopcionId,
                    modelo.Estado, 
                    modelo.Observaciones, 
                    modelo.InformacionAdicionalCorreo);
            }

            return respuesta;
        }
    }
}
