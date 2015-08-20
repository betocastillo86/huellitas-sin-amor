using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class VistaContenidoRelacionadoModel
    {
        public string Titulo { get; set; }

        public bool VerTodos { get; set; }

        public string LinkVerTodos { get; set; }

        public List<ContenidoRelacionadoModel> Contenidos { get; set; }
    }
}