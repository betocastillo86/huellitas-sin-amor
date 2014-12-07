using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class ParametrizacionController : ApiController
    {
        [HttpPut]
        public bool Put(Parametrizacion modelo)
        {
            var nParametrizacion = new ParametrizacionNegocio();
            return nParametrizacion.Actualizar(modelo);
        }
    }
}
