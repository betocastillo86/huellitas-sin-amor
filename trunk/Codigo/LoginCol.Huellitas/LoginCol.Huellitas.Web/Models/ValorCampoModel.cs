using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ValorCampoModel
    {
        public int CampoId { get; set; }

        public string CampoNombre { get; set; }

        public string Valor { get; set; }

        public string ValorTexto { get; set; }
    }
}