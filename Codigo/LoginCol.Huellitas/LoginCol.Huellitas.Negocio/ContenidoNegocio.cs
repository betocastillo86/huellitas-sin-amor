
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
    public class ContenidoNegocio : NegocioBase
    {
        public ContenidoNegocio() : base() {
            _contenidos = new Lazy<ContenidoRepositorio>(false);
        }

        public ContenidoNegocio(string rutaServidor) : base(rutaServidor){
            _contenidos = new Lazy<ContenidoRepositorio>(false);
        }
        
        private  Lazy<ContenidoRepositorio> _contenidos { get; set; }



        public List<Contenido> ObtenerPorTipo(int tipoContenido)
        {
            return ObtenerPorTipo((int)tipoContenido, false);
        }


        public List<Contenido> ObtenerPorTipo(int idTipoContenido, bool esPadre)
        {
            if (esPadre)
                return ObtenerPorTipoPadre((TipoContenidoEnum)idTipoContenido);
            else
                return _contenidos.Value.ObtenerPorTipo(idTipoContenido);
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
            return ObtenerRutaImagenPrincipal(contenido.ContenidoId, tamano);   
        }

        /// <summary>
        /// Retorna la ruta de la imagen principal del contenido ne lo diferente tamaños
        /// </summary>
        /// <param name="idContenido"></param>
        /// <param name="tamano"></param>
        /// <returns></returns>
        public string ObtenerRutaImagenPrincipal(int idContenido, TamanoImagenEnum tamano)
        {
            //Contenido contenido = Obtener(idContenido);

            string nombreImagen = string.Empty;

            switch (tamano)
            {
                case TamanoImagenEnum.Grande:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_big.jpg", idContenido);
                    break;
                case TamanoImagenEnum.Pequeno:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_mini.jpg", idContenido);
                    break;
                case TamanoImagenEnum.Mediano:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_medium.jpg", idContenido);
                    break;
                case TamanoImagenEnum.Original:
                    nombreImagen = string.Format("~/RecursosContenidos/Imagenes/{0}/{0}_original.jpg", idContenido);
                    break;
            }

            return nombreImagen;
        }

        public string ObtenerRutaFisicaImagenPrincipal(int idContenido, TamanoImagenEnum tamano)
        {
            string rutaImagen = ObtenerRutaImagenPrincipal(idContenido, tamano);
            //Se invierten los / para sacar una ruta fisica
            rutaImagen = rutaImagen.Replace("~/", string.Empty).Replace("/", @"\");
            return string.Concat(this.RutaServidor, rutaImagen);
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

        public List<ContenidoRelacionado> ObtenerImagenes(int idContenido)
        {
            return _contenidos.Value.ObtenerContenidosRelacionados(idContenido, (int)TipoRelacionEnum.Imagen);
        }

        public List<ContenidoRelacionado> ObtenerContenidosRelacionados(int idContenido, int idTipoRelacion)
        {
            return _contenidos.Value.ObtenerContenidosRelacionados(idContenido, idTipoRelacion);
        }
        public ContenidoRelacionado ObtenerContenidoRelacionado(int idContenido, int idContenidoHijo, int idTipoRelacion)
        {
            return _contenidos.Value.ObtenerContenidoRelacionado(idContenido, idContenidoHijo, idTipoRelacion);
        }

        public bool Eliminar(int idContenido)
        {
            return _contenidos.Value.Eliminar(idContenido);

        }

        public bool EliminarContenidoRelacionado(int idContenidoRelacionado)
        {
            return _contenidos.Value.EliminarContenidoRelacionado(idContenidoRelacionado);
        }

        public ResultadoOperacion AgregarContenidoRelacionado(ContenidoRelacionado contenidoRelacionado)
        {
            ResultadoOperacion respuesta = new ResultadoOperacion(true);

            try
            {
                TipoContenidoNegocio negocioTipoContenido = new TipoContenidoNegocio();

                //Consulta el detalle del nuevo tipo de relacion
                TipoRelacionContenido tipoRelacion = negocioTipoContenido.ObtenerTipoRelacionContenido(contenidoRelacionado.TipoRelacionContenidoId);

                //Cuenta cuantos contenidos relacionados hay por ese tipo
                int cantidadRelacionados = ObtenerContenidosRelacionados(contenidoRelacionado.ContenidoId, tipoRelacion.TipoRelacionContenidoId).Count;

                if (cantidadRelacionados >= tipoRelacion.MaximoRegistros && tipoRelacion.MaximoRegistros > 0)
                {
                    respuesta.OperacionExitosa = false;
                    respuesta.MensajeError = "No es posible agregar más registros a este tipo de relación";
                }
                else
                {
                    if (!_contenidos.Value.AgregarContenidoRelacionado(contenidoRelacionado))
                    {
                        respuesta.OperacionExitosa = false;
                        respuesta.MensajeError = "Ocurrio un error guardando, intente de nuevo";
                    }
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = "Ocurrio un error guardando, intente de nuevo";
            }


            return respuesta;
            
        }

        /// <summary>
        /// Guarda la imagen de un contenido y crea la estructura de carpetas redimensionando las demás
        /// </summary>
        /// <param name="idContenido">id del contenido</param>
        /// <param name="bytes">datos del archivo</param>
        public ResultadoOperacion GuardarImagen(int idContenido, byte[] bytes)
        {
            ResultadoOperacion respuesta = new ResultadoOperacion(true);

            try
            {
                //Intenta guardar el archivo original en el disco
                string imagenOriginal= ObtenerRutaFisicaImagenPrincipal(idContenido, TamanoImagenEnum.Original);
                if (Archivos.GuardarArchivoEnDisco(imagenOriginal, bytes, true))
                {
                    //Intenta redimensionar las imagenes
                    byte[] bytesGrande = Imagenes.RedimensionarImagen(imagenOriginal, 800, 800);
                    byte[] bytesMediano = Imagenes.RedimensionarImagen(imagenOriginal, 500, 500);
                    byte[] bytesPequeno = Imagenes.RedimensionarImagen(imagenOriginal, 200, 200);

                    //Intenta guardar las imagenes
                    if (!Archivos.GuardarArchivoEnDisco(ObtenerRutaFisicaImagenPrincipal(idContenido, TamanoImagenEnum.Grande), bytesGrande, true) ||
                        !Archivos.GuardarArchivoEnDisco(ObtenerRutaFisicaImagenPrincipal(idContenido, TamanoImagenEnum.Mediano), bytesMediano, true) ||
                        !Archivos.GuardarArchivoEnDisco(ObtenerRutaFisicaImagenPrincipal(idContenido, TamanoImagenEnum.Pequeno), bytesPequeno, true))
                    {
                        respuesta.OperacionExitosa = false;
                        respuesta.MensajeError = "No fue posible guardar la imagen grande";
                    }
                    
                }
                else
                {
                    respuesta.OperacionExitosa = false;
                    respuesta.MensajeError = "No fue posible guardar la imagen principal";
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
                respuesta.OperacionExitosa = false;
                respuesta.MensajeError = "Error generando las imagenes";
            }

            return respuesta;
            
        }

        /// <summary>
        /// Crea el contenido de tipo imagen y lo relaciona
        /// </summary>
        /// <param name="idContenidoPadre"></param>
        /// <param name="contenido"></param>
        /// <returns></returns>
        public ResultadoOperacion AgregarImagen(int idContenidoPadre, Contenido contenido, int idUsuario)
        { 
            contenido.TipoContenidoId = (int)TipoContenidoEnum.Imagen;
            contenido.ZonaGeograficaId = ParametrizacionNegocio.ZonaGeograficaPorDefecto;
            ResultadoOperacion respuesta = Crear(contenido, idUsuario);

            if (respuesta.OperacionExitosa)
            {
                respuesta.OperacionExitosa = AgregarContenidoRelacionado(new ContenidoRelacionado()
                                            {
                                                ContenidoHijoId = respuesta.Id,
                                                ContenidoId = idContenidoPadre,
                                                TipoRelacionContenidoId = (int)TipoRelacionEnum.Imagen
                                            }).OperacionExitosa;

            }

            return respuesta;
        }

        public List<Contenido> FiltrarContenidos(int idTipoContenido, bool esPadre, List<FiltroContenido> camposFiltros)
        {
            ContenidoRepositorio rContenido = new ContenidoRepositorio();
            return rContenido.FiltrarContenidos(idTipoContenido, esPadre, camposFiltros);
        }
    }
}
