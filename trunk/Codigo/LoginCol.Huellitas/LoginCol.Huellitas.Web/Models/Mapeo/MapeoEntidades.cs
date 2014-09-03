using AutoMapper;
using LoginCol.Huellitas.Entidades;
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
            
            AutoMapper.Mapper.CreateMap<Contenido, ContenidoModel>();

            AutoMapper.Mapper.CreateMap<ContenidoModel, Contenido>()
               // .ForMember(db => db.Campos, model => model.Ignore())
                .ForMember(o => o.ContenidosRelacionados, d => d.Ignore())
                .ForMember(o => o.ContenidosRelacionadosPadre, d => d.Ignore())
                .ForMember(o => o.TipoContenido, d => d.Ignore())
                .ForMember(o => o.Usuario, d => d.Ignore())
                .ForMember(o => o.ZonaGeografica, d => d.Ignore());

            Mapper.CreateMap<ZonaGeografica, ZonaGeograficalModel>();

            Mapper.CreateMap<ValorCampo, ValorCampoModel>();

            Mapper.CreateMap<TipoContenido, TipoContenidoModel>();
                //.ForSourceMember( o => o.Contenidos , d => d.Ignore());

            Mapper.CreateMap<CampoTipoContenido, CampoModel>();

            Mapper.CreateMap<OpcionCampo, OpcionCampoModel>();
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