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

namespace LoginCol.Huellitas.Web.Controllers
{
    public class ContenidosController : ApiController
    {

        [HttpGet]
        public List<ContenidoBaseModel> Get(int idTipoContenido, bool esPadre, [FromUri] FiltroApiContenidos filtro)
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();

            //Si el tipo de contenido es seleccionado toma por defecto el que viene y no el de animales
            if (filtro.tipo != 0)
            {
                idTipoContenido = filtro.tipo;
                esPadre = false;
            }

            //Realiza el filtro en negocio cargando los campos desde el querystring
            List<Contenido> contenidos = nContenido.FiltrarContenidos(idTipoContenido, esPadre, filtro.ObtenerValorCampo());
            return contenidos.Select(Mapper.Map<Contenido, ContenidoBaseModel>).ToList();
        }

    }

    public class FiltroApiContenidos
    {
        public int tipo { get; set; }
        public int genero { get; set; }
        public int color { get; set; }
        public int tamano { get; set; }
        public int edad { get; set; }

        public string recomendado { get; set; }

        public List<FiltroContenido> ObtenerValorCampo()
        {
            List<FiltroContenido> filtros = new List<FiltroContenido>();

            if (genero > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoGeneroId, Valor = genero.ToString() });

            if (color > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoColorId, Valor = color.ToString() });

            if (tamano > 0)
                filtros.Add(new FiltroContenido() { CampoId = ParametrizacionNegocio.CampoTamanoId, Valor = tamano.ToString() });

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
