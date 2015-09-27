using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class SeguimientoModel : BaseModel
    {

        public int ContenidoId { get; set; }

        public string ContenidoNombre { get; set; }

        public int AdopcionId { get; set; }

        [Required(ErrorMessage= "Las observaciones son obligatorias")]

        public string Observaciones { get; set; }

        [Required(ErrorMessage="La imagen principal es obligatoria")]
        public string Imagen1 { get; set; }

        public string Imagen2 { get; set; }

        public string Key { get; set; }

    }
}