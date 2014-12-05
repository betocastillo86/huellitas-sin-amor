using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ListarHuellitasModel
    {
        public List<OpcionCampoModel> Colores { get; set; }

        public List<OpcionCampoModel> Tamanos { get; set; }

        public List<OpcionCampoModel> Generos { get; set; }

        public List<OpcionCampoModel> RecomendadoPara { get; set; }

        public List<ContenidoBaseModel> Fundaciones { get; set; }


    }
}