using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class OpcionCampo
    {
        [Key]
        public int OpcionId { get; set; }

        public int CampoId { get; set; }

        public string Texto { get; set; }

        public virtual Campo Campo { get; set; }

    }
}
