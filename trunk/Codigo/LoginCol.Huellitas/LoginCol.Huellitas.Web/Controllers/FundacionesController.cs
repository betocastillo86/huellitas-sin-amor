using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class FundacionesController : Controller
    {
        //
        // GET: /Fundaciones/

        public ActionResult Index()
        {
            ListarFundacionesModel modelo = new ListarFundacionesModel();
            
            ZonaGeograficaNegocio nZonas = new ZonaGeograficaNegocio();
            modelo.ZonasPadre = nZonas.ObtenerZonasGeograficasPorPadre(ParametrizacionNegocio.ZonaGeograficaPorDefecto)
                .Select(Mapper.Map<ZonaGeografica, ZonaGeograficalModel>)
                .ToList();
            
            return View(modelo);
        }

    }
}
