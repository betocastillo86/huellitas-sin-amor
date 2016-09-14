using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Utilidades;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers.api
{
    public class HuellitasApiController : ApiController
    {

        private Lazy<ContenidoNegocio> _nContenido { get; set; }
        private Lazy<UsuarioNegocio> _nUsuario { get; set; }

        public HuellitasApiController()
        {
            _nContenido = new Lazy<ContenidoNegocio>();
            _nUsuario = new Lazy<UsuarioNegocio>();
        }

        private ContenidoNegocio nContenido { get { return _nContenido.Value; } }

        [HttpPost]
        public ResultadoOperacion Post(CrearHuellitaModel modelo)
        {

            ResultadoOperacion respuesta = new ResultadoOperacion();

            if (ModelState.IsValid)
            {
                try
                {
                    var contenido = Mapper.Map<CrearHuellitaModel, Contenido>(modelo);
                    contenido.DescripcionCorta = modelo.Nombre;
                    contenido.Activo = false;
                    contenido.TipoContenidoId = Convert.ToInt32(modelo.Tipo);
                    contenido.Imagen = null;

                    //Crea el contenido
                    respuesta = nContenido.Crear(contenido, ParametrizacionNegocio.UsuarioPorDefecto, modelo.Imagen.First());

                    if (respuesta.OperacionExitosa)
                    {
                        //crea el usaurio
                        var usuario = _nUsuario.Value.CrearUsuarioDesdeCorreo(modelo.ContactoCorreo, modelo.ContactoNombre, modelo.ContactoTelefono);
                        //lo relaciona con el contenido
                        _nContenido.Value.AgregarUsuarioRelacionado(new UsuarioContenido() { UsuarioId = usuario.UsuarioId, ContenidoId = contenido.ContenidoId, TipoRelacionId = Convert.ToInt32(TipoRelacionUsuariosEnum.Padrino) });

                        //Actualiza todas las imagenes del contenido
                        if (modelo.Imagen.Count > 1)
                        {
                            foreach (var imagen in modelo.Imagen.Skip(1))
                            {
                                nContenido.AgregarImagen(respuesta.Id, new Contenido() { Nombre = contenido.Nombre, Descripcion = contenido.Nombre }, ParametrizacionNegocio.UsuarioPorDefecto, imagen);
                            }
                        }
                    }


                }
                catch (Exception e)
                {
                    LogErrores.RegistrarError(e);
                    //respuesta.OperacionExitosa = false;
                    //respuesta.MensajeError = "Error guardando el contenido, intentalo de nuevo";
                    throw new Exception("Error guardando el contenido, intentalo de nuevo");
                }
            }
            else
            {
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = "Faltan datos por llenar";
            }
            

            return respuesta;
        }
    }
}