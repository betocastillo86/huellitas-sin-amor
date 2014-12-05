using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LoginCol.Huellitas.Entidades
{
    public class ZonaGeografica
    {
        public ZonaGeografica()
        {

        }

        public ZonaGeografica(int idZonaPadre)
        {
            ZonaGeograficaPadre = new ZonaGeografica() { ZonaGeograficaId = idZonaPadre };
        }
        
        public int ZonaGeograficaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        
        public string CodigoExterno { get; set; }

        [DefaultValue(false)]
        public bool Activo { get; set; }

        //private  ZonaGeografica _ZonaGeograficaPadre { get; set; }
        //public virtual ZonaGeografica ZonaGeograficaPadre { get { return _ZonaGeograficaPadre ?? new ZonaGeografica(); } set { _ZonaGeograficaPadre = value; } }
        public virtual ZonaGeografica ZonaGeograficaPadre { get; set; }

    }
}
