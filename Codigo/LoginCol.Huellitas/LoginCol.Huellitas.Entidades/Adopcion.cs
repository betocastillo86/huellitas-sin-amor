using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Adopcion
    {
        [Key]
        public int AdopcionId { get; set; }

        public int AdoptanteId { get; set; }

        public int FormularioId { get; set; }

        [Required]
        public DateTime FechaAdopcion { get; set; }

        public int ContenidoId { get; set; }

        [Required]
        public string Observaciones { get; set; }
        
        [Required]
        public DateTime FechaCreacion { get; set; }


        public virtual Contenido Contenido { get; set; }

        public virtual Usuario  Adoptante { get; set; }

        public virtual FormularioAdopcion Formulario { get; set; }

        public virtual List<SeguimientoAdopcion> Seguimientos { get; set; }

    }
}
