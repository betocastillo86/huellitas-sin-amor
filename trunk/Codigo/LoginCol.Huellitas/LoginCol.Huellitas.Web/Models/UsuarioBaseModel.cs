using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class UsuarioBaseModel
    {

        public int UsuarioId { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NombreCompleto { get { return string.Format("{0} {1}", Nombres, Apellidos); } }
    }
}