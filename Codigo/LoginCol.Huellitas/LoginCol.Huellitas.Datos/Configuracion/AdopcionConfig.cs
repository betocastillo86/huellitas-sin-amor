using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class AdopcionConfig : EntityTypeConfiguration<Adopcion>
    {
        public AdopcionConfig()
        {
            ToTable("Adopcion");

            HasMany(a => a.Seguimientos)
                .WithRequired(s => s.Adopcion)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Formulario)
                .WithOptional(f => f.Adopcion)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Formulario)
                .WithRequiredPrincipal(f => f.Adopcion)
                .WillCascadeOnDelete(false);
        }
    }
}
