using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    /// <summary>
    /// Tabla en la que se almacenarán los seguimientos realizados a las adopciones aprobadas 
    /// </summary>
    public class SeguimientoAdopcion
    {
        [Key]
        public int SeguimientoAdopcionId { get; set; }

        public int AdopcionId { get; set; }

        public bool Imagen1 { get; set; }

        public bool Imagen2 { get; set; }
        
        [MaxLength(50)]
        public string Video { get; set; }

        public DateTime FechaRespuesta { get; set; }

        public string Observaciones { get; set; }

        public virtual Adopcion Adopcion { get; set; }

        public virtual List<RespuestaSeguimiento> Respuestas { get; set; }

    }
}
