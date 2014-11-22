using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class UsuarioContenido
    {
        [Key]
        public int UsuarioContenidoId { get; set; }
        
        public int UsuarioId { get; set; }

        public int ContenidoId { get; set; }

        public int TipoRelacionId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Contenido Contenido { get; set; }

        public virtual TipoRelacion TipoRelacion { get; set; }
    }
}
