using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class GeneralesController : Controller
    {
        [HttpGet]
        public JsonResult ZonasGeograficas(int id)
        {
            ZonaGeograficaNegocio zonasNegocio = new ZonaGeograficaNegocio();
            return Json(zonasNegocio.ObtenerZonasGeograficasPorPadre(id).Select(AutoMapper.Mapper.Map<ZonaGeografica, ZonaGeograficalModel>).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TipoContenido(int id)
        {
            TipoContenidoNegocio tipoNegocio = new TipoContenidoNegocio();
            return Json(AutoMapper.Mapper.Map<TipoContenido, TipoContenidoModel>(tipoNegocio.Obtener(id)), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult TiposContenidos()
        {
            TipoContenidoNegocio tipoNegocio = new TipoContenidoNegocio();
            List<TipoContenidoBaseModel> listado = tipoNegocio.Obtener().Select(AutoMapper.Mapper.Map<TipoContenido, TipoContenidoBaseModel>).ToList();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Retorna el listado de tipos de relacion que se pueden encontrar con un tipo de contenido
        /// </summary>
        /// <param name="id">Id del tipo de Contenido que se desea filtrar</param>
        /// <returns></returns>
        public JsonResult TiposRelacionesPorTipoContenido(int id)
        {
            TipoContenidoNegocio tipoNegocio = new TipoContenidoNegocio();
            List<TipoRelacionContenidoModel> listado = tipoNegocio.ObtenerTiposDeRelacionContenido(id).Select(AutoMapper.Mapper.Map<TipoRelacionContenido, TipoRelacionContenidoModel>).ToList();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }


    }
}
