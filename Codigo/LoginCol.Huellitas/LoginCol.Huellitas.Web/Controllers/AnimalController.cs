using LoginCol.Huellitas.Web.Infraestructure;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AnimalController : Controller, ICrudAdministracion<AnimalModel>
    {

        public List<AnimalModel> Listar()
        {
            throw new NotImplementedException();
        }

        public AnimalModel Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public AnimalModel Crear(int id, AnimalModel modelo)
        {
            throw new NotImplementedException();
        }

        public AnimalModel Editar(int id, AnimalModel modelo)
        {
            throw new NotImplementedException();
        }

        public AnimalModel Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
