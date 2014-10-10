using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LoginCol.Huellitas.Web.Infraestructure
{
    public class Autenticacion
    {
        /// <summary>
        /// Valida las credenciales de un usuario y crea la sesion
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="clave"></param>
        /// <param name="validarAdmin">true: Solo permite autenticar administradores false: permite autenticar a todos los usuarios</param>
        /// <returns></returns>
        public bool AutenticarUsuario(string correo, string clave, bool validarAdmin)
        {
            UsuarioNegocio usuariosNegocio = new UsuarioNegocio();
            Usuario usuarioAutenticado = usuariosNegocio.AutenticarUsuario(correo, clave);

            if (usuarioAutenticado.UsuarioId > 0)
            {
                if (!validarAdmin || (validarAdmin && usuarioAutenticado.EsAdministrador))
                {
                    Autenticacion.CrearSesion(usuarioAutenticado);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }



        public static bool EstaAutenticado()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        /// <summary>
        /// Cierra la sesión activa
        /// </summary>
        public static void CerrarSesion()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Crea la cookie de autenticación para el usuario recibido
        /// </summary>
        /// <param name="usuarioAutenticado"></param>
        public static void CrearSesion(Usuario usuarioAutenticado)
        {
            string cookie = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", usuarioAutenticado.UsuarioId, usuarioAutenticado.Nombres, usuarioAutenticado.Apellidos, usuarioAutenticado.Correo, usuarioAutenticado.NumeroDocumento, usuarioAutenticado.EsAdministrador);
            FormsAuthentication.SetAuthCookie(cookie, true);
        }
    }
}