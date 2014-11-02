using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .Where(c=> c.ContenidoId == idContenido)
                    .ToList();
            }

            return lista ?? new List<Comentario>();
        }


        public int AgregarComentario(Comentario comentario)
        {
            using (var db = new Repositorio())
            {
                comentario.FechaCreacion = DateTime.Now;
                db.Comentarios
                    .Add(comentario);
                 db.SaveChanges();
            }

            return comentario.ComentarioId;
        }
    }
}
