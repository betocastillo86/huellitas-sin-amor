using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Utilidades
{
    public class ResultadoOperacion
    {
        public bool OperacionExitosa { get; set; }

        public string MensajeError { get; set; }

        public object InformacionAdicional { get; set; }

        public int Id { get; set; }

    }
}
