using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class FabricaNegocios
    {
        #region Correo
        private CorreoNegocio _Correo;

        public CorreoNegocio Correo
        {
            get {
                if (_Correo == null)
                    _Correo = new CorreoNegocio();
                return _Correo;
            }
        }

        #endregion

        #region Contenido
        private ContenidoNegocio _Contenido;

        public ContenidoNegocio Contenido
        {
            get
            {
                if (_Contenido == null)
                    _Contenido = new ContenidoNegocio();
                return _Contenido;
            }
        }

        #endregion

        #region FormularioAdopcion
        private FormularioAdopcionNegocio _FormularioAdopcion;

        public FormularioAdopcionNegocio FormularioAdopcion
        {
            get
            {
                if (_FormularioAdopcion == null)
                    _FormularioAdopcion = new FormularioAdopcionNegocio();
                return _FormularioAdopcion;
            }
        }

        #endregion

        #region Parametrizacion
        private ParametrizacionNegocio _Parametrizacion;

        public ParametrizacionNegocio Parametrizacion
        {
            get
            {
                if (_Parametrizacion == null)
                    _Parametrizacion = new ParametrizacionNegocio();
                return _Parametrizacion;
            }
        }
        #endregion
    }
}
