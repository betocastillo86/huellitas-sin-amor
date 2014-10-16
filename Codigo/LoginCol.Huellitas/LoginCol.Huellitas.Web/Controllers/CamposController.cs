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
    public class CamposController : ApiController
    {
        [HttpGet]
        public CampoModel Get(int id)
        {
            CampoNegocio nCampo = new CampoNegocio();
            Campo campo = nCampo.Obtener(id);
            CampoModel campoModel = Mapper.Map<Campo, CampoModel>(campo);
            return campoModel;
        }
    }
}
