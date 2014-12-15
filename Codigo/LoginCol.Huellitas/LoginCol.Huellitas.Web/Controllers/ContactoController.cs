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
    public class ContactoController : ApiController
    {
        [HttpPost]
        public ResultadoOperacion Post(ContactoModel modelo)
        {
            if (ModelState.IsValid)
            {
                bool exito = ContactoNegocio.EnviarContacto(modelo.Nombres, modelo.Comentario, modelo.CorreoElectronico, modelo.Telefono);
                return new ResultadoOperacion(exito);
            }
            else
            {
                return new ResultadoOperacion() { OperacionExitosa = false, MensajeError = "Los datos no son validos" };
            }
        }
    }
}
