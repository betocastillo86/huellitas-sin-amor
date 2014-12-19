using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class UsuarioModel : UsuarioBaseModel
    {
        [Required]
        public int OcupacionId { get; set; }
        
        public string OcupacionValor { get; set; }
        
        [Required]
        public int EstadoCivilId { get; set; }

        public string EstadoCivilValor { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [MaxLength(100)]
        [Required]
        public string Direccion { get; set; }
        
        [MaxLength(18)]
        [Required]
        public string Telefono { get; set; }
        
        [MaxLength(18)]
        [Required]
        public string Celular { get; set; }

        [Required]
        public DateTime? FechaNacimiento { get; set; }
    }
}