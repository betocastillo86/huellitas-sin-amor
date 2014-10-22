using LoginCol.Huellitas.Datos;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class CampoNegocio : NegocioBase
    {
        private Lazy<CampoRepositorio> _repositorio { get; set; }

        protected CampoRepositorio Repositorio { get { return _repositorio.Value; } }

        public CampoNegocio()
            : base()
        {
            _repositorio = new Lazy<CampoRepositorio>(false);
        }

        public Campo Obtener(int idCampo)
        {
            return Repositorio.Obtener(idCampo);
        }
    }
}
