using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class RespuestaSeguimiento
    {
        [Key]
        public int RespuestaSeguimientoId { get; set; }

        public int SeguimientoId { get; set; }

        public int PreguntaId { get; set; }

        public string Respuesta { get; set; }

        public virtual SeguimientoAdopcion Seguimiento { get; set; }

        public virtual DatoTablaBasica Pregunta { get; set; }

    }
}
