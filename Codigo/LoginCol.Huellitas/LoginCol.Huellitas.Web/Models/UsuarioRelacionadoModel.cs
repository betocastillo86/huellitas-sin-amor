using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class UsuarioRelacionadoModel
    {
        public int UsuarioContenidoId { get; set; }

        public ContenidoBaseModel Contenido { get; set; }

        public UsuarioModel  Usuario { get; set; }

        public int TipoRelacionId { get; set; }
    }
}