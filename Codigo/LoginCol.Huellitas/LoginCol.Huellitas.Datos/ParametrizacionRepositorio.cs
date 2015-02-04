using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class ParametrizacionRepositorio
    {
        public string Obtener(string llave)
        {
            string valor = string.Empty;

            using (var db = new Repositorio())
            {
                
                valor = db.Parametrizaciones
                    .Where(p => p.Llave.Equals(llave))
                    .FirstOrDefault().Valor;
            }

            return valor;
        }

        public bool ExisteLLave(string llave)
        {
            bool existe = false;

            using (var db = new Repositorio())
            {

                existe = db.Parametrizaciones
                    .Where(p => p.Llave.Equals(llave))
                    .FirstOrDefault() != null;
            }

            return existe;
        }

        public List<Entidades.Parametrizacion> Obtener()
        {
            List<Parametrizacion> lista;

            using (var db = new Repositorio())
            {
                lista = db.Parametrizaciones.ToList();
            }

            return lista ?? new List<Parametrizacion>();
        }

        public bool Actualizar(Parametrizacion modelo)
        {
            bool respuesta = false;

            using (var db = new Repositorio())
            {
                db.Parametrizaciones
                    .Where(p => p.Llave.Equals(modelo.Llave))
                    .ToList()
                    .ForEach(p => p.Valor = modelo.Valor);

                respuesta = db.SaveChanges() > 0;
            }

            return respuesta;
        }

        /// <summary>
        /// Crea una varibale de parametrizacion en la tabla Parametrizacion
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public bool Crear(Parametrizacion modelo)
        {
            bool respuesta = false;
            using (var db = new Repositorio())
            {
                db.Parametrizaciones
                    .Add(modelo);

                respuesta = db.SaveChanges() > 0;
            }
            return respuesta;
        }
    }
}
