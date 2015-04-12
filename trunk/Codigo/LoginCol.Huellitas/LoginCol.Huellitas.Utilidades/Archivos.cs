using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Utilidades
{
    public class Archivos
    {
        ///// <summary>
        ///// Valida que ningúno de los archivos se pase del tamaño máximo enviado en el request
        ///// </summary>
        ///// <param name="archivos">listado de archivos</param>
        ///// <param name="kbMaximos">tamaño máximo en Kilobytes enviado</param>
        ///// <returns></returns>
        //public static bool EsTamanoValidoArchivos(IEnumerable<HttpPostedFileBase> archivos, int kbMaximos)
        //{
        //    foreach (HttpPostedFileBase archivo in archivos)
        //    {
        //        if (archivo != null && archivo.ContentLength > (kbMaximos * 1000))
        //            return false;
        //    }

        //    return true;
        //}




        ///// <summary>
        ///// Convierte los archivos
        ///// </summary>
        ///// <param name="archivos"></param>
        ///// <returns></returns>
        //public static List<byte[]> ConvertirPostedFileABytes(IEnumerable<HttpPostedFileBase> archivos)
        //{
        //    List<byte[]> listaArchivos = new List<byte[]>();

        //    foreach (HttpPostedFileBase archivo in archivos)
        //    {
        //        if (archivo != null)
        //        {
        //            listaArchivos.Add(ConvertirStreamABytes(archivo.InputStream));
        //        }
        //        else
        //            listaArchivos.Add(null);
        //    }

        //    return listaArchivos;
        //}

        /// <summary>
        /// Contierte un objeto tipo stream a bytes
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static byte[] ConvertirStreamABytes(Stream datos)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = datos.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }





        /// <summary>
        /// Guarda los bytes fisicamente en el servidor
        /// </summary>
        /// <param name="nombreArchivo">ruta completa del archivo que se desea guardar</param>
        /// <param name="datos">datos en bytes del archivo que se desea guardar</param>
        /// <returns>true : archivo Guardado</returns>
        public static bool GuardarArchivoEnDisco(string nombreArchivo, byte[] datos, bool hacerBackup)
        {
            try
            {
                string carpeta = Directory.GetParent(nombreArchivo).FullName;
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);    
                }

                //Si se debe hacer backup lo marca nuevamente con la fecha de la eliminación
                if (hacerBackup && File.Exists(nombreArchivo))
                {
                    RealizarBackupArchivo(nombreArchivo);
                }

                using (System.IO.FileStream stream = new System.IO.FileStream(nombreArchivo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    stream.Write(datos, 0, datos.Length);
                    stream.Close();
                }
                
                
                
                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        public static void RealizarBackupArchivo(string nombreArchivo)
        {
            string carpeta = Directory.GetParent(nombreArchivo).FullName;
            string extension = Path.GetExtension(nombreArchivo);
            string nuevoArchivo = string.Format("{0}\\{1}{2}{3}", carpeta, Path.GetFileName(nombreArchivo).Replace(extension, string.Empty), DateTime.Now.ToString("yyyyMMddhhmmss"), extension);
            File.Copy(nombreArchivo, nuevoArchivo);
        }


        public static string CargarArchivoDeTexto(string archivo)
        {
            string texto = string.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    texto = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return texto;
        }

        /// <summary>
        /// Retorna la cabecera dependiendo el tipo de archivo
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static string ObtenerCabeceraPorTipoDeArchivo(string nombreArchivo)
        {
            string extension = Path.GetExtension(nombreArchivo);
            switch (extension)
            {
                case ".docx":
                case ".doc":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".pdf":
                    return "application/pdf";
                default:
                    return "application/pdf";
            }
        }
    }
}
