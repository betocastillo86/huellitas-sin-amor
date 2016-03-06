using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class CrearHuellitaModel : BaseModel
    {

        public CrearHuellitaModel()
            : base("TituloCrearHuellita")
        {

        }

        public int ContenidoId { get; set; }
        
        
        public string Nombre { get; set; }

        public TipoContenidoEnum Tipo { get; set; }
        
        public string Edad { get; set; }
        
        public int Genero { get; set; }
        
        public int Color { get; set; }
        
        public string ContactoNombre { get; set; }
        
        public string ContactoTelefono { get; set; }
        
        public string ContactoCorreo { get; set; }
        
        public string Descripcion { get; set; }
        
        public List<string> Imagen { get; set; }
        
        public int ZonaGeograficaId { get; set; }
    }
}