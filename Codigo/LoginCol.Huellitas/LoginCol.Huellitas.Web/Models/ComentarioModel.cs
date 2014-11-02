using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ComentarioModel
    {
        public int ComentarioId { get; set; }

        [Required]
        public string Texto { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioNombres { get; set; }

        public int ContenidoId { get; set; }

        public string CorreoElectronico { get; set; }
    }
}