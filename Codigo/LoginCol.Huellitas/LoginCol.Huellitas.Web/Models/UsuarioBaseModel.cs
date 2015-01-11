using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class UsuarioBaseModel
    {

        public int UsuarioId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        public string NombreCompleto { get { return string.Format("{0} {1}", Nombres, Apellidos); } }

        [NullableRequired]
        public int? ZonaGeograficaId { get; set; }
    }
}