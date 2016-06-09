using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Negocios = new FabricaNegocios();
        }

        public FabricaNegocios Negocios { get; set; }

    }
}