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
    }
}
