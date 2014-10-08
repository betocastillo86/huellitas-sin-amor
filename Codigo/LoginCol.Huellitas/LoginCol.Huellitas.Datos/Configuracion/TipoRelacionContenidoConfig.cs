using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class TipoRelacionContenidoConfig : EntityTypeConfiguration<TipoRelacionContenido>
    {
        public TipoRelacionContenidoConfig()
        {
            ToTable("TipoRelacionContenido");

            HasRequired(tr => tr.TipoContenido).WithMany(tc => tc.TiposDeRelacionesDeContenido).WillCascadeOnDelete(false);
        }
    }
}
