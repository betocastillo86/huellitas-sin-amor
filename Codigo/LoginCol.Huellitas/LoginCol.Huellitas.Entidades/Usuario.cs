using LoginCol.Huellitas.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [UniqueKey]
        [MaxLength(50)]
        public string Correo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string  Clave { get; set; }

        [MaxLength(15)]
        public string NumeroDocumento { get; set; }

        public DateTime FechaRegistro { get; set; }

        public Nullable<DateTime> FechaActualizacion { get; set; }

        public bool Activo { get; set; }

        public virtual List<Comentario> Comentarios { get; set; }

        public virtual List<Contenido> Contenidos { get; set; }

    }
}
