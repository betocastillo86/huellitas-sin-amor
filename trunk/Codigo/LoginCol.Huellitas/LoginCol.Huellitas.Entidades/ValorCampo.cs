using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class ValorCampo
    {
        [Key]
        public int ValorCampoId { get; set; }

        public int CampoId { get; set; }

        public int ContenidoId { get; set; }

        [Required]
        public string Valor { get; set; }

        public virtual Campo Campo { get; set; }

        public virtual Contenido Contenido { get; set; }
    }
}
