using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace LoginCol.Huellitas.Datos
{
    public class ContenidoRepositorio : IRepositorio<Contenido>
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
                        .Include(_ => _.ZonaGeografica)
                        .Include(_ => _.ZonaGeografica.ZonaGeograficaPadre)
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
                        .Include(_ => _.ZonaGeografica)
                        .Include(_ => _.ZonaGeografica.ZonaGeograficaPadre)
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

        List<Contenido> IRepositorio<Contenido>.Obtener(Contenido filtro)
        {
            throw new NotImplementedException();
        }

        public Contenido Obtener(int id)
        {
            Contenido contenido = null;

            try
            {
                using (Repositorio db = new Repositorio())
                {
                    contenido = db.Contenidos
                                    .Include(_ => _.ZonaGeografica)
                                    .Include(_ => _.TipoContenido)
                                    .Include(_ => _.Campos.Select(c=> c.Campo))
                                    .Include(_ => _.ZonaGeografica.ZonaGeograficaPadre)
                                    .Where(_ => _.ContenidoId.Equals(id)).FirstOrDefault();

                }

            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return contenido == null ? new Contenido() : contenido;
        }


        public Contenido ObtenerPrimero(Contenido filtro)
        {
            throw new NotImplementedException();
        }

        public List<ValorCampo> ObtenerCampos(int contenidoId)
        {
            List<ValorCampo> campos = null;
            try
            {
                using (var db = new Repositorio())
                {
                   campos = db.ValoresCampos
                                .Include(_ => _.Campo)
                                .Where(_ => _.ContenidoId.Equals(contenidoId)).ToList();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return campos == null ? new List<ValorCampo>() : campos;
        }

        public Contenido ObtenerPorNombre(string nombre, bool quitarGuiones)
        {
            Contenido contenido = null;
            
            nombre = quitarGuiones ? nombre.Replace("-",string.Empty) : nombre;

            try
            {
                using (var db = new Repositorio())
                {
                    contenido = db.Contenidos
                        .Where(_ => _.Nombre.Equals(nombre)).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return contenido == null ? new Contenido() : contenido;
        }
    }
}
