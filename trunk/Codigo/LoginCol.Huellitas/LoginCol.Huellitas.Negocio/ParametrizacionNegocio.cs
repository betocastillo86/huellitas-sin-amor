using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static string  String(string llave)
        {
            return datosParametrizacion.Obtener(llave);
        }

        private static bool Bool(string llave)
        {
            return Convert.ToBoolean(datosParametrizacion.Obtener(llave));
        }

        public List<Parametrizacion> Obtener()
        {
            return datosParametrizacion.Obtener();
        }

        public bool Actualizar(Parametrizacion modelo)
        {
            return datosParametrizacion.Actualizar(modelo);
        }

        public static int TamanoMaximoCargaArchivos { get { return Int("TamanoMaximoCargaArchivos"); } }

        public static string ExtensionesImagenes { get { return String("ExtensionesImagenes"); } }

        public static int ZonaGeograficaPorDefecto { get { return Int("ZonaGeograficaPorDefecto"); } }

        public static int CampoGeneroId { get { return Int("CampoGeneroId"); } }

        public static int CampoColorId { get { return Int("CampoColorId"); } }

        public static int CampoTamanoId { get { return Int("CampoTamanoId"); } }

        public static int CampoEdadId { get { return Int("CampoEdadId"); } }

        public static int CampoRecomendadoParaId { get { return Int("CampoRecomendadoParaId"); } }

        public static int ComentariosPorPagina { get { return Int("ComentariosPorPagina"); } }

        public static string LlaveRouterVerTodos { get { return String("LlaveRouterVerTodos"); } }


        public static string LlaveRouterQuieroAdoptar { get { return String("LlaveRouterQuieroAdoptar"); } }

        public static string UrlSitio { get { return String("UrlSitio"); } }

        public static string DestinatarioCorreosContacto { get { return String("DestinatarioCorreosContacto"); } }

        public static string AsuntoContacto { get { return String("AsuntoContacto"); } }

        public static string DescripcionHome { get { return String("DescripcionHome"); } }


        public static bool ValidarAnalytics { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["validarAnalytics"]); } }
    }
}
