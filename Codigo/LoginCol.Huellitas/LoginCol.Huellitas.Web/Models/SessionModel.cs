using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class SessionModel
    {
        //private static Usuario _UsuarioAutenticado { get; set; }

        public static Usuario Usuario
        {
            get
            {
                var _UsuarioAutenticado = new Usuario();

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //System.Web.Security.FormsAuthentication.SignOut();
                    string[] datosUsuario = HttpContext.Current.User.Identity.Name.Split(new char[] { '|' });
                    _UsuarioAutenticado.UsuarioId = int.Parse(datosUsuario[0]);
                    _UsuarioAutenticado.Nombres = datosUsuario[1];
                    _UsuarioAutenticado.Apellidos = datosUsuario[2];
                    _UsuarioAutenticado.Correo = datosUsuario[3];
                    _UsuarioAutenticado.NumeroDocumento = datosUsuario[4];
                    _UsuarioAutenticado.EsAdministrador = Convert.ToBoolean(datosUsuario[5]);
                }

                return _UsuarioAutenticado;
            }
        }
    }
}