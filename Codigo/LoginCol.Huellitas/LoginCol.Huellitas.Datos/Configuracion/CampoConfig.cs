using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class CampoConfig : EntityTypeConfiguration<Campo>
    {
        public CampoConfig()
        {
            ToTable("Campo");

            //HasRequired(c => c.Nombre).WithRequiredPrincipal();
            //HasMany(c => c.Valores).WithRequired(v => v.Campo).HasForeignKey(v => v.CampoId).WillCascadeOnDelete(true);
        }
    }
}
