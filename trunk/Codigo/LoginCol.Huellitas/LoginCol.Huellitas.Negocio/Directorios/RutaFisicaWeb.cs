using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoginCol.Huellitas.Negocio.Directorios
{
    public class RutaFisicaWeb : IRutasFisicas
    {
        public string ObtenerRutaFisica()
        {
            return HttpContext.Current.Server.MapPath("~/");
        }
    }
}
