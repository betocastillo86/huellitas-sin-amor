using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Admin
{
    public class FormularioAdopcionModelBase : BaseModel
    {
        public int FormularioAdopcionId { get; set; }
        
        [Display(Description = "Información adicional enviada en el correo")]
        [MaxLength(500)]
        public string InformacionAdicionalCorreo { get; set; }

        [Display(Description = "Observaciones de la adopción")]
        [MaxLength(500)]
        public string Observaciones { get; set; }

        public EstadoFormularioAdopcion Estado { get; set; }

        [Required]
        public string Barrio { get; set; }

        public bool EnviarRespuesta { get; set; }
    }
}