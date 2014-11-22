using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    /// <summary>
    /// Tipos de relaciones existentes en el sistema, diferentes a relaciones entre contenidos
    /// </summary>
    public class TipoRelacion
    {
        
        [Key]
        public int TipoRelacionId { get; set; }

        [MaxLength(20)]
        public string Nombre { get; set; }
        
        [MaxLength(500)]
        public string Descripcion { get; set; }

        public int TipoContenidoId { get; set; }

        public virtual TipoContenido TipoContenido { get; set; }

    }
}
