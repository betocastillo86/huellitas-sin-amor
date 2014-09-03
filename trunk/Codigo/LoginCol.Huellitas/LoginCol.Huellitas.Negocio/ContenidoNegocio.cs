﻿
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class ContenidoNegocio
    {
        public  Lazy<ContenidoRepositorio> _contenidos { get; set; }

        public ContenidoNegocio()
        {
            _contenidos = new Lazy<ContenidoRepositorio>(false);
        }

        public List<Contenido> ObtenerPorTipo(TipoContenidoEnum tipoContenido)
        {
            return _contenidos.Value.ObtenerPorTipo(tipoContenido);
        }
        public List<Contenido> ObtenerPorTipoPadre(TipoContenidoEnum tipoContenido)
        {
            return _contenidos.Value.ObtenerPorTipoPadre(tipoContenido).ToList();
        }

        public Contenido Obtener(int id)
        {
            Contenido contenido = _contenidos.Value.Obtener(id);
            //contenido.Campos = _contenidos.Value.ObtenerCampos(id);
            return contenido;
        }
    }
}
