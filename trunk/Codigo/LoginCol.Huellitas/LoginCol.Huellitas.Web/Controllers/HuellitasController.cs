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

            ContenidoNegocio nContenido = new ContenidoNegocio();
            modelo.Fundaciones = nContenido.ObtenerPorTipoPadre(TipoContenidoEnum.Fundacion).Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
            
            modelo.RecomendadoPara = nCampo.Obtener(ParametrizacionNegocio.CampoRecomendadoParaId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            return View(modelo);
        }


        [HttpGet]
        public ActionResult QuieroAdoptar(int id)
        {
            FormularioAdopcionModel formularioModelo = new FormularioAdopcionModel();
            DatoTablaBasicaNegocio nDatoTablaBasica = new DatoTablaBasicaNegocio();

            formularioModelo.ListaEstadoCivil = nDatoTablaBasica.ObtenerPorIdTabla(TablasBasicasEnum.EstadoCivil);

            //Cargamos el contenido en el modelo
            ContenidoNegocio nContenido = new ContenidoNegocio();
            formularioModelo.Contenido = Mapper.Map<Contenido, ContenidoModel>(nContenido.Obtener(id));

            ContenidoRelacionado hogarDePaso = nContenido.ObtenerContenidosRelacionados(id, TipoRelacionEnum.Fundacion, true).FirstOrDefault();

            if (hogarDePaso != null)
                formularioModelo.HogarDePaso = Mapper.Map<Contenido, ContenidoListadoModel>(hogarDePaso.ContenidoHijo);


            return View(formularioModelo);
        }


        [HttpPost]
        public ActionResult QuieroAdoptar(int id, FormularioAdopcionModel modelo)
        {
            
            if (this.ModelState.IsValid)
            {
                FormularioAdopcionNegocio formularioAdopcionNegocio = new FormularioAdopcionNegocio();
                FormularioAdopcion formularioDB = Mapper.Map<FormularioAdopcionModel, FormularioAdopcion>(modelo);
                formularioDB.ContenidoId = id;

                formularioAdopcionNegocio.Crear(formularioDB);

            }

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
