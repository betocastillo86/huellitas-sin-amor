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

namespace LoginCol.Huellitas.Web.Controllers
{
    public class PerdidosController : ApiController
    {

        public PerdidosController()
        {
            _nContenido = new Lazy<ContenidoNegocio>();
        }
        
        private Lazy<ContenidoNegocio> _nContenido { get; set; }
        private ContenidoNegocio nContenido { get { return _nContenido.Value; } }
        
        [HttpPost]
        public ResultadoOperacion Post(PerdidosModel modelo) {

            ResultadoOperacion respuesta = new ResultadoOperacion();
            if (modelo.TipoContenidoId == TipoContenidoEnum.AnimalesEncontrados || modelo.TipoContenidoId == TipoContenidoEnum.AnimalesPerdidos)
            {
                try
                {
                    var contenido = Mapper.Map<PerdidosModel, Contenido>(modelo);   
                    //Se sobreescire el tipo de contenido para solo tener en cuenta animales perdidos en el momento de los filtros
                    //contenido.TipoContenidoId = Convert.ToInt32(TipoContenidoEnum.AnimalesPerdidos); 
                    contenido.DescripcionCorta = modelo.Nombre;
                    contenido.Imagen = string.Empty;
                    contenido.Activo = true;
                    
                    //agrega los campso adicionales

                    respuesta = nContenido.Crear(contenido, ParametrizacionNegocio.UsuarioPorDefecto, modelo.Imagen);
                }
                catch (Exception e)
                {
                    LogErrores.RegistrarError(e);   
                    respuesta.OperacionExitosa = false;
                    respuesta.MensajeError = "Error guardando el contenido, intentalo de nuevo";
                }
            }
            else
            { 
                respuesta.MensajeError = "El tipo de contenido a guardar no es valido";
                respuesta.OperacionExitosa = false;
            }

            return respuesta;
        }
    }
}
