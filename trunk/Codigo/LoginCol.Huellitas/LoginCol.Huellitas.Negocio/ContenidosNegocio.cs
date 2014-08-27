using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class ContenidosNegocio
    {
        public  Lazy<ContenidosRepositorio> _contenidos { get; set; }

        public ContenidosNegocio()
        {
            _contenidos = new Lazy<ContenidosRepositorio>(false);
        }

        public List<Contenido> ObtenerPorTipo(TipoContenidoEnum tipoContenido)
        {
            return new ContenidosRepositorio().ObtenerPorTipo(tipoContenido);
        }
    }
}
