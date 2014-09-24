﻿using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginCol.Huellitas.Web.Models
{
    public class ContenidoModel : ContenidoBaseModel
    {
        public int Visitas { get; set; }

        public int Comentarios { get; set; }

        public int Votos { get; set; }

        public decimal PromedioVotos { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public List<TipoContenido> TiposDeContenido { get; set; }

        public int MeGusta { get; set; }

        public int Compartidos { get; set; }

        [MaxLength(20)]
        [Display(Name = "Imagen principal", Description = "Imagen principal")]
        public string Imagen { get; set; }

        #region Contacto
        [Required(ErrorMessage = "El Departamento es obligatorio")]
        [Display(Name = "Departamento", Description = "Departamento")]
        public List<ZonaGeografica> Departamentos { get; set; }
        
        [Display(Name = "Ciudad", Description = "Ciudad")]
        public int ZonaGeograficaId { get; set; }

        public int ZonaGeograficaZonaGeograficaPadreZonaGeograficaId { get; set; }


        public List<ValorCampoModel> Campos { get; set; }

        //public string Direccion { get; set; }

        //public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [Display(Name = "Correo electrónico", Description = "Correo electrónico")]
        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        #endregion

        public int UsuarioId { get; set; }

        public List<TipoRelacionContenido> TiposRelacionContenido { get; set; }

    }
}