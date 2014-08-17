using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LoginCol.Huellitas.Entidades
{
    public class ZonaGeografica
    {
        public int ZonaGeograficaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        
        public string CodigoExterno { get; set; }

        public Nullable<int> ZonaGeograficaPadreId { get; set; }

        public virtual ZonaGeografica ZonaGeograficaPadre { get; set; }
    }
}
