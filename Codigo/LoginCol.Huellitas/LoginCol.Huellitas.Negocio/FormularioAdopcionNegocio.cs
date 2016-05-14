using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class FormularioAdopcionNegocio
    {
        public FormularioAdopcionNegocio()
        {
            _formularioAdoptantes = new Lazy<FormularioAdopcionRepositorio>();
            _nUsuarios = new Lazy<UsuarioNegocio>();
        }

        
        private Lazy<FormularioAdopcionRepositorio> _formularioAdoptantes { get; set; }
        private FormularioAdopcionRepositorio dFormularioAdopcion { get { return _formularioAdoptantes.Value; } }
        
        
        private Lazy<UsuarioNegocio> _nUsuarios { get; set; }
        private UsuarioNegocio nUsuarios { get { return _nUsuarios.Value; } }


        public ResultadoOperacion Crear(FormularioAdopcion formularioAdopcion)
        {
            var respuesta = new ResultadoOperacion(true);
            
            //var usuario = nUsuarios.Crear(formularioAdopcion.Usuario.Correo, formularioAdopcion.Usuario.Nombres, formularioAdopcion.Usuario.Telefono);
            nUsuarios.Crear(formularioAdopcion.Usuario);


            if (formularioAdopcion.Usuario.UsuarioId > 0)
            {
                
                formularioAdopcion.UsuarioId = formularioAdopcion.Usuario.UsuarioId;
                formularioAdopcion.Usuario = null;
                formularioAdopcion.Contenido = null;

                respuesta.Id = dFormularioAdopcion.Crear(formularioAdopcion);
                respuesta.OperacionExitosa = respuesta.Id > 0;

                if (!respuesta.OperacionExitosa)
                    respuesta.MensajeError = "No fue posible crear el formulario";
                else
                {
                    //Después de generar la adopción envia el correo de confirmación
                    new CorreoNegocio().EnviarCorreoAdopcion(respuesta.Id, PlantillasCorreo.SolicitudAdopcion);
                }

                return respuesta;
            }
            else
            {
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = "No fue posible crear el usuario";
            }


            return respuesta; 
            
           
        }

        public List<FormularioAdopcion> Obtener()
        {
            try
            {
                return dFormularioAdopcion.Obtener(null);
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);

                return new List<FormularioAdopcion>();
            }
        }

        public FormularioAdopcion Obtener(int idFormulario)
        {
            try
            {
                return dFormularioAdopcion.Obtener(idFormulario)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);

                return new FormularioAdopcion();
            }
        }

        /// <summary>
        /// Actualiza los datos de un formulario de adopción, principalmente Información adicional, Observaciones y Estado
        /// </summary>
        /// <param name="idFormulario">Id del formulario a actualizar</param>
        /// <param name="estado"> estado nuevo del formulario</param>
        /// <param name="informacionCorreo">Información adicional del correo</param>
        /// <param name="observaciones">Observaciones internas de la adopción</param>
        /// <returns>true: si la operación fue exitosa</returns>
        public bool Actualizar(int idFormulario, string observaciones = null, string informacionCorreo = null, EstadoFormularioAdopcion? estado = null)
        {
            try 
	        {
                return dFormularioAdopcion.Actualizar(idFormulario, observaciones, informacionCorreo, estado);
	        }
	        catch (Exception e)
	        {
                LogErrores.RegistrarError(e);
                return false;
	        }
        }

        /// <summary>
        /// Realiza el envio de la respuesta de la adopción dependiendo del estado al que desea pasar, además de eso actualiza los datos en la tabla
        /// </summary>
        /// <param name="idFormulario">id del formulario que se desea enviars</param>
        /// <param name="estado">estado en el que va quedar el formulario</param>
        /// <param name="observaciones">observaciones internas que se tienen de la adopción. NO se envian en el correo</param>
        /// <param name="informacionCorreo">información adicional que se envia en el correo</param>
        /// <returns>Resultado del envio del correo y el respectivo error</returns>
        public ResultadoOperacion EnviarRespuestaAdopcion(int idFormulario, EstadoFormularioAdopcion estado, string observaciones = null, string informacionCorreo = null)
        { 
            
            ResultadoOperacion respuesta = new ResultadoOperacion(false);
            //Valida de acuerdo al estado que plantilla se debe usar para enviar el correo
            PlantillasCorreo plantilla = PlantillasCorreo.Ninguna;
            switch (estado)
	        {
                case EstadoFormularioAdopcion.Aprobado:
                    plantilla = PlantillasCorreo.AdopcionAprobada;
                 break;
                case EstadoFormularioAdopcion.Rechazado:
                    plantilla = PlantillasCorreo.AdopcionRechazada;
                 break;
                case EstadoFormularioAdopcion.AdoptadoPreviamente:
                    plantilla = PlantillasCorreo.AdopcionPrevia;
                 break;
	        }

            //Valida que haya sido uno de los estados validos para enviar correos
            //Esta validacion se hace por medio de la plantilla cargada
            if(plantilla != PlantillasCorreo.Ninguna)
            {
                //Si el correo es enviado actualiza la información en la BD
                if (new CorreoNegocio().EnviarCorreoAdopcion(idFormulario, plantilla, informacionCorreo))
                {
                    respuesta.OperacionExitosa = Actualizar(idFormulario, observaciones, informacionCorreo, estado);
                    //Si ocurrio un error actualiza el valor
                    if(respuesta.OperacionExitosa)
                        respuesta.MensajeError = "No fue posible actualizar en la base de datos el formulario";
                }
                else
                {
                    respuesta.MensajeError = "No fue posible enviar el correo";
                }

            }
            else
            {
                LogErrores.RegistrarError("Se intenta enviar correo para formulario invalido {0}", idFormulario);
                respuesta.MensajeError = "No es un estado valido para enviar la plantila";
            }


            return respuesta;
            
        }
    }
}
