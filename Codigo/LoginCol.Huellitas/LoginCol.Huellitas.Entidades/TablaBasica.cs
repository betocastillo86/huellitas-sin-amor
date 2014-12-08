using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class TablaBasica
    {
        public int TablaBasicaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<DatoTablaBasica> DatosTablaBasica { get; set; }
    }
}
