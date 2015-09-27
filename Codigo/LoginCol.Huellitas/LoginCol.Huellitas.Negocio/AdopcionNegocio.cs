using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class AdopcionNegocio
    {
        private AdopcionRepositorio dAdopcion;
        private ArchivosTemporalesNegocio nArchivosTemporales;
        
        public AdopcionNegocio()
        {
            dAdopcion = new AdopcionRepositorio();
            nArchivosTemporales = new ArchivosTemporalesNegocio();
        }

        

        public bool Crear(Adopcion adopcion)
        {
            try
            {
                return dAdopcion.Crear(adopcion);
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
            
        }

        /// <summary>
        /// Retorna una adopcion por el id
        /// </summary>
        /// <param name="idAdopcion"></param>
        /// <returns></returns>
        public Adopcion Obtener(int idAdopcion)
        {
            try
            {
                return dAdopcion.Obtener(idAdopcion);
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return null;
            }
        }

        public List<Adopcion> Obtener()
        {
            try
            {
                return dAdopcion.Obtener();
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return new List<Adopcion>();
            }
        }

        public List<SeguimientoAdopcion> ObtenerSeguimientosPorAdopcion(int idAdopcion)
        {
            try
            {
                return dAdopcion.ObtenerSeguimientosPorAdopcion(idAdopcion);
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return new List<SeguimientoAdopcion>();
            }
        }


        public bool CrearSeguimiento(int idAdopcion, string observaciones, string imagenTemp1, string imagenTemp2)
        {
            var seguimiento = new SeguimientoAdopcion();
            seguimiento.AdopcionId = idAdopcion;
            seguimiento.Observaciones = observaciones;
            seguimiento.FechaRespuesta = DateTime.Now;
            seguimiento.Imagen1 = !string.IsNullOrEmpty(imagenTemp1);
            seguimiento.Imagen2 = !string.IsNullOrEmpty(imagenTemp2);

           //intenta guardar el seguimiento
            dAdopcion.CrearSeguimiento(seguimiento);

            if (seguimiento.SeguimientoAdopcionId > 0)
            {

                try
                {
                    ///Guarda el archivo temporal con la ruta de la imagen principal
                    if (seguimiento.Imagen1)
                        GuardarImagenSeguimiento(nArchivosTemporales.ObtenerRutaArchivoTemporal(imagenTemp1), seguimiento.SeguimientoAdopcionId, 1);

                    if (seguimiento.Imagen2)
                        GuardarImagenSeguimiento(nArchivosTemporales.ObtenerRutaArchivoTemporal(imagenTemp2), seguimiento.SeguimientoAdopcionId, 2);
                }
                catch (Exception e)
                {
                    this.dAdopcion.EliminarSeguimiento(seguimiento.SeguimientoAdopcionId);
                    throw new Exception("No fue posible eliminar imagen");
                }
                return true;
            }
            else
            {
                return false;
            }
            
           

        }

        /// <summary>
        /// Mueve el archivo temporal a un nuevo lugar con la carpeta del seguimiento
        /// num
        /// </summary>
        /// <param name="ruta">Ruta del archivo</param>"
        /// <param name="seguimientoId"></param>
        /// <param name="numImagen">Numero de la imagne que se va guardar</param>
        /// <returns></returns>
        private void GuardarImagenSeguimiento(string ruta, int seguimientoId, int numImagen)
        {
            string carpeta = string.Format(@"{0}\{1}", nArchivosTemporales.CarpetaSeguimiento, seguimientoId);
            if (!System.IO.Directory.Exists(carpeta))
                System.IO.Directory.CreateDirectory(carpeta);

            //Mueve la imagen a la nueva ruta
            System.IO.File.Move(ruta, string.Format(@"{0}\{1}.jpg", carpeta, numImagen));
        }

    }
}
