using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class FormularioAdopcion
    {
        public int FormularioAdopcionId { get; set; }

        public int ContenidoId { get; set; }

        public int UsuarioId { get; set; }
        
        public int MiembrosFamilia { get; set; }

        //public string EdadesMiembros { get; set; }

        public virtual List<RespuestaAdopcion> Respuestas { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Contenido Contenido { get; set; }

        //public virtual ZonaGeografica ZonaGeografica { get; set; }

        public virtual Usuario Usuario { get; set; }

        [MaxLength(3000)]
        public string InformacionAdicionalCorreo { get; set; }

        [MaxLength(3000)]
        public string Observaciones { get; set; }

        [MaxLength(50)]
        public string Barrio { get; set; }

        public EstadoFormularioAdopcion Estado { get; set; }
    }
}
