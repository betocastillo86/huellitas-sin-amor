using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Admin
{
    public class ListarContenidoModel
    {
        public ListarContenidoModel()
        {
            PrefijoAcciones = "contenidos";
            Contenido = new ContenidoModel();
        }
        public string PrefijoAcciones { get; set; }

        public string Titulo { get; set; }

        public ContenidoModel Contenido { get; set; }
    }
}