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


    }
}
