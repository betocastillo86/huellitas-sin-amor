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
    public class TablasBasicasController : ApiController
    {
        /// <summary>
        /// Trae el listado de datos tabla basica por id de tabla basica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DatoTablaBasica> Get([FromUri]int id)
        {
            var nTablasBasicas = new DatoTablaBasicaNegocio();
            return nTablasBasicas.ObtenerPorIdTabla((TablasBasicasEnum)Enum.Parse(typeof(TablasBasicasEnum), id.ToString()));
        }
    }
}
