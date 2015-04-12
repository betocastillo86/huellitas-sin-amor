using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class SeguimientoAdopcionConfig : EntityTypeConfiguration<SeguimientoAdopcion>
    {
        public SeguimientoAdopcionConfig()
        {
            ToTable("SeguimientoAdopcion");

            HasMany(s => s.Respuestas)
                .WithRequired(r => r.Seguimiento)
                .HasForeignKey(r => r.SeguimientoId)
                .WillCascadeOnDelete(false);
        }
    }
}
