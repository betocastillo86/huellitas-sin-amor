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
    public class AdminSeguimientoController : ApiController
    {
        [HttpGet]
        public List<SeguimientoAdopcionModel> ObtenerSeguimientosPorAdopcion(int id)
        {
            var nAdopciones = new AdopcionNegocio();
            return nAdopciones.ObtenerSeguimientosPorAdopcion(id)
                .Select(Mapper.Map<SeguimientoAdopcion, SeguimientoAdopcionModel>)
                .ToList();
        }
    }
}
