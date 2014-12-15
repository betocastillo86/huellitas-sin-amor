using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class ListarFundacionesModel : BaseModel
    {
        public ListarFundacionesModel()
            : base("TituloFundaciones")
        {

        }
        
        public List<ZonaGeograficalModel> ZonasPadre { get; set; }
    }
}