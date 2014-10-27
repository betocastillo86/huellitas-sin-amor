using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    /// <summary>
    /// Modelo que se muestra en el listado de los contenidos
    /// </summary>
    public class ContenidoListadoModel : ContenidoBaseModel
    {
        public int Visitas { get; set; }

        public int Comentarios { get; set; }

        public int Votos { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        [Display(Name = "Ciudad", Description = "Ciudad")]
        public int ZonaGeograficaId { get; set; }

        public string ZonaGeograficaNombre { get; set; }

        public List<ValorCampoModel> Campos { get; set; }

        public List<int> Imagenes { get; set; }
    }
}