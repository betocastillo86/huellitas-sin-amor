using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Contenido
    {
        public int ContenidoId { get; set; }


        [NotMapped]
        public string NombreLink { get { return string.IsNullOrEmpty(Nombre) ? string.Empty : Nombre.Replace(" ", "-"); } }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(130)]
        public string DescripcionCorta { get; set; }

        public string Descripcion { get; set; }

        public int Visitas { get; set; }

        public int Comentarios { get; set; }

        public int Votos { get; set; }

        public decimal PromedioVotos { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Nullable<DateTime> FechaActualizacion { get; set; }

        public Nullable<DateTime> FechaPublicacion { get; set; }

        public int TipoContenidoId { get; set; }

        public virtual TipoContenido TipoContenido { get; set; }

        public int MeGusta { get; set; }

        public int Compartidos { get; set; }
        
        [MaxLength(50)]
        public string Imagen { get; set; }

        #region Contacto
        public int ZonaGeograficaId { get; set; }

        public virtual ZonaGeografica ZonaGeografica { get; set; }

        //public string Direccion { get; set; }

        //public string Telefono { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        //public decimal Latitud { get; set; }

        //public decimal Longitud { get; set; }

        #endregion

        public virtual List<ValorCampo> Campos { get; set; }

        public virtual List<ContenidoRelacionado> ContenidosRelacionados { get; set; }

        public virtual List<ContenidoRelacionado> ContenidosRelacionadosPadre { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public bool Activo { get; set; }

        [DefaultValue(false)]
        public bool Eliminado { get; set; }

        public virtual List<FormularioAdopcion> FormularioAdoptantes { get; set; }
         
        
        public string UrlVideo { get; set; }

        public bool Destacado { get; set; }

        public virtual List<UsuarioContenido> UsuariosRelacionados { get; set; }

    }
}
