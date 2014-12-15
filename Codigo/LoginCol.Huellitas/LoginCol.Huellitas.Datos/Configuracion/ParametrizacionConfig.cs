using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class ParametrizacionConfig : EntityTypeConfiguration<Parametrizacion>
    {
        public ParametrizacionConfig()
        {
            ToTable("Parametrizacion"); 
        }
    }
}
