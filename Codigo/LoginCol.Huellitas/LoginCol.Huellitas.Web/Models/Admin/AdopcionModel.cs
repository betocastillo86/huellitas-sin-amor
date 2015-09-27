using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Admin
{
    public class AdopcionModel
    {
        public int AdopcionId { get; set; }

        public int AdoptanteId { get; set; }

        [Required]
        [Display(Name = "Huellita adoptada")]
        public int ContenidoId { get; set; }


        [Display(Name = "Número Formulario Relacionado")]
        public int FormularioId { get; set; }

        
        public string AdoptanteNombres { get; set; }

        public string AdoptanteApellidos { get; set; }

        [Display(Name = "Adoptante")]
        public string AdoptanteNombreCompleto { get { return string.Format("{0} {1}", AdoptanteNombres, AdoptanteApellidos); } }

        [Display(Name = "Fecha de Adopción")]
        [Required]
        public DateTime FechaAdopcion { get; set; }

        [Required]
        public string Observaciones { get; set; }

        public List<ContenidoBaseModel> Contenidos { get; set; }

        public string ContenidoNombre { get; set; }
    }
}