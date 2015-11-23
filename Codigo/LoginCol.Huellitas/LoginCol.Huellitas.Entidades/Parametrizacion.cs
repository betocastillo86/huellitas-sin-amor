using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Parametrizacion
    {
        [Key]
        [MaxLength(50)]
        public string Llave { get; set; }
        
        [Required]
        [MaxLength(4000)]
        public string Valor { get; set; }
    }
}
