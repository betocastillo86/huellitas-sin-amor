using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Infraestructure;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class HuellitasController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CampoNegocio nCampo = new CampoNegocio();
            ListarHuellitasModel modelo = new ListarHuellitasModel();
            modelo.Colores = nCampo.Obtener(ParametrizacionNegocio.CampoColorId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            modelo.Tamanos = nCampo.Obtener(ParametrizacionNegocio.CampoTamanoId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            modelo.Generos = nCampo.Obtener(ParametrizacionNegocio.CampoGeneroId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            modelo.RecomendadoPara = nCampo.Obtener(ParametrizacionNegocio.CampoRecomendadoParaId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            return View(modelo);
        }

        [HttpGet]
        [SumarVisita]
        public ActionResult Detalle(int id)
        {   
            ContenidoNegocio nContenido = new ContenidoNegocio();
            DetalleHuellitaModel modelo = Mapper.Map<Contenido, DetalleHuellitaModel>(nContenido.Obtener(id));

            ContenidoRelacionado hogarDePaso = nContenido.ObtenerContenidosRelacionados(id, TipoRelacionEnum.Fundacion, true).FirstOrDefault();

            HuellitaNegocio nHuellitas = new HuellitaNegocio();
            UsuarioContenido padrino = nHuellitas.ObtenerAdoptanteOPadrino(id);

            if (padrino != null)
            {
                modelo.AdoptantePadrino = Mapper.Map<Usuario, UsuarioBaseModel>(padrino.Usuario);
                modelo.TipoAdoptante = (TipoRelacionUsuariosEnum) padrino.TipoRelacionId;
            }

            if (hogarDePaso != null)
            {
                modelo.HogarDePaso = Mapper.Map<Contenido, ContenidoListadoModel>(hogarDePaso.ContenidoHijo);
                modelo.HogarDePaso.CorreoElectronico = hogarDePaso.ContenidoHijo.Email;
            }

            return View(modelo);
        }


    }
}
