using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class ContenidoRelacionado
    {
        [Key]
        public int ContenidoRelacionadoId { get; set; }

        public int ContenidoId { get; set; }

        public int ContenidoHijoId { get; set; }

        public int TipoRelacionContenidoId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Contenido Contenido { get; set; }

        public virtual Contenido ContenidoHijo { get; set; }

        public virtual TipoRelacionContenido TipoRelacionContenido { get; set; }

    }
}
