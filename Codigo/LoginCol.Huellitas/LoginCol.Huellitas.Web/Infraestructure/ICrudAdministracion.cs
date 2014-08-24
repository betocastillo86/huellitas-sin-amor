using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Infraestructure
{
    public interface ICrudAdministracion<T>
    {
        [HttpGet]
        List<T> Listar();

        [HttpGet]
        T Obtener(int id);
        
        [HttpPost]
        T Crear(int id, T modelo);

        [HttpPut]
        T Editar(int id, T modelo);

        [HttpDelete]
        T Eliminar(int id);

        
    }
}
