using LoginCol.Huellitas.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [UniqueKey]
        [MaxLength(50)]
        public string Correo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        //[MaxLength(50)]
        public string Apellidos { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string  Clave { get; set; }

        [MaxLength(15)]
        public string NumeroDocumento { get; set; }

        public DateTime FechaRegistro { get; set; }

        public Nullable<DateTime> FechaActualizacion { get; set; }

        public bool Activo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public Nullable<DateTime> FechaNacimiento { get; set; }

        public virtual int Edad { get { return (int)((DateTime.Now - FechaNacimiento.Value).TotalDays / (double)365); } }

        public Nullable<int> OcupacionId { get; set; }

        public Nullable<int> EstadoCivilId { get; set; }

        public Nullable<int> ZonaGeograficaId { get; set; }

        public bool EsAdministrador { get; set; }

        public virtual List<Comentario> Comentarios { get; set; }

        public virtual List<Contenido> Contenidos { get; set; }

        public virtual List<UsuarioContenido> ContenidosRelacionados { get; set; }

        public virtual DatoTablaBasica EstadoCivil { get; set; }

        public virtual DatoTablaBasica Ocupacion { get; set; }

        public virtual List<FormularioAdopcion> FormulariosDeAdopcion { get; set; }

        public virtual ZonaGeografica ZonaGeografica { get; set; }


    }
}
