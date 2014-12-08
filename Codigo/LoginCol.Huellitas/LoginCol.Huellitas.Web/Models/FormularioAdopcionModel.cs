using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class FormularioAdopcionModel
    {

        public FormularioAdopcionModel()
        {
            Contenido = new ContenidoModel();
        }

        public ContenidoListadoModel HogarDePaso { get; set; }

        public ContenidoModel Contenido { get; set; }


        [Display(Description = "Nombre")]
        public string Nombre { get; set; }

        
        [Display(Description = "Edad")]
        public int Edad { get; set; }


        [Display(Description = "Ocupación")]
        public string Ocupacion { get; set; }


        [Display(Description = "Ciudad")]
        public string Ciudad { get; set; }


        [Display(Description = "Dirección")]
        public string Direccion { get; set; }


        [Display(Description = "Teléfono")]
        public string Telefono { get; set; }


        [Display(Description = "Celular")]
        public string Celular { get; set; }

        
        [Display(Description = "CorreoElectronico")]
        public string CorreoElectronico { get; set; }


        [Display(Description = "Número de Miembros de la Familia")]
        public int MiembrosFamilia { get; set; }


        [Display(Description = "Edades")]
        public string EdadesMiembrosFamilia { get; set; }


        [Display(Description="Estado Civil")]
        public string EstadoCivil { get; set; }
        

        public List<DatoTablaBasica> ListaEstadoCivil { get; set; }


        public string RespuestaPregunta1 { get; set; }

        public string RespuestaPregunta2 { get; set; }

        public string RespuestaPregunta3 { get; set; }

        public string RespuestaPregunta4 { get; set; }

        public string RespuestaPregunta5 { get; set; }
        
        public string RespuestaPregunta6 { get; set; }
        
        public string RespuestaPregunta7 { get; set; }
        
        public string RespuestaPregunta8 { get; set; }

        public string RespuestaPregunta9 { get; set; }

        public string RespuestaPregunta10 { get; set; }

        public string RespuestaPregunta11 { get; set; }

        public string RespuestaPregunta12 { get; set; }

        public string RespuestaPregunta13 { get; set; }

        public string RespuestaPregunta14 { get; set; }

        public string RespuestaPregunta15 { get; set; }

        public string RespuestaPregunta16 { get; set; }



    }
}