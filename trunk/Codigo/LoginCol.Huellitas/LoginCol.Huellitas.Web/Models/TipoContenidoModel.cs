using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class TipoContenidoModel
    {
        public int TipoContenidoId { get; set; }

        public string Nombre { get; set; }

        public List<CampoModel> Campos { get; set; }
    }
}