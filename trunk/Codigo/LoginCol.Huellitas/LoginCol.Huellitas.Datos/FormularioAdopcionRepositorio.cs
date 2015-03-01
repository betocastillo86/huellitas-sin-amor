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
                    .Include(f => f.Usuario)
                    .Include(f => f.Usuario.ZonaGeografica);

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


        /// <summary>
        /// Actualiza los datos de un formulario de adopción, principalmente Información adicional, Observaciones y Estado
        /// </summary>
        /// <param name="idFormulario">Id del formulario a actualizar</param>
        /// <param name="estado"> estado nuevo del formulario</param>
        /// <param name="informacionCorreo">Información adicional del correo</param>
        /// <param name="observaciones">Observaciones internas de la adopción</param>
        /// <returns>true: si la operación fue exitosa</returns>
        public bool Actualizar(int idFormulario, string observaciones, string informacionCorreo, EstadoFormularioAdopcion? estado)
        {
            bool respuesta = false;
            using (var db = new Repositorio())
            {
                var formulario = db.FormulariosAdopciones
                    .FirstOrDefault(f => f.FormularioAdopcionId == idFormulario);
                
                if (formulario != null)
                {
                    formulario.Observaciones = observaciones ?? formulario.Observaciones;
                    formulario.InformacionAdicionalCorreo = informacionCorreo ?? formulario.InformacionAdicionalCorreo;
                    formulario.Estado = estado ?? formulario.Estado;
                    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(formulario, EntityState.Modified);
                    respuesta = db.SaveChanges() > 0;
                }

            }
            return respuesta;
        }
    }
}
