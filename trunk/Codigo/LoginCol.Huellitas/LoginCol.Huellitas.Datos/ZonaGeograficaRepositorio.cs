using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class ZonaGeograficaRepositorio : IRepositorio<ZonaGeografica>
    {

        public List<ZonaGeografica> Obtener(ZonaGeografica filtro)
        {
            List<ZonaGeografica> lista = new List<ZonaGeografica>();

            try
            {
                using (Repositorio db = new Repositorio())
                {
                    lista = db.ZonasGeograficas.Where(_ =>
                                            (filtro.ZonaGeograficaId == 0 || _.ZonaGeograficaId == filtro.ZonaGeograficaId) &&
                                            (filtro.ZonaGeograficaPadre.ZonaGeograficaId == 0 || _.ZonaGeograficaPadre.ZonaGeograficaId == filtro.ZonaGeograficaPadre.ZonaGeograficaId)).ToList();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }
            
            return lista;
        }

        public int Insertar(ZonaGeografica obj)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(ZonaGeografica obj)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        List<ZonaGeografica> IRepositorio<ZonaGeografica>.Obtener(ZonaGeografica filtro)
        {
            throw new NotImplementedException();
        }

        public ZonaGeografica Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public ZonaGeografica ObtenerPrimero(ZonaGeografica filtro)
        {
            throw new NotImplementedException();
        }
    }
}
