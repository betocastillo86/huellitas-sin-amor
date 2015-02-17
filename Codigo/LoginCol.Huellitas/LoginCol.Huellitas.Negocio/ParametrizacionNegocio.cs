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

        public bool ExisteLlave(string llave)
        {
            return datosParametrizacion.ExisteLLave(llave);
        }

        public List<Parametrizacion> Obtener()
        {
            return datosParametrizacion.Obtener();
        }

        /// <summary>
        /// Actualiza el valor de una variable de parametrización
        /// dependiendo de los parametros de entrada, puede crear el registro si no existe
        /// </summary>
        /// <param name="modelo">Valores de la llave de parametrización. Nombre y valor</param>
        /// <param name="crearSiNoExiste">Si no llegase a existir la llave que intenta actualizar, se debe crear</param>
        /// <returns>true: Si los datos fueron actualizados false: si no se actualiza nada</returns>
        public bool Actualizar(Parametrizacion modelo, bool crearSiNoExiste = false)
        {
            //Si está activo el crear al no existir y si la llave efectivamente no existe, la crea
            //de lo contrario intenta actualizarla
            if (crearSiNoExiste && !ExisteLlave(modelo.Llave))
            {
                return datosParametrizacion.Crear(modelo);
            }
            else
                return datosParametrizacion.Actualizar(modelo);
        }

        public static int TamanoMaximoCargaArchivos { get { return Int("TamanoMaximoCargaArchivos"); } }

        public static string ExtensionesImagenes { get { return String("ExtensionesImagenes"); } }

        public static int ZonaGeograficaPorDefecto { get { return Int("ZonaGeograficaPorDefecto"); } }

        public static int CampoGeneroId { get { return Int("CampoGeneroId"); } }

        public static int CampoColorId { get { return Int("CampoColorId"); } }

        public static int CampoTamanoId { get { return Int("CampoTamanoId"); } }

        public static int CampoEdadId { get { return Int("CampoEdadId"); } }

        public static int CampoContactoNombreId { get { return Int("CampoContactoNombreId"); } }

        public static int CampoContactoCorreoId { get { return Int("CampoContactoCorreoId"); } }

        public static int CampoContactoTelefonoId { get { return Int("CampoContactoTelefonoId"); } }

        public static int CampoRecomendadoParaId { get { return Int("CampoRecomendadoParaId"); } }

        public static int ComentariosPorPagina { get { return Int("ComentariosPorPagina"); } }


        public static int CampoTipoPerdido { get { return Int("CampoTipoPerdido"); } }

        public static int CampoRaza { get { return Int("CampoRaza"); } }

        public static string LlaveRouterVerTodos { get { return String("LlaveRouterVerTodos"); } }


        public static string LlaveRouterQuieroAdoptar { get { return String("LlaveRouterQuieroAdoptar"); } }

        public static string UrlSitio { get { return String("UrlSitio"); } }

        public static string DestinatarioCorreosContacto { get { return String("DestinatarioCorreosContacto"); } }

        public static string AsuntoContacto { get { return String("AsuntoContacto"); } }

        public static string DescripcionHome { get { return String("DescripcionHome"); } }


        public static bool ValidarAnalytics { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["validarAnalytics"]); } }

        public static int UsuarioPorDefecto { get { return Int("UsuarioPorDefecto"); } }

        public static string DescripcionPerdidos { get { return String("DescripcionPerdidos"); } }

        public static string AsuntoAdopcion { get { return String("AsuntoAdopcion"); } }

        public static string AsuntoAdopcionAceptada { get { return String("AsuntoAdopcionAceptada"); } }

        public static string AsuntoAdopcionRechazada { get { return String("AsuntoAdopcionRechazada"); } }

        public static string AsuntoAdopcionEspera { get { return String("AsuntoAdopcionEspera"); } }
    }
}
