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

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            return _usuarios.Value.ObtenerUsuarioPorCorreo(correo);
        }

        /// <summary>
        /// Crea un usuario partiendo del correo y los nombres
        /// El usuario queda inactivo y no es administrador
        /// </summary>
        /// <param name="correo">correo del usuario</param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Usuario CrearUsuarioDesdeCorreo(string correo, string nombre, string telefono = null)
        {
            //Busca si hay usuarios registrados con ese correo
            var usuario = ObtenerUsuarioPorCorreo(correo);

            //Valida si el suuario que esta poniendo el comentario esta registrado o no
            if (usuario.UsuarioId == 0)
            {
                usuario = new Usuario();
                usuario.Correo = correo;
                usuario.Nombres = nombre;
                usuario.Telefono = telefono;
                usuario.Apellidos = ".";
                usuario.EsAdministrador = false;
                usuario.Clave = ".";
                usuario.Activo = false;
                usuario.UsuarioId = _usuarios.Value.CrearUsuario(usuario);
            }

            return usuario;            
        }

        public List<Usuario> ObtenerUsuariosActivos(bool soloAdmin)
        {
            return _usuarios.Value.ObtenerUsuariosActivos(soloAdmin);
        }
    }
}
