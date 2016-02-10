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

        public HuellitasApiController()
        {
            _nContenido = new Lazy<ContenidoNegocio>();
        }

        private ContenidoNegocio nContenido { get { return _nContenido.Value; } }

        [HttpPost]
        public ResultadoOperacion Post(CrearHuellitaModel modelo)
        {

            ResultadoOperacion respuesta = new ResultadoOperacion();
            
            try
            {
                var contenido = Mapper.Map<CrearHuellitaModel, Contenido>(modelo);
                contenido.DescripcionCorta = modelo.Nombre;
                contenido.Activo = true;

                //Crea el contenido
                respuesta = nContenido.Crear(contenido, ParametrizacionNegocio.UsuarioPorDefecto, modelo.Imagen.First());
                
                if (respuesta.OperacionExitosa)
                {
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
            

            return respuesta;
        }
    }
}