using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class TipoRelacionTipoContenido
    {
        [Key]
        public int TipoRelacionTipoContenidoId { get; set; }

        public int TipoContenidoId { get; set; }

        public int TipoRelacionContenidoId { get; set; }

        

        public virtual TipoContenido TipoContenido { get; set; }

        public virtual TipoRelacionContenido TipoRelacionContenido { get; set; }
    }
}
