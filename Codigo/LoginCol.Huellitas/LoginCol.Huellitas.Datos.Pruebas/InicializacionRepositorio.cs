using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
