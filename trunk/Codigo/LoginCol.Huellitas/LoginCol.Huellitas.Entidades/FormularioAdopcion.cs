using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class FormularioAdopcion
    {
        public int FormularioAdopcionId { get; set; }

        public int ContenidoId { get; set; }

        public virtual Contenido Contenido { get; set; }

        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string Ocupacion { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string CorreoElectronico { get; set; }

        public string EstadoCivil { get; set; }

        public int MiembrosFamilia { get; set; }

        public string EdadesMiembros { get; set; }

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

        public DateTime FechaCreacion { get; set; }

    }
}
