using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class FiltroContenido
    {
        public FiltroContenido()
        {
            TipoFiltro = TipoFiltroContenidoEnum.Igual;
        }
        
        public int CampoId { get; set; }

        public string Valor { get; set; }

        public string ValorHasta { get; set; }

        public TipoFiltroContenidoEnum TipoFiltro { get; set; }
    }

    public enum TipoFiltroContenidoEnum
    { 
        Igual,
        Rango,
        [Description("Cuando hay varias opciones y alguna de esas es posible")]
        MultipleOpcion
    }
}
