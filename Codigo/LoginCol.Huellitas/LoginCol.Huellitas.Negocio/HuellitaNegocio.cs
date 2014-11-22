using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class HuellitaNegocio
    {

        private Lazy<ContenidoNegocio> _nContenido { get; set; }

        private ContenidoNegocio nContenido { get { return _nContenido.Value; } }

        public HuellitaNegocio()
        {
            _nContenido = new Lazy<ContenidoNegocio>();
        }



        /// <summary>
        /// Retorna el adoptante o el padrino de un contenido
        /// </summary>
        /// <param name="idContenido"></param>
        /// <returns></returns>
        public UsuarioContenido ObtenerAdoptanteOPadrino(int idContenido)
        {
            UsuarioContenido usuario = nContenido.ObtenerUsuariosRelacionados(idContenido, (int) TipoRelacionUsuariosEnum.Adoptante).FirstOrDefault();

            if (usuario == null)
            {
                usuario = nContenido.ObtenerUsuariosRelacionados(idContenido, (int)TipoRelacionUsuariosEnum.Padrino).FirstOrDefault();
            }

            return usuario;
        }
    }
}
