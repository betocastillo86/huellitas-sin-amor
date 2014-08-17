using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class ValorCampoConfig : EntityTypeConfiguration<ValorCampo>
    {
        public ValorCampoConfig()
        {
            ToTable("ValorCampo");
            
            HasKey(v => v.ValorCampoId);

            HasRequired(vc => vc.Campo).WithMany(vc => vc.Valores).HasForeignKey(f => f.CampoId).WillCascadeOnDelete(false);
            HasRequired(vc => vc.Contenido).WithMany(vc => vc.Campos).HasForeignKey(c => c.ContenidoId).WillCascadeOnDelete(false);
        }
    }
}
