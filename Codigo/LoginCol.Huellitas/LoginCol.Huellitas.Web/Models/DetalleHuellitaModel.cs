using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class DetalleHuellitaModel : ContenidoModel
    {
        

        public ContenidoListadoModel HogarDePaso { get; set; }

        public UsuarioBaseModel AdoptantePadrino { get; set; }

        public TipoRelacionUsuariosEnum TipoAdoptante { get; set; }

    }
}