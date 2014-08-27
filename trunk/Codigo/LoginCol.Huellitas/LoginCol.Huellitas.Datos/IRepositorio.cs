using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public interface IRepositorio<T>
    {
        T Obtener(T filtro);

        int Insertar(T obj);

        bool Actualizar(T obj);

        bool Eliminar(int id);
    }
}
