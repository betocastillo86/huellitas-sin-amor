
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginCol.Huellitas.Utilidades;

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

        /// <summary>
        /// Busca un contenido por el nombnre
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="quitarGuiones">Valida si debe remover los guiones al momento de buscar</param>
        /// <returns></returns>
        public Contenido ObtenerPorNombre(string nombre, bool quitarGuiones)
        {
            return _contenidos.Value.ObtenerPorNombre(nombre, quitarGuiones);
        }


        public string ObtenerImagenPrincipal(string nombre, TamanoImagenEnum tamano)
        {
            Contenido contenido = ObtenerPorNombre(nombre, true);
            return ObtenerImagenPrincipal(contenido.ContenidoId, tamano);   
        }

        /// <summary>
        /// Retorna la ruta de la imagen principal del contenido ne lo diferente tamaños
        /// </summary>
        /// <param name="idContenido"></param>
        /// <param name="tamano"></param>
        /// <returns></returns>
        public string ObtenerImagenPrincipal(int idContenido, TamanoImagenEnum tamano)
        {
            //Contenido contenido = Obtener(idContenido);

            string nombreImagen = string.Empty;

            switch (tamano)
            {
                case TamanoImagenEnum.Grande:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_big.gif", idContenido);
                    break;
                case TamanoImagenEnum.Pequeno:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_mini.gif", idContenido);
                    break;
                case TamanoImagenEnum.Mediano:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_medium.gif", idContenido);
                    break;
            }

            return nombreImagen;
        }

        public ResultadoOperacion Actualizar(Contenido contenido)
        {
           ResultadoOperacion respuesta = new ResultadoOperacion();
           respuesta.OperacionExitosa = _contenidos.Value.Actualizar(contenido);
           return respuesta;
        }

        public ResultadoOperacion Crear(Contenido contenido, int idUsuario)
        {
            ResultadoOperacion respuesta = new ResultadoOperacion();
            contenido.UsuarioId = idUsuario;
            
            respuesta.Id = _contenidos.Value.Crear(contenido);
            respuesta.OperacionExitosa = respuesta.Id > 0;

            if (!respuesta.OperacionExitosa)
                respuesta.MensajeError = "No fue posible crear el contenido";
            
            return respuesta;
        }

        public List<Contenido> ObtenerImagenes(int idContenido)
        {
            return _contenidos.Value.ObtenerContenidosRelacionados(idContenido, TipoRelacionEnum.Imagen);
        }
    }
}
