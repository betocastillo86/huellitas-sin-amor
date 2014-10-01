using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public  class Configuraciones
    {
        public static int ZonaGeograficaPorDefecto { get { return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IdZonaGeograficaDefecto"]); } }
    }
}
