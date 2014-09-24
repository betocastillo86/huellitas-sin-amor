using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LoginCol.Huellitas.Datos
{
    public class TipoContenidoRepositorio : IRepositorio<TipoContenido>
    {

        public List<TipoContenido> Obtener(TipoContenido filtro)
        {
            List<TipoContenido> lista = new List<TipoContenido>();

            try
            {
                filtro.TipoContenidoPadre = filtro.TipoContenidoPadre == null ? new TipoContenido() : filtro.TipoContenidoPadre;

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
            TipoContenido obj = new TipoContenido();

            try
            {
                using (Repositorio db = new Repositorio())
                {
                    obj = db.TiposContenidos
                        .Include(_ => _.Campos.Select(c => c.Campo))
                        .Include(_ => _.Campos.Select(c => c.Campo).Select(c => c.Opciones))
                        .Where(_ => _.TipoContenidoId == id)
                        .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return obj;
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

        public List<Campo> ObtenerCampos(int id)
        {
            List<Campo> lista = null;
            try
            {
                using (var db = new Repositorio())
                {
                   lista = db.Campos
                       .Include(_ => _.TiposContenidos.Where(t => t.TipoContenidoId == id))
                       .Include(_ => _.Opciones)
                       .ToList();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista == null ? new List<Campo>() : lista;
        }

        public List<TipoRelacionContenido> ObtenerTiposDeRelacionContenido(int id)
        {
            List<TipoRelacionContenido> lista = null;
            try
            {
                using (var db = new Repositorio())
                {
                    lista = db.TiposDeRelacionPorTiposDeContenidos
                        .Where(t => t.TipoContenidoId == id)
                        .Select(t => t.TipoRelacionContenido).ToList();


                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista == null ? new List<TipoRelacionContenido>() : lista;
        }


    }
}
