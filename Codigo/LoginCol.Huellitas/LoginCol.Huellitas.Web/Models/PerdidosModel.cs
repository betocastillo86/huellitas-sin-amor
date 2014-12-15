using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class PerdidosModel : BaseModel
    {

        public PerdidosModel() : base("TituloPerdidos")
        {

        }

        [Required]
        public int TipoId { get; set; }
        [Required]
        public int BarrioId { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public int Genero { get; set; }
        [Required]
        public int Color { get; set; }
        [Required]
        public string ContactoNombre { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }
        [Required]
        public string ContactoCorreo { get; set; }
        
        [Required]
        public int Zona { get; set; }
    }
}