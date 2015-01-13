using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using LoginCol.Huellitas.Web.Models;
using System.Collections.Generic;
using System;
using LoginCol.Huellitas.Utilidades;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class ContenidosController : ApiController
    {

        [HttpGet]
        public List<ContenidoListadoModel> Get(int idTipoContenido, bool esPadre, [FromUri] FiltroApiContenidos filtro)
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();

            //Si el tipo de contenido es seleccionado toma por defecto el que viene y no el de animales
            if (filtro.tipo != 0)
            {
                idTipoContenido = filtro.tipo;
                esPadre = false;
            }
            else if (filtro.tipoPadre > 0)
            {
                idTipoContenido = filtro.tipoPadre;
                esPadre = true;
            }

            Contenido filtroBase = new Contenido();

            //Si la zona padre viene como filtro, la zona principal debe venir igual a 0
            if (filtro.zonaPadre > 0 && filtro.zona == 0)
            {
                filtroBase.ZonaGeografica = new ZonaGeografica(filtro.zonaPadre);
            }
                
                

            if (filtro.zona > 0)
                filtroBase.ZonaGeograficaId = filtro.zona;

            if (!string.IsNullOrEmpty(filtro.nombre))
                filtroBase.Nombre = filtro.nombre;

            int resultadosPorPagina = 8;

            var contenidosRelacionados = new List<ContenidoRelacionado>();
            if (filtro.fundacion > 0)
                contenidosRelacionados.Add(new ContenidoRelacionado() { ContenidoId = filtro.fundacion, TipoRelacionContenidoId = (int)TipoRelacionEnum.Fundacion });

            //Realiza el filtro en negocio cargando los campos desde el querystring
            var contenidosSinOrden = nContenido
                .FiltrarContenidos(idTipoContenido, esPadre, filtroBase, filtro.ObtenerValorCampo(), contenidosRelacionados).AsQueryable();
                
            switch (filtro.orden)
	        {
		        //Ordena por los mas nuevos
                case 1:
                    contenidosSinOrden = contenidosSinOrden.OrderByDescending(c => c.FechaCreacion);
                    break;
                //Ordena por los mas viejos
                case 2:
                    contenidosSinOrden = contenidosSinOrden.OrderBy(c => c.FechaCreacion);
                    break;
                //Ordena por los mas visitados
                case 3:
                    contenidosSinOrden = contenidosSinOrden.OrderByDescending(c => c.Visitas);
                    break;
                //Ordena por los mas jovenes
                case 4:
                    contenidosSinOrden = contenidosSinOrden
                        .OrderBy(c => c.Campos
                            .Where(v => v.CampoId == ParametrizacionNegocio.CampoEdadId)
                            .Select(v => Convert.ToInt32(v.Valor))
                            .FirstOrDefault());
                    break;
                //Ordena por los mas viejos
                case 5:
                    contenidosSinOrden = contenidosSinOrden
                        .OrderByDescending(c => c.Campos
                            .Where(v => v.CampoId == ParametrizacionNegocio.CampoEdadId)
                            .Select(v => Convert.ToInt32(v.Valor))
                            .FirstOrDefault());
                    break;
                //El orden por defecto es por los prioritarios y por fecha de creacion
                case 0:
                default:
                    contenidosSinOrden = contenidosSinOrden
                        .OrderByDescending(c => c.FechaCreacion)
                        .OrderByDescending(c => c.Destacado);
                    break;
	        }
            

            List<Contenido> contenidos = contenidosSinOrden
                .Skip(resultadosPorPagina*filtro.paginaActual)
                .Take(resultadosPorPagina)
                .ToList();


            return contenidos.Select(Mapper.Map<Contenido, ContenidoListadoModel>).ToList();
        }


        public ContenidoModel Get([FromUri] int id)
        {
            var nContenido = new ContenidoNegocio();
            return Mapper.Map<Contenido, ContenidoModel>(nContenido.Obtener(id));
        }
        
        [HttpDelete]
        public ResultadoOperacion Delete(int id)
        {
            var nContenido = new ContenidoNegocio();
            if (nContenido.Eliminar(id))
            {
                return new ResultadoOperacion(true);
            }
            else {
                return new ResultadoOperacion(false) { MensajeError = "Ocurrió un error guardando, intente de nuevo" };
            }
        }

    }

    public class FiltroApiContenidos
    {
        public int tipo { get; set; }
        public int genero { get; set; }
        public int color { get; set; }
        public int tamano { get; set; }
        public int edad { get; set; }
        public int tipoPerdido { get; set; }
        

        public string recomendado { get; set; }

        public int paginaActual { get; set; }

        public int zona { get; set; }

        public int zonaPadre { get; set; }

        public int tipoPadre { get; set; }

        public int fundacion { get; set; }


        public string nombre { get; set; }

        public int orden { get; set; }

        public List<FiltroContenido> ObtenerValorCampo()
        {
            List<FiltroContenido> filtros = new List<FiltroContenido>();

            if (genero > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoGeneroId, Valor = genero.ToString() });

            if (color > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoColorId, Valor = color.ToString() });

            if (tamano > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoTamanoId, Valor = tamano.ToString() });

            if (tipoPerdido > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoTipoPerdido, Valor = tipoPerdido.ToString() });

            if (!string.IsNullOrEmpty(recomendado))
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoRecomendadoParaId, Valor = recomendado , TipoFiltro = TipoFiltroContenidoEnum.MultipleOpcion});

            //Dependiendo del valor seleccionado en la edad carga los rangos de la busqueda
            if (edad > 0)
            {
                FiltroContenido filtro = new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoEdadId, TipoFiltro = TipoFiltroContenidoEnum.Rango };
                switch (edad)
                {
                    case 1:
                        filtro.Valor = "0";
                        filtro.ValorHasta = "1";
                        break;
                    case 2:
                        filtro.Valor = "1";
                        filtro.ValorHasta = "3";
                        break;
                    case 3:
                        filtro.Valor = "3";
                        filtro.ValorHasta = "5";
                        break;
                    case 4:
                        filtro.Valor = "5";
                        filtro.ValorHasta = "30";
                        break;
                    default:
                        break;
                }

                filtros.Add(filtro);
            }

            
                

            return filtros;
        }
    }
}
