using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class ZonaGeograficaConfig: EntityTypeConfiguration<ZonaGeografica>
    {
        public ZonaGeograficaConfig()
        {
            ToTable("ZonaGeografica");
            HasKey(z => z.ZonaGeograficaId);

            //HasOptional(z => z.ZonaGeograficaPadre).WithMany(z => zp.ZonasGeograficasHijo).HasForeignKey(zp => zp.ZonaGeograficaId).WillCascadeOnDelete(false);
            HasOptional(z => z.ZonaGeograficaPadre).WithMany().Map(c => c.MapKey("ZonaGeograficaPadreId"));
        }
    }
}
