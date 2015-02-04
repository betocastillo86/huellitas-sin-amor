using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginCol.Huellitas.Web.Models
{
    public class ContenidoModel : ContenidoListadoModel
    {
        

        public decimal PromedioVotos { get; set; }

        

        public List<TipoContenido> TiposDeContenido { get; set; }

        public int MeGusta { get; set; }

        public int Compartidos { get; set; }

        [MaxLength(50)]
        [Display(Name = "Imagen principal", Description = "Imagen principal")]
        public string Imagen { get; set; }

        #region Contacto
        [Required(ErrorMessage = "El Departamento es obligatorio")]
        [Display(Name = "Departamento", Description = "Departamento")]
        public List<ZonaGeografica> Departamentos { get; set; }
        
        public int ZonaGeograficaZonaGeograficaPadreZonaGeograficaId { get; set; }

        public string ZonaGeograficaZonaGeograficaPadreNombre { get; set; }

        //public string Direccion { get; set; }

        //public string Telefono { get; set; }
        [Display(Name = "Correo electrónico", Description = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        #endregion

        public int UsuarioId { get; set; }

        public List<TipoRelacionContenido> TiposRelacionContenido { get; set; }

        public List<TipoRelacion> TiposRelacionUsuario { get; set; }

        [MaxLength(100)]
        public string UrlVideo { get; set; }

        public List<UsuarioModel> Usuarios { get; set; }

        
    }
}