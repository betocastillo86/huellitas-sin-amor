using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Negocio.Directorios;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Infraestructure;
using LoginCol.Huellitas.Web.Models;
using LoginCol.Huellitas.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace LoginCol.Huellitas.Web.Controllers
{
    
    public class AdministracionController : Controller
    {
        //
        // GET: /Admin/
        [HttpGet]
        [Authorize]
        public ActionResult Submodulos(string queryValues)
        {
            string vista = "Index";
            string[] partesUrl = queryValues.ToLower().Split(new char[] { '/' });
            object modelo = null;

            var nTipoContenido = new TipoContenidoNegocio();

            switch (string.Format("{0}/{1}", partesUrl[0], partesUrl[1]))
            {
                case "animales/listar":
                case "animales/editar":
                case "animales/crear":
                    vista = "Contenido/Index.cshtml";
                    ListarContenidoModel modeloAnimales = new ListarContenidoModel() { PrefijoAcciones = "animales", Titulo = "Administración de Animales" };
                    modeloAnimales.Contenido.Departamentos = new ZonaGeograficaNegocio().ObtenerZonasGeograficasPorPadre(Convert.ToInt32(ConfigurationManager.AppSettings["IdZonaGeograficaDefecto"]));
                    modeloAnimales.Contenido.TiposDeContenido = new TipoContenidoNegocio().ObtenerPorPadre((int)TipoContenidoEnum.Animal);
                    modeloAnimales.Contenido.TiposRelacionContenido = nTipoContenido.ObtenerTiposDeRelacionContenido((int)TipoContenidoEnum.Animal);
                    modeloAnimales.Contenido.TiposRelacionUsuario = nTipoContenido.ObtenerTiposDeRelacionUsuarios((int)TipoContenidoEnum.Animal);
                    modeloAnimales.Contenido.Usuarios = new UsuarioNegocio().ObtenerUsuariosActivos(false).Select(AutoMapper.Mapper.Map<Usuario,UsuarioModel>).ToList(); 
                    modelo = modeloAnimales;
                    break;
                case "fundaciones/listar":
                case "fundaciones/editar":
                case "fundaciones/crear":
                    vista = "Contenido/Index.cshtml";
                    ListarContenidoModel modeloFundaciones = new ListarContenidoModel() { PrefijoAcciones = "fundaciones", Titulo = "Administración de Fundaciones" };
                    modeloFundaciones.Contenido.Departamentos = new ZonaGeograficaNegocio().ObtenerZonasGeograficasPorPadre(Convert.ToInt32(ConfigurationManager.AppSettings["IdZonaGeograficaDefecto"]));
                    modeloFundaciones.Contenido.TiposDeContenido = new TipoContenidoNegocio().ObtenerPorPadre((int)TipoContenidoEnum.Fundacion);
                    modeloFundaciones.Contenido.TiposRelacionContenido = new TipoContenidoNegocio().ObtenerTiposDeRelacionContenido((int)TipoContenidoEnum.Fundacion);
                    modeloFundaciones.Contenido.TiposRelacionUsuario = nTipoContenido.ObtenerTiposDeRelacionUsuarios((int)TipoContenidoEnum.Fundacion);
                    modeloFundaciones.Contenido.Usuarios = new UsuarioNegocio().ObtenerUsuariosActivos(false).Select(AutoMapper.Mapper.Map<Usuario, UsuarioModel>).ToList(); 
                    modelo = modeloFundaciones;
                    break;
                default:
                    modelo = new ListarContenidoModel();
                    break;
            }

            return View(string.Format("~/Views/Administracion/{0}", vista), modelo);
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Index(LoginModel modelo)
        {
            if (this.ModelState.IsValid)
            {
                Autenticacion objAutenticacion = new Autenticacion();
                if (objAutenticacion.AutenticarUsuario(modelo.Usuario, modelo.Clave, true))
                {
                    return Redirect("/admin/animales/listar");
                    //return RedirectToAction("Index", new { queryValues = "animales/listar" });
                }
                else
                {
                    modelo.Error = "Valide las credenciales de nuevo";
                }
            }

            return View(modelo);
        }
        #region Parametrizacion
        public ActionResult Parametrizacion()
        {
            return View(new ParametrizacionNegocio().Obtener());
        }
        #endregion

        #region UsuariosExternos

        public ActionResult UsuariosExternos()
        {
            var modelo = new ListarUsuariosExternosModel();

            //consulta todos los usuarios externos activos
            UsuarioNegocio nUsuario = new UsuarioNegocio();
            modelo.Usuarios = nUsuario.ObtenerUsuarios(null, false, null)
                .Select(Mapper.Map<Usuario, UsuarioModel>)
                .ToList();

            return View(modelo);
        }

        #endregion

        #region Formularios Adopciones

        Lazy<FormularioAdopcionNegocio> _nFormulario = new Lazy<FormularioAdopcionNegocio>();
        FormularioAdopcionNegocio nFormulario { get { return _nFormulario.Value; } }


        Lazy<AdopcionNegocio> _nAdopcion = new Lazy<AdopcionNegocio>();
        AdopcionNegocio nAdopcion { get { return _nAdopcion.Value; } }

        Lazy<ContenidoNegocio> _nContenido = new Lazy<ContenidoNegocio>();
        ContenidoNegocio nContenido { get { return _nContenido.Value; } }
        [Authorize]
        public ActionResult FormulariosListar()
        {

            var modelo = new ListarFormularioAdopcionModel();
            modelo.Formularios =  nFormulario.Obtener()
                .Select(Mapper.Map<FormularioAdopcion, FormularioAdopcionModel>)
                .OrderByDescending(f => f.FechaCreacion)
                .ToList();
            return View(modelo);
        }
        [Authorize]
        public ActionResult FormulariosDetalle(int id)
        {
            var formulario = nFormulario.Obtener(id);
            var modelo = Mapper.Map<FormularioAdopcion, FormularioAdopcionModel>(formulario);
            
            return View(modelo);
        }

        #endregion

        #region Adopciones
        [Authorize]
        public ActionResult AdopcionesDetalle(int? id) 
        {
            
            var modelo = new AdopcionModel();

            //Si no viene con Id es un formulario que se va convertir en adopción
            if(!id.HasValue)
            {
                //Valida que el id del formulario sea valido
                int idFormulario = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["fId"]) && int.TryParse(Request.QueryString["fId"], out idFormulario))
                {
                    modelo.FormularioId = idFormulario;

                    //Busca si el formulario existe o no
                    var formulario = nFormulario.Obtener(idFormulario);
                    if (formulario != null)
                    {
                        modelo.AdoptanteNombres = formulario.Usuario.Nombres;
                        modelo.AdoptanteApellidos = formulario.Usuario.Apellidos;
                        modelo.ContenidoId = formulario.ContenidoId;
                        modelo.FechaAdopcion = DateTime.Now;

                        var camposFiltro = new List<FiltroContenido>();
                        camposFiltro.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoEstadoAnimalId, Valor = ParametrizacionNegocio.ValorCampoEstadoAnimalId, TipoFiltro = TipoFiltroContenidoEnum.Igual });

                        modelo.Contenidos = nContenido.ObtenerAnimalesAdoptados()
                            .Select(Mapper.Map<Contenido, ContenidoBaseModel>)
                            .OrderBy(c => c.Nombre)
                            .ToList();

                    }
                    else
                    {
                        return RedirectToAction("FormulariosListar");
                    }
                }
                else
                    return RedirectToAction("FormulariosListar");

            }
            else
            {
                //Si tiene valor  realiza el tratamiento de la adopción existente
                //modelo.AdopcionId = id.Value;
                modelo = Mapper.Map<Adopcion, AdopcionModel>(nAdopcion.Obtener(id.Value));
            }

            return View(modelo);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AdopcionesDetalle(int? id, AdopcionModel modelo)
        {
            if (ModelState.IsValid)
            {
                if (!id.HasValue)
                {
                    var adopcion = Mapper.Map<AdopcionModel, Adopcion>(modelo);
                    var formulario = nFormulario.Obtener(modelo.FormularioId);

                    if (formulario != null)
                    {
                        adopcion.AdoptanteId = formulario.UsuarioId;
                        adopcion.FormularioId = formulario.FormularioAdopcionId;
                        
                        if (nAdopcion.Crear(adopcion))
                        {
                            return Redirect("AdopcionesDetalle/" + adopcion.AdopcionId);
                            //return RedirectToAction("AdopcionesDetalle", new { id = adopcion.AdopcionId });
                        }
                    }
                }
            }

            modelo.Contenidos = nContenido.ObtenerAnimalesAdoptados()
                               .Select(Mapper.Map<Contenido, ContenidoBaseModel>)
                               .OrderBy(c => c.Nombre)
                               .ToList();

            return View(modelo);
        }

        public ActionResult AdopcionesListar()
        {
            var model = new ListarAdopcionModel();
            model.Adopciones = nAdopcion.Obtener()
                .Select(Mapper.Map<Adopcion, AdopcionModel>)
                .ToList();
            return View(model);
        }


        #endregion  

        #region Imagenes
        [Authorize]
        [HttpPost]
        public ActionResult RelacionarImagen(int id)
        {
            ResultadoOperacion respuesta = new ResultadoOperacion();

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        ContenidoNegocio contenidoNegocio = new ContenidoNegocio(new RutaFisicaWeb());

                        var contenidoPadre = contenidoNegocio.Obtener(id);
                        var contenidoHijo = new Contenido() { Nombre = contenidoPadre.Nombre, Descripcion = contenidoPadre.Descripcion, DescripcionCorta = contenidoPadre.Nombre };
                        contenidoHijo.ContenidoId = contenidoNegocio.AgregarImagen(id, contenidoHijo, SessionModel.Usuario.UsuarioId).Id;
                        respuesta = contenidoNegocio.GuardarImagen(contenidoHijo.ContenidoId, Utilidades.Archivos.ConvertirStreamABytes(file.InputStream));
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = ex.Message;
            }

            return Json(respuesta);
        }

        #endregion

        public ActionResult Salir()
        {
            Autenticacion.CerrarSesion();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public JsonResult OpcionesMenu()
        {
            List<OpcionMenu> opcionesMenu = new List<OpcionMenu>();
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 1, Nombre = "Animales", Vinculo = "/admin/animales/listar" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 2, Nombre = "Fundaciones", Vinculo = "/admin/fundaciones/listar" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 3, Nombre = "Parametrizacion", Vinculo = "/admin/parametrizacion" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 4, Nombre = "Usuarios Externos", Vinculo = "/admin/usuariosexternos" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 4, Nombre = "Formularios Adopción", Vinculo = "/admin/formularioslistar" });
            opcionesMenu.Add(new OpcionMenu() { IdMenu = 4, Nombre = "Adopciones", Vinculo = "/admin/adopcioneslistar" });
            return Json(opcionesMenu, JsonRequestBehavior.AllowGet);
        }


    }
}
