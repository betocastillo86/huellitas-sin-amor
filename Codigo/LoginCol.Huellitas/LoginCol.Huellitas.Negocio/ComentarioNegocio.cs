using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class ComentarioNegocio
    {
        public List<Comentario> ObtenerComentarios(int idContenido)
        {
            ComentarioRepositorio dComentario = new ComentarioRepositorio();
            return dComentario.ObtenerComentarios(idContenido);
        }

        /// <summary>
        /// Crea un comentario en la Base de datos y registra al usuario si este no existe en la Base de datos, relacionandolo
        /// </summary>
        /// <param name="comentario">datos del comentario</param>
        /// <returns></returns>
        public Comentario AgregarComentario(Comentario comentario)
        {
            UsuarioNegocio nUsuario = new UsuarioNegocio();

            comentario.UsuarioId = nUsuario.CrearUsuarioDesdeCorreo(comentario.Usuario.Correo, comentario.Usuario.Nombres).UsuarioId;

            if (comentario.UsuarioId > 0)
            {
                //Agrega el comentario a Base de datos
                ComentarioRepositorio dComentario = new ComentarioRepositorio();
                comentario.Activo = true;
                comentario.Usuario = null;
                //comentario.FechaCreacion = DateTime.Now;
                comentario = dComentario.AgregarComentario(comentario);
            }


            return comentario;
        }
    }
}
