using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Mapeo
{
    public static class MapeoEntidades
    {
        public static void CrearMapeo()
        {
            AutoMapper.Mapper.CreateMap<TipoContenido, string>().ConvertUsing<TipoContenidoTypeConverter>();

            AutoMapper.Mapper.CreateMap<Contenido, ContenidoModel>()
                .BeforeMap(AntesConvertirContenido)
                .ForMember(o => o.Campos, opt => opt.Ignore());
                //OJO:Si se quita revisar el listado de contenidos
                //.ForMember(o => o.Campos, opt => opt.Ignore());


            AutoMapper.Mapper.CreateMap<Contenido, ContenidoBaseModel>();

            AutoMapper.Mapper.CreateMap<ContenidoModel, Contenido>()
               // .ForMember(db => db.Campos, model => model.Ignore())
                .ForMember(o => o.ContenidosRelacionados, d => d.Ignore())
                .ForMember(o => o.ContenidosRelacionadosPadre, d => d.Ignore())
                .ForMember(o => o.TipoContenido, d => d.Ignore())
                .ForMember(o => o.Usuario, d => d.Ignore())
                .ForMember(o => o.ZonaGeografica, d => d.Ignore());

            Mapper.CreateMap<ZonaGeografica, ZonaGeograficalModel>();

            Mapper.CreateMap<ValorCampo, ValorCampoModel>();
            Mapper.CreateMap<ValorCampoModel, ValorCampo>();

            Mapper.CreateMap<TipoContenido, TipoContenidoModel>();
            Mapper.CreateMap<TipoContenido, TipoContenidoBaseModel>();
                //.ForSourceMember( o => o.Contenidos , d => d.Ignore());

            Mapper.CreateMap<CampoTipoContenido, CampoModel>();

            Mapper.CreateMap<OpcionCampo, OpcionCampoModel>();

            AutoMapper.Mapper.CreateMap<ContenidoRelacionado, ContenidoRelacionadoModel>();
        }

        private static void AntesConvertirContenido(Contenido obj, ContenidoModel model)
        {
            try
            {
                if (obj.Campos == null || obj.Campos.Count == 0)
                {
                    model.Campos = new List<ValorCampoModel>();
                }
                else
                {
                    model.Campos = obj.Campos.Select(Mapper.Map<ValorCampo, ValorCampoModel>).ToList();
                }

            }
            catch (ObjectDisposedException e)
            {
                model.Campos = new List<ValorCampoModel>();
            }
        }

        public class TipoContenidoTypeConverter : ITypeConverter<TipoContenido, string>
        {
            public string Convert(ResolutionContext context)
            {
                return ((TipoContenido)context.SourceValue).Nombre;
            }
        }
    }
}