using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class CampoModel
    {
        public int CampoId { get; set; }

        public string CampoNombre { get; set; }

        public LoginCol.Huellitas.Entidades.TipoDatoCampo CampoTipoDato { get; set; }

        public List<OpcionCampoModel> CampoOpciones { get; set; }

    }
}