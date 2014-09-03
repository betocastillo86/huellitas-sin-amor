using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginCol.Huellitas.Web.Models
{
    public class ContenidoModel
    {
        public int ContenidoId { get; set; }

        [Required(ErrorMessage="El nombre es obligatorio")]
        [MaxLength(50)]
        [Display(Name="Nombre", Description="Nombre del contenido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="La descripción es obligatoria")]
        [Display(Name="Descripción", Description="Descripción del contenido")]
        public string Descripcion { get; set; }

        public int Visitas { get; set; }

        public int Comentarios { get; set; }

        public int Votos { get; set; }

        public decimal PromedioVotos { get; set; }

        [Display(Name = "Fecha de Creación", Description = "Fecha de creación del contenido")]
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public DateTime? FechaPublicacion { get; set; }


        public List<TipoContenido> TiposDeContenido { get; set; }
        public int TipoContenidoId { get; set; }

        public string TipoContenidoNombre { get; set; }

        public int MeGusta { get; set; }

        public int Compartidos { get; set; }

        [MaxLength(20)]
        public string Imagen { get; set; }

        #region Contacto
        public List<ZonaGeografica> Departamentos { get; set; } 
        public int ZonaGeograficaId { get; set; }

        public int ZonaGeograficaZonaGeograficaPadreZonaGeograficaId { get; set; }


        public List<ValorCampoModel> Campos { get; set; }

        //public string Direccion { get; set; }

        //public string Telefono { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        #endregion

        public int UsuarioId { get; set; }

        public bool Activo { get; set; }

    }
}