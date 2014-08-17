using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Comentario
    {
        public int ComentarioId { get; set; }

        [Required]
        public string Texto { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UsuarioId { get; set; }
        
        public virtual Usuario Usuario { get; set; }

        public int ContenidoId { get; set; }

        public virtual Contenido Contenido { get; set; }
  
    }
}
