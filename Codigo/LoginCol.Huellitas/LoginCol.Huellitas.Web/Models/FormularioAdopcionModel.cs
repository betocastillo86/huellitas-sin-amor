using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class FormularioAdopcionModel  : BaseModel
    {

        public FormularioAdopcionModel()
        {
            Contenido = new ContenidoModel();
        }

        public int FormularioAdopcionId { get; set; }

        public ContenidoListadoModel HogarDePaso { get; set; }

        public ContenidoModel Contenido { get; set; }

        public UsuarioModel Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        [Range(1,10)]
        [Display(Description="Miembros de la familia")]
        public int? MiembrosFamilia { get; set; }

        [Required]
        [Display(Description = "Edades")]
        public string EdadesMiembrosFamilia { get; set; }

        public List<RespuestaAdopcion> Respuestas { get; set; }

        public List<DatoTablaBasica> ListaEstadoCivil { get; set; }

        public List<DatoTablaBasica> ListaOcupaciones { get; set; }

        public List<DatoTablaBasica> Preguntas { get; set; }


    }
}