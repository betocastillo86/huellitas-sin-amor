using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class FormularioAdopcionRepositorio
    {

        public int Crear(FormularioAdopcion formularioAdopcion)
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

        public List<FormularioAdopcion> Obtener(int? idFormulario)
        {
            List<FormularioAdopcion> lista;
            
            using (var db = new Repositorio())
            {
                var query = db.FormulariosAdopciones
                    .Include(f => f.Contenido)
                    .Include(f => f.Usuario);

                if (idFormulario.HasValue)
                {
                    query = query.Include(f => f.Respuestas)
                        .Include(f => f.Respuestas.Select(r => r.Pregunta));
                    
                    query = query.Where(f => f.FormularioAdopcionId == idFormulario);
                }
                     

                lista = query.ToList();
                    
            }

            return lista ?? new List<FormularioAdopcion>();
        }


    }
}
