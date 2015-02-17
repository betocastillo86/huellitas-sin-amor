using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginCol.Huellitas.Entidades;

namespace LoginCol.Huellitas.Datos.Pruebas
{
    [TestClass]
    public class InicializacionRepositorio
    {
        [TestMethod]
        public void CrearBaseDeDatos()
        {
            using (var db = new Repositorio())
            {
                if (db.Database.Exists())
                    db.Database.Delete();

                db.Database.Create();
            }
        }

        [TestMethod]
        public void DatosIniciales()
        {
            CargarTiposDeContenido();
            CargarTiposDeRelacion();
            CargarZonasGeograficas();
            CargarUsuarios();
            CargarContenidoIncial();
            CargarCampos();
            CargarParametrizacion();
        }

        private void CargarCampos()
        {
            using (var db = new Repositorio())
            {
                db.Campos.Add(new Campo() { CampoId = 1, Nombre ="Color", TipoDato = TipoDatoCampo.Relacional });
                db.CamposTiposContenidos.Add(new CampoTipoContenido() { CampoTipoContenidoId = 1, TipoContenidoId = 4, CampoId = 1 });
                db.OpcionesCampos.Add(new OpcionCampo() { OpcionId = 1, CampoId = 1, Texto = "Rojo" });
                db.OpcionesCampos.Add(new OpcionCampo() { OpcionId = 2, CampoId = 1, Texto = "Negro" });
                db.OpcionesCampos.Add(new OpcionCampo() { OpcionId = 3, CampoId = 1, Texto = "Blanco" });

                db.Campos.Add(new Campo() { CampoId = 2, Nombre = "Tamaño", TipoDato = TipoDatoCampo.Relacional });
                db.CamposTiposContenidos.Add(new CampoTipoContenido() { CampoTipoContenidoId = 1, TipoContenidoId = 4, CampoId = 2 });
                db.OpcionesCampos.Add(new OpcionCampo() { OpcionId = 4, CampoId = 1, Texto = "Grande"});
                db.OpcionesCampos.Add(new OpcionCampo() { OpcionId = 5, CampoId = 1, Texto = "Pequeño" });
                db.OpcionesCampos.Add(new OpcionCampo() { OpcionId = 6, CampoId = 1, Texto = "Mediano" });

                db.Campos.Add(new Campo() { CampoId = 3, Nombre = "Edad", TipoDato = TipoDatoCampo.Int });
            }
        }

        private void CargarUsuarios()
        {
            using (var db = new Repositorio())
            {
                db.Usuarios.Add(new Usuario() { UsuarioId = 1, Nombres = "Gabriel", Apellidos = "Castillo", Activo = true, Correo = "gabriel.castillo86@hotmail.com", FechaRegistro = DateTime.Now, Clave = "123", NumeroDocumento = "1023865316"  });
                db.Usuarios.Add(new Usuario() { UsuarioId = 2, Nombres = "Erica", Apellidos = "Prado", Activo = true, Correo = "erica@hotmail.com", FechaRegistro = DateTime.Now, Clave = "123", NumeroDocumento = "1023865315" });
                db.SaveChanges();
            }
        }

        private void CargarContenidoIncial()
        {
            using (var db = new Repositorio())
            {
                db.Contenidos.Add(new Contenido() { ContenidoId = 1, Nombre = "Skid", TipoContenidoId = 4, Descripcion = "Perrito", FechaCreacion = DateTime.Now, ZonaGeograficaId = 2, UsuarioId = 1 });
                db.Contenidos.Add(new Contenido() { ContenidoId = 2, Nombre = "Lennon", TipoContenidoId = 4, Descripcion = "Perrito", FechaCreacion = DateTime.Now, ZonaGeograficaId = 2, UsuarioId = 1 });
                db.Contenidos.Add(new Contenido() { ContenidoId = 3, Nombre = "Perro1", TipoContenidoId = 4, Descripcion = "Perrito", FechaCreacion = DateTime.Now, ZonaGeograficaId = 2, UsuarioId = 1 });
                db.Contenidos.Add(new Contenido() { ContenidoId = 4, Nombre = "perro2", TipoContenidoId = 3, Descripcion = "Perrito", FechaCreacion = DateTime.Now, ZonaGeograficaId = 2, UsuarioId = 1 });
                db.Contenidos.Add(new Contenido() { ContenidoId = 5, Nombre = "perro3", TipoContenidoId = 3, Descripcion = "Perrito", FechaCreacion = DateTime.Now, ZonaGeograficaId = 2, UsuarioId = 1 });
                db.Contenidos.Add(new Contenido() { ContenidoId = 6, Nombre = "perro4", TipoContenidoId = 4, Descripcion = "Perrito", FechaCreacion = DateTime.Now, ZonaGeograficaId = 2, UsuarioId = 1 });
                db.SaveChanges();
            }
        }

