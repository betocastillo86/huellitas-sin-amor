using LoginCol.Huellitas.Negocio.Directorios;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class ArchivosTemporalesNegocio : NegocioBase
    {
        private string CarpetaTemporal { get { return Path.Combine(this.RutaServidor, "TempFiles"); } }

        public ArchivosTemporalesNegocio()
        {

        }

        public ArchivosTemporalesNegocio(IRutasFisicas rutasFisicas)
            : base(rutasFisicas)
        {

        }

        /// <summary>
        /// Guarda un archivo temporal en el sistema y retorna la llave para ser recogido despues
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public ResultadoOperacion GuardarArchivoTemporal(byte[] archivo, string extension)
        {
            string nuevaLLave = Guid.NewGuid().ToString();

            string ruta = System.IO.Path.Combine(this.CarpetaTemporal, string.Concat(nuevaLLave, extension));

            //Si el archivo ya existe se intenta crear uno nuevo
            if (!File.Exists(ruta))
            {
                var respuesta = new ResultadoOperacion();

                if (Archivos.GuardarArchivoEnDisco(ruta, archivo, false))
                {
                    respuesta.InformacionAdicional = nuevaLLave;
                    respuesta.OperacionExitosa = true;
                }
                else
                {
                    respuesta.OperacionExitosa = false;
                    respuesta.MensajeError = "Error guardando la imagen en disco";
                }

                return respuesta;
            }
            else
            {
                return GuardarArchivoTemporal(archivo, extension);
            }
        }

        /// <summary>
        /// Retorna los bytes de un archivo que se ha guardado temporalmente
        /// </summary>
        /// <param name="llave"></param>
        /// <returns></returns>
        public byte[] ObtenerArchivoTemporal(string llave)
        {

            try
            {
                var rutaArchivo = System.IO.Directory.GetFiles(this.CarpetaTemporal).FirstOrDefault(a => a.Contains(llave));
                return System.IO.File.ReadAllBytes(rutaArchivo);
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return null;
            }

        }

        public void EliminarArchivoTemporal(string llave)
        {
            var rutaArchivo = System.IO.Directory.GetFiles(this.CarpetaTemporal).FirstOrDefault(a => a.Contains(llave));
            System.IO.File.Delete(rutaArchivo);
        }

        public static string ObtenerPathArchivo(IRutasFisicas rutasFisicas, string archivo)
        {
            return string.Format("{0}/{1}/{2}", rutasFisicas.ObtenerRutaFisica(), archivo);
        }
    }
}
