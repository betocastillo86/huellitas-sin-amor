using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LoginCol.Huellitas.Datos
{
    public class AdopcionRepositorio
    {
        /// <summary>
        /// Guarda un formulario de adopción
        /// </summary>
        /// <param name="adopcion"></param>
        /// <returns></returns>
        public bool Crear(Adopcion adopcion)
        {
            adopcion.FechaCreacion = DateTime.Now;
            bool exitoso = false;
            using (var db = new Repositorio())
            {
                db.Adopciones.Add(adopcion);
                exitoso = db.SaveChanges() > 0;
            }

            return exitoso;
        }
        /// <summary>
        /// Retorna una adopcion por el id
        /// </summary>
        /// <param name="idAdopcion"></param>
        /// <returns></returns>
        public Adopcion Obtener(int idAdopcion)
        {
            Adopcion adopcion = null;
            using (var db = new Repositorio())
            {
                adopcion = db.Adopciones.
                    Include("Contenido").
                    Include("Adoptante").
                    FirstOrDefault(a => a.AdopcionId == idAdopcion);
            }
            return adopcion;
        }

        /// <summary>
        /// Retorna todos los seguimuentos de una adopcion
        /// </summary>
        /// <param name="idAdopcion"></param>
        /// <returns></returns>
        public List<SeguimientoAdopcion> ObtenerSeguimientosPorAdopcion(int idAdopcion)
        {
            List<SeguimientoAdopcion> lista = null;
            using (var db = new Repositorio())
            {
                lista = db.SeguimientosAdopciones
                    .Include("Adopcion")
                    .Where(s => s.AdopcionId == idAdopcion)
                    .ToList();
            }
            return lista ?? new List<SeguimientoAdopcion>() ;
        }

        public List<Adopcion> Obtener()
        {
            List<Adopcion> lista = null;
            using (var db = new Repositorio())
            {
                lista = db.Adopciones
                    .Include(a => a.Adoptante)
                    .Include(a => a.Contenido)
                    .ToList();
            }
            return lista ?? new List<Adopcion>();
        }


        public void EliminarSeguimiento(int id)
        {
            using (var db = new Repositorio())
            {
                var obj = db.SeguimientosAdopciones.FirstOrDefault(s => s.SeguimientoAdopcionId == id);
                db.SeguimientosAdopciones.Remove(obj);
                ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(obj, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void CrearSeguimiento(SeguimientoAdopcion seguimiento)
        {
            using (var db = new Repositorio())
            {
                db.SeguimientosAdopciones.Add(seguimiento);
                db.SaveChanges();
            }
        }

        public SeguimientoAdopcion ObtenerSeguimientoAdopcion(int id)
        {
            SeguimientoAdopcion obj = null;
            using (var db = new Repositorio())
            {
                obj = db.SeguimientosAdopciones.FirstOrDefault(s => s.SeguimientoAdopcionId == id);
            }
            return obj ?? new SeguimientoAdopcion();
        }
    }
}
