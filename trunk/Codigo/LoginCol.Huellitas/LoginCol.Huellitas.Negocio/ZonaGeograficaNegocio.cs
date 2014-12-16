using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginCol.Huellitas.Datos;

namespace LoginCol.Huellitas.Negocio
{
    public class ZonaGeograficaNegocio
    {
        private Lazy<ZonaGeograficaRepositorio> _zonas { get; set; }

        public ZonaGeograficaNegocio()
        {
            _zonas = new Lazy<ZonaGeograficaRepositorio>();
        }
        
        public List<ZonaGeografica> ObtenerZonasGeograficasPorPadre(int idZonaPadre)
        {
            return _zonas.Value.Obtener(new ZonaGeografica() { ZonaGeograficaPadre = new ZonaGeografica() { ZonaGeograficaId = idZonaPadre } })
                .OrderBy(z => z.Nombre)
                .ToList();
        }
    }
}
