using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class FormularioAdopcionRepositorio
    {

        public int AgregarFormularioAdopcion(FormularioAdopcion formularioAdopcion)
        {
            try {
                using (var db = new Repositorio())
                {
                    formularioAdopcion.FechaCreacion = DateTime.Now;

                    db.FormulariosAdopciones
                        .Add(formularioAdopcion);
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return 0;
            }

            return formularioAdopcion.FormularioAdopcionId;
        }


    }
}
