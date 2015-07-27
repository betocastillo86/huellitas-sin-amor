using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class AdopcionNegocio
    {
        private AdopcionRepositorio dAdopcion;
        
        public AdopcionNegocio()
        {
            dAdopcion = new AdopcionRepositorio();
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
    }
}
