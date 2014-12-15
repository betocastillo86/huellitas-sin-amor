using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class RespuestaAdopcion
    {
        [Key]
        public int RespuestaAdopcionId { get; set; }

        public int FormularioAdopcionId { get; set; }

        public int PreguntaId { get; set; }

        public string Respuesta { get; set; }

        public virtual DatoTablaBasica Pregunta { get; set; }

        public virtual FormularioAdopcion FormularioAdopcion { get; set; }
    }
}