        private void CargarZonasGeograficas()
        {
            using (var db = new Repositorio())
            {
                db.ZonasGeograficas.Add(new ZonaGeografica() { ZonaGeograficaId = 1, Nombre = "Colombia" });
                //db.ZonasGeograficas.Add(new ZonaGeografica() { ZonaGeograficaId = 2, ZonaGeograficaPadre = new ZonaGeografica() { ZonaGeograficaId = 1 }, Nombre = "Bogotá" });
                db.ZonasGeograficas.Add(new ZonaGeografica() { ZonaGeograficaId = 2, Nombre = "Bogotá" });
                db.ZonasGeograficas.Add(new ZonaGeografica() { ZonaGeograficaId = 3, Nombre = "Cali" });
                db.ZonasGeograficas.Add(new ZonaGeografica() { ZonaGeograficaId = 4, Nombre = "Medellin" });
                db.SaveChanges();
            }
        }

        private void CargarTiposDeRelacion()
        {
            using (var db = new Repositorio())
            {
                db.TiposRelacionContenidos.Add(new TipoRelacionContenido() { TipoRelacionContenidoId = 1, Nombre = "Imagen", Descripcion = "Imagenes asociadas al usuario" });
                db.TiposRelacionContenidos.Add(new TipoRelacionContenido() { TipoRelacionContenidoId = 2, Nombre = "Perros en fundacion", Descripcion = "Perros en la fundación" });
                db.TiposRelacionContenidos.Add(new TipoRelacionContenido() { TipoRelacionContenidoId = 2, Nombre = "Staff", Descripcion = "Staff de la fundación" });
                db.SaveChanges();
            }
        }

        private void CargarTiposDeContenido()
        {
            using (var db = new Repositorio())
            {

                db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 1, Nombre = "Imagen"  });
                db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 2, Nombre = "Animal" });
                db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 3, Nombre = "Fundacion" });
                //db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 4, Nombre = "Perro", TipoContenidoPadre = new TipoContenido() { TipoContenidoId = 1 } });
                //db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 5, Nombre = "Gato", TipoContenidoPadre = new TipoContenido() { TipoContenidoId = 1 } });
                //db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 6, Nombre = "Pajaro", TipoContenidoPadre = new TipoContenido() { TipoContenidoId = 1 } });
                db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 4, Nombre = "Perro" });
                db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 5, Nombre = "Gato" });
                db.TiposContenidos.Add(new TipoContenido() { TipoContenidoId = 6, Nombre = "Pajaro" });
                db.SaveChanges();
            }
        }

        public void CargarParametrizacion()
        {
            using (var db = new Repositorio())
            {
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "AsuntoContacto", Valor = "Contacto Huellitas pagina" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoColorId", Valor = "1" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoContactoCorreoId", Valor = "23" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoContactoNombreId", Valor = "21" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoContactoTelefonoId", Valor = "22" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoEdadId", Valor = "4" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoGeneroId", Valor = "6" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoRaza", Valor = "25" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoRecomendadoParaId", Valor = "8" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoTamanoId", Valor = "3" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "CampoTipoPerdido", Valor = "24" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "ComentariosPorPagina", Valor = "5" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "DescripcionHome", Valor = "Huellitas sin Hogar es un sitio web sin animo de lucro en el cual puedes buscar una mascota y adoptarla completamente gratis. " });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "DescripcionPerdidos", Valor = "Huellitas sin hogar tiene una plataforma para tí en la cual podrás ingresar los datos de mascotas perdidas al rededor de Colombia. También si estas buscando tu perro o gato perdido, lo podrás encontrar acá ya sea Bogotá, Cali, Medellin, Barranquilla o cualquier ciudad." });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "DestinatarioCorreosContacto", Valor = "gabriel.castillo86@gmail.com" });
                //db.Parametrizaciones.Add(new Parametrizacion() { Llave = "ExtensionesImagenes", Valor = "/^.*\.(jpg|JPG)$/" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "LlaveRouterQuieroAdoptar", Valor = "quiero-adoptar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "LlaveRouterVerTodos", Valor = "ver-todos" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "MapsApiKey", Valor = "AIzaSyA81Cbp8FVDItLNrbaU0yNJU_bB94a1Jgo" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TamanoMaximoCargaArchivos", Valor = "10000000" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloAdopcion", Valor = "Quiero adoptar a {0}  - Huellitas sin Hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloDetalleFundacion", Valor = "{0} - Descubre lo que hay detras de este centro de adopción - Huellitas sin Hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloDetalleHuellita", Valor = "{0} - No hay que comprar un perro o un gato, dale la oportunidad a {0} - Huellitas sin Hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloFundaciones", Valor = "Busca la fundación más cercana a tí y adopta un perro o un gato - Huellitas sin Hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloHome", Valor = "Adopta una mascota y dale amor toda la vida - Huellitas sin Hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloHuellitas", Valor = "Encuentra mascotas desde cachorros hasta adultos y adoptalos - Huellitas sin Hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloHuellitasDeFundacion", Valor = "{0} tiene los siguientes perros o gatos para dar en adopción" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloPerdidos", Valor = "Encuentra o reporta mascotas perdidas - Huellitas sin hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "TituloPorqueAdoptar", Valor = "¿Por qué debes adoptar una mascota? - Huellitas sin hogar" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "UrlSitio", Valor = "http://localhost:37624/" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "UsuarioPorDefecto", Valor = "1" });
                db.Parametrizaciones.Add(new Parametrizacion() { Llave = "ZonaGeograficaPorDefecto", Valor = "1" });
            }
        }


    }
}
