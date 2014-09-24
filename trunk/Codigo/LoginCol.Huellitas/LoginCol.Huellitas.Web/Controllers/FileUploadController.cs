using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class FileUploadController : ApiController
    {
        private static readonly string ServerUploadFolder = "C:\\Temp";
        
        [HttpPost]
        public async void Post(int id)
        {
            var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            await Request.Content.ReadAsMultipartAsync(streamProvider);
            string a = "";
        }
    }
}
