using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Admin
{
    public class ListarFormularioAdopcionModel : BaseModel
    {
        public List<FormularioAdopcionModel> Formularios { get; set; }
    }
}