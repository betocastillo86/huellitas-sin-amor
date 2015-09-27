using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class SeguimientoAdopcionModel
    {
        public int SeguimientoAdopcionId { get; set; }

        public int AdopcionId { get; set; }

        public string Imagen1 { get; set; }

        public string Imagen2 { get; set; }

        public string Video { get; set; }

        public DateTime FechaRespuesta { get; set; }

        public string Observaciones { get; set; }

        public string AdopcionContenidoNombre { get; set; }
        
        public string AdopcionContenidoId { get; set; }
    }
}