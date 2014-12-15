using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class ContactoNegocio
    {
        public static bool EnviarContacto(string nombres, string comentario, string email, string telefono)
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendFormat("Nombre:{0} <br/>", nombres);
            mensaje.AppendFormat("Comentario:{0} <br/>", comentario);
            mensaje.AppendFormat("Email:{0} <br/>", email);
            mensaje.AppendFormat("Telefono:{0} <br/>", telefono);
            return CorreoNegocio.EnviarCorreo(ParametrizacionNegocio.AsuntoContacto, ParametrizacionNegocio.DestinatarioCorreosContacto, mensaje.ToString());
        }
    }
}
