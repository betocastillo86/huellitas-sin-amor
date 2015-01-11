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

        /// <summary>
        /// Guarda la información de los campos adicionales
        /// </summary>
        /// <param name="id"></param>
        /// <param name="camposAdicionales"></param>
        /// <returns></returns>
        private bool GuardarCamposAdicionales(int id, List<ValorCampo> camposAdicionales)
        {

            try
            {
                List<ValorCampo> camposBD = ObtenerCampos(id);
                
                using (var db = new Repositorio())
                {
                    //Se deben eliminar todas las opciones de campo multiple para poder ser insertadas de nuevo
                    db.ValoresCampos.RemoveRange(db.ValoresCampos.Where(_ => _.Campo.TipoDato == TipoDatoCampo.Multiple && _.ContenidoId == id));
                    
                    //db.SaveChanges();

                    foreach (var campo in camposAdicionales)
                    {
                        ValorCampo campoBD = camposBD.Where(_ => _.CampoId == campo.CampoId && _.Campo.TipoDato != TipoDatoCampo.Multiple).FirstOrDefault();

                        //Si el campo no existe en Base de datos lo agrega
                        if (campoBD == null)
                        {

                            //solo cuando el valor es diferente de vacio
                            if (!string.IsNullOrEmpty(campo.Valor))
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

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var db = new Repositorio())
                {
                    Contenido contenidoEliminar = db.Contenidos.Where(c => c.ContenidoId == id).FirstOrDefault();
                    contenidoEliminar.Eliminado = true;
                    db.Contenidos.Attach(contenidoEliminar);
                    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(contenidoEliminar, EntityState.Modified);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        public List<Contenido> ObtenerPorTipo(int idTipoContenido)
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
                        .Where(c => c.TipoContenido.TipoContenidoId == idTipoContenido && !c.Eliminado)
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
                        .Where(c => c.TipoContenido.TipoContenidoPadre.TipoContenidoId == (int)tipoContenido && !c.Eliminado)
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
                                    .Include(_ => _.Campos.Select(c => c.Campo.Opciones))
                                    .Include(_ => _.ZonaGeografica.ZonaGeograficaPadre)
                                    .Where(_ => _.ContenidoId.Equals(id) && !_.Eliminado).FirstOrDefault();

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

        public List<ContenidoRelacionado> ObtenerContenidosRelacionados(int idContenido, int? tipoRelacion, bool cargarCampos)
        {
            try
            {

                List<ContenidoRelacionado> listaRelacionados = null;
                using (var db = new Repositorio())
                {
                    

                    var query  = db.ContenidosRelacionados
                        .Include(c => c.ContenidoHijo)
                        .Include(c => c.ContenidoHijo.TipoContenido)
                        .Include(c => c.ContenidoHijo.ZonaGeografica)
                        .Include(c => c.Contenido)
                        .Include(c => c.Contenido.TipoContenido)
                        .Where(c => (c.ContenidoHijoId == idContenido || c.ContenidoId == idContenido) && !c.ContenidoHijo.Eliminado && !c.Contenido.Eliminado);


                    if (tipoRelacion.HasValue)
                        query = query.Where(c => c.TipoRelacionContenidoId == tipoRelacion.Value);
                    
                    if(cargarCampos)
                        query = query
                            .Include(c => c.ContenidoHijo.Campos)
                            .Include(c => c.ContenidoHijo.Campos.Select( ca => ca.Campo))
                            .Include(c => c.ContenidoHijo.Campos.Select( ca => ca.Campo.Opciones));
                    
                    listaRelacionados = query.ToList();
                }

                //Iguala todos los contenidos hijos como los relacionados
                listaRelacionados.ForEach(r =>  r.ContenidoHijo = (r.ContenidoId == idContenido ? r.ContenidoHijo : r.Contenido));
                return listaRelacionados;

            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return new List<ContenidoRelacionado>();
            }

        }


        public bool AgregarContenidoRelacionado(ContenidoRelacionado contenidoRelacionado)
        {
            try
            {
                using (var db = new Repositorio())
                {
                    contenidoRelacionado.FechaCreacion = DateTime.Now;
                    db.ContenidosRelacionados.Add(contenidoRelacionado);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        public ContenidoRelacionado ObtenerContenidoRelacionado(int idContenido, int idContenidoHijo, int idTipoRelacion)
        {
            ContenidoRelacionado relacion = null;
            
            try
            {
                using (var db = new Repositorio())
                {
                    relacion = db.ContenidosRelacionados
                        .Include(c => c.ContenidoHijo)
                        .Include(c => c.ContenidoHijo.TipoContenido)
                        .Include(c => c.Contenido)
                        .Include(c => c.Contenido.TipoContenido)
                        .Where(c => c.ContenidoHijoId == idContenidoHijo && c.ContenidoId == idContenido && c.TipoRelacionContenidoId == idTipoRelacion && !c.ContenidoHijo.Eliminado && !c.Contenido.Eliminado).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return relacion == null ? new ContenidoRelacionado() : relacion;
        }

        public bool EliminarContenidoRelacionado(int idContenidoRelacionado)
        {
            try
            {
                using (var db = new Repositorio())
                {
                    ContenidoRelacionado contenidoRelacionado = db.ContenidosRelacionados.Where(c => c.ContenidoRelacionadoId.Equals(idContenidoRelacionado)).FirstOrDefault();
                    db.ContenidosRelacionados.Remove(contenidoRelacionado);
                    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(contenidoRelacionado, EntityState.Deleted);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        /// <summary>
        /// Realiza el filtro de contenidos de acuerdo a los paramentros enviados en el camposFiltros
        /// </summary>
        /// <param name="idTipoContenido">id del tipo de contenido por el que se debe filtrar inicialmente</param>
        /// <param name="esPadre">true: Busca los contenidos por el tipo Padre false: Busca los contenidos por el mismo tipo</param>
        /// <param name="camposFiltros">listado de campos y valores de los filtros</param>
        /// <param name="filtroBase">Filtros adicionales que van ligados al contenido</param>
        /// <returns>Listado de contenidos encontrados de acuerdo a la busqueda</returns>
        /// <param name="contenidosRelacionados">Contenidos relacionados por los que se debe filtrar. Propiedades: IDContenido  y TipoRelacion</param>
        public List<Contenido> FiltrarContenidos(int idTipoContenido, bool esPadre, Contenido filtroBase,  List<FiltroContenido> camposFiltros = null, List<ContenidoRelacionado> contenidosRelacionados = null)
        {
            List<Contenido> lista = null;
            try
            {
                using (var db = new Repositorio())
                {

                    //Listado de contenidos que aplican a los filtros por campo
                    List<int> contenidosPorFiltro = new List<int>();
                    
                    //Consulta los contenidos que posiblemente cumplen con el filtro de campos
                    if (camposFiltros != null && camposFiltros.Count > 0)
                    {
                        StringBuilder consulta = new StringBuilder();
                        consulta.AppendLine("SELECT ContenidoId FROM (");
                            consulta.AppendLine("SELECT count(ContenidoId) as cantidad, ContenidoId");
                            consulta.AppendLine(" FROM ValorCampo");
                            consulta.AppendLine( "WHERE");
                            int contarCondiciones = 0;
                            //Cuenta las opciones adicionales incluidas cuando se hace una busqueda multiple
                            int contarOpcionesAdicionales = 0;
                            foreach (var campo in camposFiltros)
                            {
                                if (contarCondiciones > 0)
                                    consulta.Append(" or ");

                                switch (campo.TipoFiltro)
                                {
                                    case TipoFiltroContenidoEnum.Igual:
                                    default:
                                        consulta.AppendFormat(" (CampoId = {0} and Valor = '{1}')", campo.CampoId, campo.Valor);
                                        break;
                                    case TipoFiltroContenidoEnum.Rango:
                                        consulta.AppendFormat(" (CampoId = {0} and Valor between '{1}' and '{2}')", campo.CampoId, campo.Valor, campo.ValorHasta);
                                        break;
                                    case TipoFiltroContenidoEnum.MultipleOpcion:
                                        int contarOpciones = 0;

                                        consulta.Append("(");
                                        //Toma cada una de las opciones y las agrega al filtro
                                        foreach (var opcion in campo.Valor.Split(new char[]{','}))
                                        {
                                            if (contarOpciones > 0) consulta.Append(" or ");
                                            consulta.AppendFormat(" (CampoId = {0} and Valor = '{1}')", campo.CampoId, opcion);
                                            contarOpciones++;
                                        }
                                        //Suma la cantidad de opciones adicionales para poder coincidir el final de busquedas con el mismo numero de criterios
                                        contarOpcionesAdicionales += contarOpciones - 1;
                                        consulta.Append(")");
                                        break;
                                }

                                contarCondiciones++;
                            }
                            consulta.AppendLine(" GROUP BY ContenidoId");

                            consulta.AppendFormat(") as f where	f.cantidad = {0}", camposFiltros.Count + contarOpcionesAdicionales);

                        List<object> paramsQuery = new List<object>();
                        contenidosPorFiltro = db.Database.SqlQuery<int>(consulta.ToString(), paramsQuery.ToArray()).ToList().ToList();
                    }

                    //Inicia consulta de los detalles de los contenidos
                    var query = db.Contenidos
                        .Include(c => c.TipoContenido)
                        .Include(c => c.TipoContenido.TipoContenidoPadre)
                        .Include(c=> c.ZonaGeografica)
                        .Include(c => c.ContenidosRelacionados)
                        .Include(c => c.Campos.Select(v => v.Campo))
                        .Where(c => c.Activo);

                    if (contenidosRelacionados != null)
                    {
                        //Recorre todos los contenidos relacionados y realiza el filtro sobre ellos
                        foreach (var relacionado in contenidosRelacionados)
                        {
                            query = query
                                .Where(c => c.ContenidosRelacionados
                                    .Where(cr => cr.ContenidoHijoId == relacionado.ContenidoId).Count() > 0);
                        }
                    }
                    

                    //Si no hay filtros seleccionados no realiza el filtro 
                    if(camposFiltros != null && camposFiltros.Count > 0)
                        query = query.Where(c => contenidosPorFiltro.Contains(c.ContenidoId)) ;

                    //Si es padre consulta por el tipo de contenido padre
                    if(esPadre)
                        query = query.Where(c=> c.TipoContenido.TipoContenidoPadre.TipoContenidoId == idTipoContenido);
                    else
                        query = query.Where(c=> c.TipoContenidoId == idTipoContenido);


                    if (filtroBase != null)
                    {
                        //agrega los filtros base
                        if (filtroBase.ZonaGeograficaId > 0)
                            query = query.Where(c => c.ZonaGeograficaId == filtroBase.ZonaGeograficaId);

                        if (filtroBase.ZonaGeografica != null && filtroBase.ZonaGeografica.ZonaGeograficaPadre != null && filtroBase.ZonaGeografica.ZonaGeograficaPadre.ZonaGeograficaId > 0)
                            query = query.Where(c => c.ZonaGeografica.ZonaGeograficaPadre.ZonaGeograficaId == filtroBase.ZonaGeografica.ZonaGeograficaPadre.ZonaGeograficaId);

                        if (!string.IsNullOrEmpty(filtroBase.Nombre))
                            query = query.Where(c => c.Nombre.Contains(filtroBase.Nombre));
                    }

                    

                    

                    lista = query.ToList();

                    //carga las imagenes del contenido
                    //lista.ForEach(c => c.ContenidosRelacionados = ObtenerContenidosRelacionados(c.ContenidoId, (int)TipoRelacionEnum.Imagen));
                    
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista == null ? new List<Contenido>() : lista;
        }


        public List<Contenido> FiltrarContenidosSp()
        {
            using (var db = new Repositorio())
            {
                var x = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this)
                    .ObjectContext
                    .CreateQuery<Contenido>("spObtenerContenidos", new List<System.Data.Entity.Core.Objects.ObjectParameter>().ToArray());
                
                
                //var x = db.Database.SqlQuery<Contenido>("spObtenerContenidos", new List<object>().ToArray());
                string a = "";
            }

            return null;
        }

        /// <summary>
        /// Suma una visita para el Contenido
        /// </summary>
        /// <param name="idContenido"></param>
        public void SumarVisita(int idContenido)
        {
            using (var db = new Repositorio())
            {
                Contenido contenido = db.Contenidos
                    .Where(c => c.ContenidoId.Equals(idContenido))
                    .FirstOrDefault();

                if (contenido != null)
                {
                    contenido.Visitas++;
                    db.SaveChanges();
                }
            }
        }

        public List<UsuarioContenido> ObtenerUsuariosRelacionados(int idContenido, int idTipoRelacion, bool cargarCampos)
        {
            try
            {

                List<UsuarioContenido> listaRelacionados = null;
                using (var db = new Repositorio())
                {
                    var query = db.UsuariosContenidos
                        .Include(c => c.Usuario)
                        .Include(c => c.Contenido)
                        .Include(c => c.Contenido.TipoContenido)
                        .Where(c => c.ContenidoId == idContenido);

                    if (idTipoRelacion > 0)
                        query = query.Where(c => c.TipoRelacionId == idTipoRelacion);


                    listaRelacionados = query.ToList();
                }

                return listaRelacionados;

            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return new List<UsuarioContenido>();
            }
        }

        public bool AgregarUsuarioRelacionado(UsuarioContenido usuarioContenido)
        {
            try
            {
                bool operacionExitosa = false;
                using (var db = new Repositorio())
                {

                    //Si ya tenia un contenido relacionado lo elimina
                    var relacionAnterior = db.UsuariosContenidos
                        .Where(u => u.ContenidoId == usuarioContenido.ContenidoId && u.TipoRelacionId == usuarioContenido.TipoRelacionId )
                        .FirstOrDefault();

                    if (relacionAnterior != null)
                    {
                        ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(relacionAnterior, EntityState.Deleted);
                    }
                    
                    db.UsuariosContenidos
                        .Add(usuarioContenido);

                    operacionExitosa =  db.SaveChanges() > 0;
                }

                return operacionExitosa;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }

        public bool EliminarUsuarioRelacionado(int idUsuarioContenido)
        {
            try
            {
                using (var db = new Repositorio())
                {
                    UsuarioContenido contenidoRelacionado = db.UsuariosContenidos.Where(c => c.UsuarioContenidoId.Equals(idUsuarioContenido)).FirstOrDefault();
                    db.UsuariosContenidos.Remove(contenidoRelacionado);
                    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(contenidoRelacionado, EntityState.Deleted);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                return false;
            }
        }
    }
}
