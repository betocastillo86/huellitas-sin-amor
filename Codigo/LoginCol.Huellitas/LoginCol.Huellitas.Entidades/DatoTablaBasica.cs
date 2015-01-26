using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class DatoTablaBasica
    {
        public int DatoTablaBasicaId { get; set; }

        public int TablaBasicaId { get; set; }

        public virtual TablaBasica TablaBasica { get; set;}

        public string Valor { get; set; }

        public string ValorIngles { get; set; }

        public Nullable<int> PadreId { get; set; }

        public bool Activo { get; set; }

        public string CodigoExterno { get; set; }

        public string InformacionAdicional { get; set; }

        public virtual List<RespuestaAdopcion> Respuestas { get; set; }

        public virtual List<Usuario> Ocupaciones { get; set; }

        public virtual List<Usuario> EstadosCiviles { get; set; }
    }
}
