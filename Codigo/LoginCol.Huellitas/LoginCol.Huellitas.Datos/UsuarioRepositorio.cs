using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class UsuarioRepositorio
    {

        /// <summary>
        /// De acuerdo al usuario y clave autentica a un usuario y devuelve el objeto cargado
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="clave">clave en MD5</param>
        /// <returns>Objeto usuario autenticado, si la autenticación tiene errores retorna un objeto instanciado</returns>
        public Usuario AutenticarUsuario(string correo, string clave)
        {
            Usuario usuario = null;

            try
            {
                using (var db = new Repositorio())
                {
                    usuario = db.Usuarios
                        .Where(_ => _.Correo.Equals(correo) && _.Clave.Equals(clave))
                        .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }
            

            return usuario == null ? new Usuario() : usuario;
        }

        public int CrearUsuario(Usuario usuario)
        {

            using (var db = new Repositorio())
            {
                usuario.FechaRegistro = DateTime.Now;
                db.Usuarios
                    .Add(usuario);
                db.SaveChanges();
            }

            return usuario.UsuarioId;
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            Usuario usuario = null;

            using (var db = new Repositorio())
            {
                usuario = db.Usuarios
                    .Where(u => u.Correo.Equals(correo))
                    .FirstOrDefault();
            }

            return usuario ?? new Usuario();
        }

        public List<Usuario> ObtenerUsuariosActivos(bool soloAdmin)
        {
            List<Usuario> usuarios;

            using (var db = new Repositorio())
            {
                usuarios = db.Usuarios
                    .Where(u => u.Activo && u.EsAdministrador == soloAdmin)
                    .ToList();
            }

            return usuarios ?? new List<Usuario>();
        }
    }
}
