using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class TipoRelacionConfig : EntityTypeConfiguration<TipoRelacion>
    {
        public TipoRelacionConfig()
        {
            ToTable("TipoRelacion");

            HasKey(t => t.TipoRelacionId);

            HasRequired(t => t.TipoContenido)
                .WithMany(c => c.TiposRelacionesUsuarios)
                .HasForeignKey(t => t.TipoContenidoId)
                .WillCascadeOnDelete(false);
        }
    }
}
