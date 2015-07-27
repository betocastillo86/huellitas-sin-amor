using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Admin
{
    public class ListarAdopcionModel : BaseModel
    {
        public List<AdopcionModel> Adopciones { get; set; }
    }
}