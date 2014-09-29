using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ContenidoRelacionadoModel
    {
        public int ContenidoRelacionadoId { get; set; }

        public ContenidoBaseModel ContenidoHijo { get; set; }

        public int TipoRelacionContenidoId { get; set; }
    }
}