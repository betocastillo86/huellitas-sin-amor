using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class TipoContenidoNegocio
    {
        public Lazy<TipoContenidoRepositorio> _tiposContenidos { get; set; }

        public TipoContenidoNegocio()
        {
            _tiposContenidos = new Lazy<TipoContenidoRepositorio>();
        }
        
        
        public List<TipoContenido> ObtenerPorPadre(int id)
        {
            return _tiposContenidos.Value.Obtener(new TipoContenido() { TipoContenidoPadre = new TipoContenido() { TipoContenidoId = id } });
        }

        public List<Campo> ObtenerCampos(int id)
        {
            return _tiposContenidos.Value.ObtenerCampos(id);
        }

        public TipoContenido Obtener(int id)
        {
            return _tiposContenidos.Value.Obtener(id);
        }

        /// <summary>
        /// Retorna los tipos de relacion existentes por un tipo de contenido
        /// </summary>
        /// <param name="idTipoContenido"></param>
        /// <returns></returns>
        public List<TipoRelacionContenido> ObtenerTiposDeRelacionContenido(int idTipoContenido)
        {
            return _tiposContenidos.Value.ObtenerTiposDeRelacionContenido(idTipoContenido);
        }

        /// <summary>
        /// Retorna el tipo de relacion contenido por el id
        /// </summary>
        /// <param name="idTipoRelacionContenido"></param>
        /// <returns></returns>
        public TipoRelacionContenido ObtenerTipoRelacionContenido(int idTipoRelacionContenido)
        {
            return _tiposContenidos.Value.ObtenerTipoRelacionContenido(idTipoRelacionContenido);
        }

        public List<TipoContenido> Obtener()
        {
            return _tiposContenidos.Value.Obtener(new TipoContenido());
        }

        public List<TipoRelacion> ObtenerTiposDeRelacionUsuarios(int idTipoContenido)
        {
            return _tiposContenidos.Value.ObtenerTiposDeRelacionUsuarios(idTipoContenido);
        }
    }
}
