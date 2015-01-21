using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class PerdidosModel : BaseModel
    {

        public PerdidosModel() : base("TituloPerdidos")
        {

        }

        public int ContenidoId { get; set; }
        
        public string Nombre { get; set; }

        
        public int Tipo { get; set; }
        
        
        public int Edad { get; set; }
        
        public int Genero { get; set; }
        
        public int Color { get; set; }
        
        public string ContactoNombre { get; set; }
        
        public string ContactoTelefono { get; set; }
        
        public string ContactoCorreo { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public string Imagen2 { get; set; }

        public int Raza { get; set; }

        /// <summary>
        /// Para esta sección solo aplican dos tipos de contenidos:
        /// AnimalesPerdidos
        /// AnimalesEncontrados
        /// </summary>
        public TipoContenidoEnum TipoContenidoId { get; set; }

        
        public int ZonaGeograficaId { get; set; }
    }
}