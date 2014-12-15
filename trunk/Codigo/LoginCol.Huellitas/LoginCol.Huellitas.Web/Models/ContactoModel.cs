using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ContactoModel
    {
        [Required]
        public string Nombres { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        [Required]
        public string Comentario { get; set; }
    }
}