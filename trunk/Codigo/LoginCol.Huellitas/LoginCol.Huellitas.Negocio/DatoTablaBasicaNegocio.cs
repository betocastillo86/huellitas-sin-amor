using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class DatoTablaBasicaNegocio : NegocioBase
    {

        private  Lazy<DatoTablaBasicaRepositorio> _datosTablaBasica { get; set; }

        public DatoTablaBasicaNegocio()
        {
            _datosTablaBasica = new Lazy<DatoTablaBasicaRepositorio>();
        }


        public List<DatoTablaBasica> ObtenerPorIdTabla(TablasBasicasEnum TablaBasicaId)
        {
            return _datosTablaBasica.Value.ObtenerPorTabla((int)TablaBasicaId);
        }
    }
}
