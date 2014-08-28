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
        ActionResult Listar();

        [HttpGet]
        ActionResult Obtener(int id);
        
        [HttpPost]
        ActionResult Crear(int id, T modelo);

        [HttpPut]
        ActionResult Editar(int id, T modelo);

        [HttpDelete]
        string Eliminar(int id);

        
    }
}
