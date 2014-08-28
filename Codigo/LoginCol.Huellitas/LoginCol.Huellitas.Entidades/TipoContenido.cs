using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class TipoContenido
    {
        public int TipoContenidoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public virtual TipoContenido TipoContenidoPadre { get; set; } 

        public virtual ICollection<Contenido> Contenidos { get; set; }

        public virtual ICollection<Campo> Campos { get; set; }



    }
}
