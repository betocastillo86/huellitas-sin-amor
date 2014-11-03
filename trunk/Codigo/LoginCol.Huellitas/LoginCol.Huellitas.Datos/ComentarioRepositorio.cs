using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LoginCol.Huellitas.Datos
{
    public class ComentarioRepositorio
    {
        /// <summary>
        /// Retorna el listado comentarios existentes en el contenido
        /// </summary>
        /// <param name="idContenido">id del contenido que debe cargar</param>
        /// <returns></returns>
        public List<Comentario> ObtenerComentarios(int idContenido)
        {
            List<Comentario> lista = null;

            using (var db = new Repositorio())
            {
                lista = db.Comentarios
                    .Include(c => c.Usuario)
                    .Where(c=> c.ContenidoId == idContenido)
                    .ToList();
            }

            return lista ?? new List<Comentario>();
        }


        public Comentario AgregarComentario(Comentario comentario)
        {
            using (var db = new Repositorio())
            {
                comentario.FechaCreacion = DateTime.Now;
                db.Comentarios
                    .Add(comentario);
                db.SaveChanges();

                //Actualiza el numero de comentarios del contenido
                int numComentarios = db.Comentarios
                    .Where(c => c.ContenidoId == comentario.ContenidoId && c.Activo)
                    .Count();

                db.Contenidos
                    .Where(c => c.ContenidoId == comentario.ContenidoId)
                    .FirstOrDefault()
                    .Comentarios = numComentarios;

                db.SaveChanges();

            }

            return comentario;
        }
    }
}
