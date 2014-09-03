using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class CampoTipoContenido
    {
        [Key]
        public int CampoTipoContenidoId { get; set; }

        public int CampoId { get; set; }

        public int TipoContenidoId { get; set; }

        public virtual Campo Campo { get; set; }

        public virtual TipoContenido TipoContenido { get; set; }

    }
}
