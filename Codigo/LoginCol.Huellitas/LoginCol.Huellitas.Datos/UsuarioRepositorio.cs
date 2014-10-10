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
    }
}
