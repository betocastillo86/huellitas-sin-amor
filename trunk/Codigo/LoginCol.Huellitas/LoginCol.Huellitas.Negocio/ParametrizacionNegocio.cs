using LoginCol.Huellitas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class ParametrizacionNegocio
    {
        private static Lazy<ParametrizacionRepositorio> lazyParamatrizacion = new Lazy<ParametrizacionRepositorio>(() => new ParametrizacionRepositorio());

        private static ParametrizacionRepositorio datosParametrizacion { get { return lazyParamatrizacion.Value; } }

        /// <summary>
        /// Retorna el valor de una llave en entero
        /// </summary>
        /// <param name="llave">llave buscada</param>
        /// <returns>valor convertido a entero</returns>
        private static int Int(string llave)
        {
            return Convert.ToInt32(datosParametrizacion.Obtener(llave));
        }

        private static string  String(string llave)
        {
            return datosParametrizacion.Obtener(llave);
        }

        private static bool Bool(string llave)
        {
            return Convert.ToBoolean(datosParametrizacion.Obtener(llave));
        }

        public static int TamanoMaximoCargaArchivos { get { return Int("TamanoMaximoCargaArchivos"); } }

        public static string ExtensionesImagenes { get { return String("ExtensionesImagenes"); } }

        public static int ZonaGeograficaPorDefecto { get { return Int("ZonaGeograficaPorDefecto"); } }

        public static int CampoGeneroId { get { return Int("CampoGeneroId"); } }

        public static int CampoColorId { get { return Int("CampoColorId"); } }

        public static int CampoTamanoId { get { return Int("CampoTamanoId"); } }

        public static int CampoEdadId { get { return Int("CampoEdadId"); } }

        public static int CampoRecomendadoParaId { get { return Int("CampoRecomendadoParaId"); } }
    }
}
