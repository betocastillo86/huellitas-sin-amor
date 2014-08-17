using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Campo
    {
        public int CampoId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public TipoDatoCampo TipoDato { get; set; }

        public int TipoContenidoId { get; set; }

        public virtual TipoContenido TipoContenido { get; set; }

        public virtual List<ValorCampo> Valores { get; set; }
    }

    public enum TipoDatoCampo
    { 
        Int,
        Bit,
        Varchar
    }
}
