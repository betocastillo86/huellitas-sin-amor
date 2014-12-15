using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class BaseModel 
    {

        public BaseModel()
        {

        }

        public BaseModel(string llaveTitulo)
        {
            CargarTitulo(llaveTitulo);
        }

        public BaseModel(string llaveTitulo, params string[] parametros)
        {
            CargarTitulo(llaveTitulo, parametros);
        }

        public void CargarTitulo(string llaveTitulo)
        {
            this.Titulo = ParametrizacionNegocio.String(llaveTitulo);
        }

        public void CargarTitulo(string llaveTitulo, params string[] parametros)
        {
            this.Titulo = string.Format(ParametrizacionNegocio.String(llaveTitulo), parametros);
        }

        public int Id { get; set; }

        public bool OperacionExitosa { get; set; }

        public string MensajeError { get; set; }

        public string Titulo { get; set; }

        //public string TagDescripcion { get; set; }
    }
}