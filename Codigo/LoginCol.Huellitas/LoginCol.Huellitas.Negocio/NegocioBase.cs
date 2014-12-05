using LoginCol.Huellitas.Negocio.Directorios;
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
            this._rutasFisicas = new RutaFisicaWeb();
        }

        protected readonly IRutasFisicas _rutasFisicas;

        public NegocioBase(IRutasFisicas rutasFisicas)
        {
            this._rutasFisicas = rutasFisicas;
        }
        
        private string _rutaServidor = string.Empty;
        public string RutaServidor
        {
            get
            {
                if (this._rutasFisicas == null)
                {
                    throw new Exception("no hay instanciado un IrutasFisicas");
                }
                else
                    return _rutasFisicas.ObtenerRutaFisica();
            }
        }
    }
}
