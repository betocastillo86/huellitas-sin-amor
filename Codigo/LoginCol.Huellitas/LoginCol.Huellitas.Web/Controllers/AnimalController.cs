using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AnimalController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            
            
            //return Request.CreateResponse(HttpStatusCode.OK, );
        }
    }
}
