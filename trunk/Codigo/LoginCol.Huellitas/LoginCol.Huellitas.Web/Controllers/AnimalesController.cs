using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AnimalesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Admin/Animales/Index.cshtml");            
        }
    }
}
