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
            try
            {
                List<ValorCampo> camposAdicionales = obj.Campos;

                using (var db = new Repositorio())
                {
                    obj.Campos = null;
                    db.Contenidos.Attach(obj);
                    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(obj, EntityState.Modified);
                    db.SaveChanges();
                    
                }

                GuardarCamposAdicionales(obj.ContenidoId, camposAdicionales);

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }   
        }

        private void GuardarCamposAdicionales(int id, List<ValorCampo> camposAdicionales)
        {
            List<ValorCampo> camposBD = ObtenerCampos(id);

            using (var db = new Repositorio())
            {
                foreach (var campo in camposAdicionales)
                {
                    ValorCampo campoBD = camposBD.Where(_ => _.CampoId == campo.CampoId).FirstOrDefault();

                    if (campoBD == null && !string.IsNullOrEmpty(campo.Valor))
                    {
                        
                        
                        db.ValoresCampos.Add(campo);
                        
                    }
                    else
                    {
                        campoBD.Valor = campo.Valor;

                        if (string.IsNullOrEmpty(campo.Valor))
                        {
                            db.ValoresCampos.Remove(campoBD);
                            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(campoBD, EntityState.Deleted);
                        }
                        else
                        {
                            db.ValoresCampos.Attach(campoBD);
                            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(campoBD, EntityState.Modified);
                        }
                    }
                }

                
                db.SaveChanges();
            }

           
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

        public int Crear(Contenido contenido)
        {
            try
            {
                contenido.FechaCreacion = DateTime.Now;

                using (var db = new Repositorio())
                {    
                    db.Contenidos.Add(contenido);
                    db.SaveChanges();
                }

                return contenido.ContenidoId;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return 0;
            }
        }

        public List<Contenido> ObtenerContenidosRelacionados(int idContenido, TipoRelacionEnum tipoRelacion)
        {
            
            
            try
            {

                List<ContenidoRelacionado> listaRelacionados = null;
                using (var db = new Repositorio())
                {
                    int tipoRelacionInt = Convert.ToInt32(tipoRelacion);

                    //lista = db.Contenidos
                    //    .Include(c => c.ContenidosRelacionados)
                    //    .Where(c => c.ContenidoId == idContenido )
                    //    .FirstOrDefault().ContenidosRelacionados.Where(_ => _.TipoRelacionContenidoId == tipoRelacionInt).ToList();


                    listaRelacionados = db.ContenidosRelacionados
                        .Include(c => c.ContenidoHijo)
                        .Include(c => c.ContenidoHijo.TipoContenido)
                        .Include(c => c.Contenido)
                        .Include(c => c.Contenido.TipoContenido)
                        .Where(c => (c.ContenidoHijoId == idContenido || c.ContenidoId == idContenido) && c.TipoRelacionContenidoId == tipoRelacionInt).ToList();

                    //lista = db.ContenidosRelacionados.Where(cr => cr.ContenidoId == idContenido).Select(_ => _.ContenidoHijo).ToList();

                    //lista = db.Contenidos
                    //    .Where(c => c.TipoContenido.TiposDeContenidosRelacionados.Where(tc => tc.TipoRelacionContenidoId == tipoRelacionInt).Count() > 0 
                    //        && c.ContenidoId == idContenido)
                    //    .ToList();
                }

                //Lista de contenidos relacionados extraidos de la consulta
                List<Contenido> listaContenidos = new List<Contenido>();
                listaRelacionados.ForEach(r => listaContenidos.Add(r.ContenidoId == idContenido ? r.ContenidoHijo : r.Contenido));
                return listaContenidos;

            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return new List<Contenido>();
            }

        }
    }
}
