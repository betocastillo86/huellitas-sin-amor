using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class TipoRelacionContenidoModel
    {
        public int TipoRelacionContenidoId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int TipoContenidoId { get; set; }

        /// <summary>
        /// Cantidad maxima de registros posibles en la relacion
        /// </summary>
        public int MaximoRegistros { get; set; }
    }
}