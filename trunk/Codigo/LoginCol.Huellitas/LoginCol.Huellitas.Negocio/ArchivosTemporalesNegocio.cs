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
        private string CarpetaTemporal { get { return "TempFiles"; } }
        
        public ArchivosTemporalesNegocio()
        {

        }

        public ArchivosTemporalesNegocio(IRutasFisicas rutasFisicas ) : base(rutasFisicas)
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

            string ruta = System.IO.Path.Combine(this.RutaServidor, this.CarpetaTemporal, string.Concat(nuevaLLave, extension));

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
    }
}
