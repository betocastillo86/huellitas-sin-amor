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
        private FormularioAdopcionRepositorio nFormularioAdopcion { get { return _formularioAdoptantes.Value; } }
        
        
        private Lazy<UsuarioNegocio> _nUsuarios { get; set; }
        public UsuarioNegocio nUsuarios { get { return _nUsuarios.Value; } }


        public ResultadoOperacion Crear(FormularioAdopcion formularioAdopcion)
        {
            var respuesta = new ResultadoOperacion(true);
            var usuario = nUsuarios.CrearUsuarioDesdeCorreo(formularioAdopcion.Usuario.Correo, formularioAdopcion.Usuario.Nombres, formularioAdopcion.Usuario.Telefono);

            if (usuario.UsuarioId > 0)
            {
                formularioAdopcion.Usuario = null;
                formularioAdopcion.Contenido = null;
                formularioAdopcion.UsuarioId = usuario.UsuarioId;

                respuesta.Id = nFormularioAdopcion.Crear(formularioAdopcion);
                respuesta.OperacionExitosa = respuesta.Id > 0;

                if (!respuesta.OperacionExitosa)
                    respuesta.MensajeError = "No fue posible crear el formulario";

                return respuesta;
            }
            else
            {
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = "No fue posible crear el usuario";
            }


            return respuesta; 
            
           
        }
    }
}
