using LoginCol.Huellitas.Negocio.Directorios;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class CorreoNegocio
    {
        
            private static IRutasFisicas CargarRutasFisicas(IRutasFisicas rutaFisica)
            {
                if (rutaFisica == null)
                    return new RutaFisicaWeb();

                return rutaFisica;
            }
            
            /// <summary>
            /// Envia un correo que no requiere de plantilla
            /// </summary>
            /// <param name="asunto"></param>
            /// <param name="destinatario"></param>
            /// <param name="mensaje"></param>
            /// <returns></returns>
            public static bool EnviarCorreo(string asunto, string destinatario, string mensaje, IRutasFisicas rutasFisicas = null)
            {
                string[] parametros = null;
                return EnviarCorreo(asunto, destinatario, PlantillasCorreo.Ninguna, mensaje, null, rutasFisicas, parametros);
            }

            /// <summary>
            /// Envia un correo que requiere de plantilla
            /// </summary>
            /// <param name="asunto"></param>
            /// <param name="destinatario"></param>
            /// <param name="plantilla"></param>
            /// <param name="parametros"></param>
            /// <returns></returns>
            public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, IRutasFisicas rutasFisicas = null,params string[] parametros)
            {
                return EnviarCorreo(asunto, destinatario, plantilla, null, null, rutasFisicas, parametros);
            }


            //public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla,  params string[] parametros)
            //{
            //    return EnviarCorreo(asunto, destinatario, plantilla,mensaje, null, parametros);
            //}

            public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, List<string> adjuntos,  IRutasFisicas rutasFisicas = null, params string[] parametros)
            {
                return EnviarCorreo(asunto, destinatario, plantilla, null, adjuntos, rutasFisicas, parametros);
            }

            public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, List<string> adjuntos, int timeout, IRutasFisicas rutasFisicas = null, params string[] parametros)
            {
                return EnviarCorreo(asunto, destinatario, plantilla, null, adjuntos, timeout, rutasFisicas, parametros);
            }

            /// <summary>
            /// Envia el correo y carga la plantilla si es necesario
            /// </summary>
            /// <param name="asunto"></param>
            /// <param name="destinatario"></param>
            /// <param name="plantilla"></param>
            /// <param name="mensaje"></param>
            /// <param name="parametros"></param>
            /// <returns></returns>
            private static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, string mensaje, List<string> rutasAdjuntos, IRutasFisicas rutasFisicas = null,params string[] parametros)
            {
                return EnviarCorreo(asunto, destinatario, plantilla, mensaje, rutasAdjuntos, 0, rutasFisicas, parametros);
            }

            /// <summary>
            /// Evnia un correo con la ruta de la plantilla
            /// </summary>
            /// <param name="asunto"></param>
            /// <param name="destinatario"></param>
            /// <param name="plantilla"></param>
            /// <param name="rutasAdjuntos"></param>
            /// <param name="timeout"></param>
            /// <param name="parametros"></param>
            /// <returns></returns>
            public static bool EnviarCorreo(string asunto, string destinatario, string plantilla, List<string> rutasAdjuntos, int timeout = 0, IRutasFisicas rutasFisicas = null, params string[] parametros)
            {
                EnvioCorreos objCorreo = new EnvioCorreos();
                objCorreo.Para = destinatario;
                objCorreo.Asunto = asunto;
                objCorreo.TimeOut = timeout;
                
                rutasFisicas = CargarRutasFisicas(rutasFisicas);

                //if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]) && Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]))
                //{
                //    if (rutasAdjuntos != null)
                //        objCorreo.Adjuntos = rutasAdjuntos.ToArray();
                //}


                objCorreo.ConPlantilla = true;
                objCorreo.EsHtml = true;
                objCorreo.RutaPlantilla = plantilla;
                objCorreo.UrlSitio = ParametrizacionNegocio.UrlSitio;

                objCorreo.ParametrosPlantilla = parametros;

                return objCorreo.Enviar();
            }


            private static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, string mensaje, List<string> rutasAdjuntos, int timeout, IRutasFisicas rutasFisicas = null, params string[] parametros)
            {
                EnvioCorreos objCorreo = new EnvioCorreos();
                objCorreo.Para = destinatario;
                objCorreo.Asunto = asunto;
                objCorreo.TimeOut = timeout;
                rutasFisicas = CargarRutasFisicas(rutasFisicas);
                //if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]) && Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]))
                //{
                //    if (rutasAdjuntos != null)
                //        objCorreo.Adjuntos = rutasAdjuntos.ToArray();
                //}

                if (plantilla == PlantillasCorreo.Ninguna)
                {
                    objCorreo.Mensaje = mensaje;
                    objCorreo.ConPlantilla = false;
                }
                else
                {
                    objCorreo.ConPlantilla = true;
                    objCorreo.EsHtml = true;
                    string nombrePlantilla = string.Concat(plantilla.ToString(), ".txt");
                    objCorreo.RutaPlantilla = System.IO.Path.Combine(rutasFisicas.ObtenerRutaFisica() + "Plantillas", nombrePlantilla);
                    objCorreo.UrlSitio = ParametrizacionNegocio.UrlSitio;
                }

                objCorreo.ParametrosPlantilla = parametros;

                return objCorreo.Enviar();
            }


        }


        public enum PlantillasCorreo
        {
            Ninguna
        }

    
}
