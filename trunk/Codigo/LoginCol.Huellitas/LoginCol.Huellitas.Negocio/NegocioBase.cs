using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class NegocioBase
    {
        public NegocioBase()
        {

        }

        public NegocioBase(string rutaServidor)
        {
            this._rutaServidor = rutaServidor;
        }
        
        private string _rutaServidor = string.Empty;
        public string RutaServidor
        {
            get
            {
                if (string.IsNullOrEmpty(_rutaServidor))
                {
                    throw new Exception("No se ha cargado la ruta del servidor");
                }
                else
                    return _rutaServidor;
            }
            set
            {
                _rutaServidor = value;
            }
        }
    }
}
