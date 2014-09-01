using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class TipoContenidoRepositorio : IRepositorio<TipoContenido>
    {

        public List<TipoContenido> Obtener(TipoContenido filtro)
        {
            List<TipoContenido> lista = new List<TipoContenido>();

            try
            {
                using (Repositorio db = new Repositorio())
                {
                   lista =  db.TiposContenidos.Where(_ =>
                                            (filtro.TipoContenidoId == 0 || _.TipoContenidoId == filtro.TipoContenidoId) &&
                                            (filtro.TipoContenidoPadre.TipoContenidoId == 0 || _.TipoContenidoPadre.TipoContenidoId == filtro.TipoContenidoPadre.TipoContenidoId)).ToList();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista;
        }

        public TipoContenido Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public TipoContenido ObtenerPrimero(TipoContenido filtro)
        {
            throw new NotImplementedException();
        }

        public int Insertar(TipoContenido obj)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(TipoContenido obj)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
