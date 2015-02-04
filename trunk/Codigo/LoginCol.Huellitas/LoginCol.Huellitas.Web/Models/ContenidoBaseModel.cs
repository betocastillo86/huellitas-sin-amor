using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ContenidoBaseModel : BaseModel
    {
        public int ContenidoId { get; set; }
        
        [MaxLength(50)]
        [Display(Name = "Nombre", Description = "Nombre del contenido")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string NombreLink { get { return !string.IsNullOrEmpty(Nombre) ?  Nombre.Replace(" ", "-") : string.Empty; } }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción", Description = "Descripción del contenido")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de Creación", Description = "Fecha de creación del contenido")]
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        [Display(Name = "Tipo de contenido", Description = "Tipo de contenido")]
        public int TipoContenidoId { get; set; }

        public string TipoContenidoNombre { get; set; }

        public bool Activo { get; set; }

        public bool Destacado { get; set; }

        public string Email { get; set; }

        [MaxLength(130)]
        public string DescripcionCorta { get; set; }
    }
}