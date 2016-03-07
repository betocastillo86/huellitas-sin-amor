using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Utilidades;
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
            var modelo = new ListarHuellitasModel("TituloHuellitas");
            modelo.Colores = nCampo.Obtener(ParametrizacionNegocio.CampoColorId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            modelo.Tamanos = nCampo.Obtener(ParametrizacionNegocio.CampoTamanoId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            modelo.Generos = nCampo.Obtener(ParametrizacionNegocio.CampoGeneroId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();

            ContenidoNegocio nContenido = new ContenidoNegocio();
            modelo.Fundaciones = nContenido.ObtenerPorTipoPadre(TipoContenidoEnum.Fundacion).Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
            
            modelo.RecomendadoPara = nCampo.Obtener(ParametrizacionNegocio.CampoRecomendadoParaId).Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            return View(modelo);
        }

        #region QuieroAdoptar
        [HttpGet]
        public ActionResult QuieroAdoptar(int id)
        {
            var modelo = new FormularioAdopcionModel();
            
            CargarModeloFormulario(modelo, id);

            //Si no está activo lo envia al home
            if (!modelo.Contenido.Activo)
                return RedirectToAction("Index", "Home");

            return View(modelo);
        }


        [HttpPost]
        public ActionResult QuieroAdoptar(int id, FormularioAdopcionModel modelo)
        {
            ModelState.Remove("Usuario.Telefono");
            ModelState.Remove("Usuario.Clave");
            ModelState.Remove("Usuario.Apellidos");
            if (ModelState.IsValid)
            {
                var respuestas = new List<RespuestaAdopcion>();

                foreach (var pregunta in Request.Form.AllKeys.Where(k => k.StartsWith("pregunta")))
                {
                    respuestas.Add(new RespuestaAdopcion()
                    {
                        PreguntaId = Convert.ToInt32(pregunta.Replace("pregunta", string.Empty)),
                        Respuesta = Request.Form[pregunta]
                    });
                }

                var formularioAdopcionNegocio = new FormularioAdopcionNegocio();

                //Crea el formulario de adopción
                var formulario = Mapper.Map<FormularioAdopcionModel, FormularioAdopcion>(modelo);
                formulario.ContenidoId = id;
                formulario.Respuestas = respuestas;
                formulario.Usuario.Apellidos = ".";

                var respuesta = formularioAdopcionNegocio.Crear(formulario);

                if (respuesta.OperacionExitosa)
                {
                    modelo.Id = respuesta.Id;
                }
                else
                {
                    modelo.OperacionExitosa = false;
                    modelo.MensajeError = respuesta.MensajeError;
                }

                //Cargamos el contenido en el modelo
                ContenidoNegocio nContenido = new ContenidoNegocio();
                modelo.Contenido = Mapper.Map<Contenido, ContenidoModel>(nContenido.Obtener(id));
            }
            else
            {
                //Vuelve a cargar el modelo
                CargarModeloFormulario(modelo, id);
                modelo.Id = 0;
            }

            return View(modelo);
        }


        public FormularioAdopcionModel CargarModeloFormulario(FormularioAdopcionModel modelo, int idContenido)
        {
            DatoTablaBasicaNegocio nDatoTablaBasica = new DatoTablaBasicaNegocio();

            modelo.ListaOcupaciones = nDatoTablaBasica.ObtenerPorIdTabla(TablasBasicasEnum.Ocupacion);
            modelo.Preguntas = nDatoTablaBasica.ObtenerPorIdTabla(TablasBasicasEnum.PreguntaAdopcion);

            //Cargamos el contenido en el modelo
            var nContenido = new ContenidoNegocio();

            modelo.Contenido = Mapper.Map<Contenido, ContenidoModel>(nContenido.Obtener(idContenido));

            modelo.CargarTitulo("TituloAdopcion", modelo.Contenido.Nombre);

            ContenidoRelacionado hogarDePaso = nContenido.ObtenerContenidosRelacionados(idContenido, TipoRelacionEnum.Fundacion, true).FirstOrDefault();

            if (hogarDePaso != null)
                modelo.HogarDePaso = Mapper.Map<Contenido, ContenidoListadoModel>(hogarDePaso.ContenidoHijo);

            modelo.Usuario = new UsuarioModel();

            return modelo;
        }

        #endregion


        #region Detalle
        [HttpGet]
        [SumarVisita]
        public ActionResult Detalle(int id)
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            DetalleHuellitaModel modelo = Mapper.Map<Contenido, DetalleHuellitaModel>(nContenido.Obtener(id));
            modelo.CargarTitulo("TituloDetalleHuellita", modelo.Nombre);

            ContenidoRelacionado hogarDePaso = nContenido.ObtenerContenidosRelacionados(id, TipoRelacionEnum.Fundacion, true).FirstOrDefault();

            HuellitaNegocio nHuellitas = new HuellitaNegocio();
            UsuarioContenido padrino = nHuellitas.ObtenerAdoptanteOPadrino(id);

            if (padrino != null)
            {
                modelo.AdoptantePadrino = Mapper.Map<Usuario, UsuarioBaseModel>(padrino.Usuario);
                modelo.TipoAdoptante = (TipoRelacionUsuariosEnum)padrino.TipoRelacionId;
            }

            if (hogarDePaso != null)
            {
                modelo.HogarDePaso = Mapper.Map<Contenido, ContenidoListadoModel>(hogarDePaso.ContenidoHijo);
                //modelo.HogarDePaso.Email = hogarDePaso.ContenidoHijo.Email;
            }

            modelo.ImagenCompartir = string.Format("/img/{0}/big", modelo.ContenidoId);
            modelo.Id = id;

            return View(modelo);
        }

        [ChildActionOnly]
        public ActionResult Destacados()
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            var contenidos = nContenido.ObtenerDestacadosPorTipoPadre(TipoContenidoEnum.Animal)
                .OrderBy(c => Guid.NewGuid())
                .Take(2)
                .Select(Mapper.Map<Contenido, ContenidoListadoModel>)
                .ToList();

            return PartialView("_BannerDestacados", contenidos);
        }


        [ChildActionOnly]
        public ActionResult ContenidosRelacionados(ContenidoModel contenido, string titulo, TipoRelacionEnum tipoRelacion, bool verTodos = false, string linkVerTodos = null)
        {
            var nContenido = new ContenidoNegocio();
            var model = new VistaContenidoRelacionadoModel();
            model.VerTodos = verTodos;
            model.LinkVerTodos = linkVerTodos;
            model.Contenidos = nContenido.ObtenerContenidosRelacionados(contenido.Id, Convert.ToInt32(tipoRelacion))
            .Select(Mapper.Map<ContenidoRelacionado, ContenidoRelacionadoModel>)
            .OrderBy(c => Guid.NewGuid())
            .Take(10)
            .ToList();
            model.Titulo = titulo;

            return PartialView("_ContenidosRelacionados", model);
        }

        #endregion


        #region Dar en adopción
        public ActionResult CrearHuellita()
        {
            return View(new CrearHuellitaModel());
        }
        #endregion

    }
}
