using LoginCol.Huellitas.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuario");

            HasMany(u => u.FormulariosDeAdopcion)
                .WithRequired(f => f.Usuario)
                .HasForeignKey(f => f.UsuarioId)
                .WillCascadeOnDelete(false);

            //HasKey(u => u.Correo);

            //HasMany(u => u.Contenidos).WithRequired(c => c.Usuario).HasForeignKey(c => c.UsuarioId);

            //HasMany(u => u.Comentarios).WithRequired(c => c.Usuario).HasForeignKey(c => c.UsuarioId);
        }
    }
}
