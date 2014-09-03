using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class CampoTipoContenidoConfig : EntityTypeConfiguration<CampoTipoContenido>
    {
        public CampoTipoContenidoConfig()
        {
            ToTable("CampoTipoContenido");
            HasRequired(ctc => ctc.Campo).WithMany(c => c.TiposContenidos).HasForeignKey(f => f.CampoId).WillCascadeOnDelete(false);
            HasRequired(ctc => ctc.TipoContenido).WithMany(tc => tc.Campos).HasForeignKey(f => f.TipoContenidoId).WillCascadeOnDelete(false);
        }
    }
}
