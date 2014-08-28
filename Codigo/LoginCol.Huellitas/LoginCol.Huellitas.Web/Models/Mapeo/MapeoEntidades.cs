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
                .ForMember(db => db.Campos, model => model.Ignore())
                .ForMember(db => db.ContenidosRelacionados, model => model.Ignore())
                .ForMember(db => db.ContenidosRelacionadosPadre, model => model.Ignore())
                .ForMember(db => db.TipoContenido, model => model.Ignore())
                .ForMember(db => db.Usuario, model => model.Ignore())
                .ForMember(db => db.ZonaGeografica, model => model.Ignore());
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