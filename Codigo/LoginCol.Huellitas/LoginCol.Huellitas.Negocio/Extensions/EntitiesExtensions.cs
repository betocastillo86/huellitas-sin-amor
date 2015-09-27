using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio.Extensions
{
    public static class EntitiesExtensions
    {
        /// <summary>
        /// Retorna la llave de confirmación con la 
        /// </summary>
        /// <returns></returns>
        public static string ObtenerLlaveDeConfirmacionSeguimientoAdopcion(this Adopcion adopcion)
        { 
            return Utilidades.Seguridad.MD5(string.Format("{0}{1}", adopcion.AdopcionId, adopcion.FormularioId));
        }

    }
}
