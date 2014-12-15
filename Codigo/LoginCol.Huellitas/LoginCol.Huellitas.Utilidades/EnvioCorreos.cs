using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Utilidades
{
    public class EnvioCorreos
    {

        public bool EsHtml { get; set; }
        public string Para { get; set; }
        public bool ConPlantilla { get; set; }
        public string RutaPlantilla { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string UrlSitio { get; set; }
        //public Dictionary<string, string> ParametrosPlantilla { get; set; }
        public string[] ParametrosPlantilla { get; set; }
        //Listado de adjuntos disponibles
        public string[] Adjuntos { get; set; }

        public string Adjunto { get; set; }

        public int TimeOut { get; set; }

        /// <summary>
        /// Envia un correo electrónico con la clase System.Net.MailMessage
        /// </summary>
        /// <returns></returns>
        public bool Enviar()
        {
            try
            {
                MailMessage objCorreo = new MailMessage();

                objCorreo.To.Add(new MailAddress(Para));
                objCorreo.Subject = Asunto;
                objCorreo.IsBodyHtml = EsHtml;

                //Carga el cuerpo del mensaje
                objCorreo.Body = ObtenerMensaje();

                //Agrega los adjuntos si existen
                if (Adjuntos != null)
                {
                    foreach (string adjunto in Adjuntos)
                    {
                        objCorreo.Attachments.Add(new Attachment(adjunto));
                    }
                }

                //intenta enviar el correo
                SmtpClient client = new SmtpClient();
                if (TimeOut > 0)
                    client.Timeout = TimeOut;

                if (Convert.ToBoolean(ConfigurationManager.AppSettings["enviarCorreos"]))
                {
                    client.Send(objCorreo);
                }

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        /// <summary>
        /// Carga el cuerpo del mesaje dependiendo si es desde una plantilla o no
        /// </summary>
        /// <returns></returns>
        private string ObtenerMensaje()
        {
            if (ConPlantilla)
            {
                string plantilla = Archivos.CargarArchivoDeTexto(RutaPlantilla);
                //Se puede cambiar si la plantilla con el format presenta problemas
                //foreach (KeyValuePair<string, string> campo in ParametrosPlantilla)
                //{
                //    plantilla.Replace(campo.Key, campo.Value);
                //}
                Mensaje = string.Format(@plantilla, ParametrosPlantilla);

                //Carga la url del sitio para imagenes y links
                Mensaje = Mensaje.Replace("<<<<rutaSitio>>>>", UrlSitio);
            }

            return Mensaje;
        }

        public bool EnviarConAdjunto()
        {
            MailMessage objCorreo = new MailMessage();

            objCorreo.To.Add(new MailAddress(Para));
            objCorreo.Subject = Asunto;
            objCorreo.IsBodyHtml = EsHtml;

            //Carga el cuerpo del mensaje
            objCorreo.Body = ObtenerMensaje();
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(Adjunto);
            objCorreo.Attachments.Add(attachment);
            try
            {
                //intenta enviar el correo
                SmtpClient client = new SmtpClient();
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["enviarCorreos"]))
                {
                    client.Send(objCorreo);
                }

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

    }
}
