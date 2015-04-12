
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class FormularioAdopcionConfig : EntityTypeConfiguration<FormularioAdopcion>
    {
        public FormularioAdopcionConfig()
        {
            ToTable("FormularioAdopcion");

            HasMany(f => f.Respuestas)
                .WithRequired(r => r.FormularioAdopcion)
                .HasForeignKey(r => r.FormularioAdopcionId)
                .WillCascadeOnDelete(false);

            HasOptional(f => f.Adopcion)
                .WithRequired(a => a.Formulario)
                .WillCascadeOnDelete(false);
        }
    }
}
