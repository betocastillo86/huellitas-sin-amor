using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class UsuarioNegocio
    {
        public Lazy<UsuarioRepositorio> _usuarios { get; set; }

        public UsuarioNegocio()
        {
            _usuarios = new Lazy<UsuarioRepositorio>();
        }


        /// <summary>
        /// De acuerdo al usuario y clave autentica a un usuario y devuelve el objeto cargado
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="clave"></param>
        /// <returns>Objeto usuario autenticado, si la autenticación tiene errores retorna un objeto instanciado</returns>
        public Usuario AutenticarUsuario(string correo, string clave)
        {
            return _usuarios.Value.AutenticarUsuario(correo, Seguridad.MD5(clave));
        }
    }
}
