using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Utilidades
{
    public class ResultadoOperacion
    {

        public ResultadoOperacion()
        {

        }
        public ResultadoOperacion(bool operacionExitosa)
        {
            this.OperacionExitosa = operacionExitosa;
        }
        public bool OperacionExitosa { get; set; }

        public string MensajeError { get; set; }

        public object InformacionAdicional { get; set; }

        public int Id { get; set; }

    }
}
