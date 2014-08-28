using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace LoginCol.Huellitas.Datos
{
    public class ContenidosRepositorio : IRepositorio<Contenido>
    {
        

        public Contenido Obtener(Contenido filtro)
        {
            throw new NotImplementedException();
        }

        public int Insertar(Contenido obj)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(Contenido obj)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contenido> ObtenerPorTipo(TipoContenidoEnum tipoContenido)
        {
            List<Contenido> lista = new List<Contenido>();

            try
            {
                using (var db = new Repositorio())
                {
                    lista = db.Contenidos
                        .Include(_ => _.TipoContenido)
                        .Where(c => c.TipoContenido.TipoContenidoId == (int)tipoContenido)
                        .ToList();
                }

            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista;
        }


        public List<Contenido> ObtenerPorTipoPadre(TipoContenidoEnum tipoContenido)
        {
            List<Contenido> lista = new List<Contenido>();

            try
            {
             
                using (var db = new Repositorio())
                {
                    lista = db.Contenidos
                        .Include(_ => _.TipoContenido)
                        .Where(c => c.TipoContenido.TipoContenidoPadre.TipoContenidoId == (int)tipoContenido)
                        .ToList();
                }

            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista;
        }
    }
}
