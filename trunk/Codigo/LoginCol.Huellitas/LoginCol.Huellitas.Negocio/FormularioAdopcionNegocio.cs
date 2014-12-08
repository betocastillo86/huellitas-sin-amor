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
        }

        private Lazy<FormularioAdopcionRepositorio> _formularioAdoptantes { get; set; }

        public ResultadoOperacion Crear(FormularioAdopcion formularioAdopcion)
        {
            ResultadoOperacion respuesta = new ResultadoOperacion();
            
            respuesta.Id = _formularioAdoptantes.Value.AgregarFormularioAdopcion(formularioAdopcion);
            respuesta.OperacionExitosa = respuesta.Id > 0;

            if (!respuesta.OperacionExitosa)
                respuesta.MensajeError = "No fue posible crear el formulario";
           
            return respuesta;
        }
    }
}
