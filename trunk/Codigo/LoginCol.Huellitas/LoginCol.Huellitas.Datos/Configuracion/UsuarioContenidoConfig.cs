using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class UsuarioContenidoConfig : EntityTypeConfiguration<UsuarioContenido>
    {
        public UsuarioContenidoConfig()
        {
            ToTable("UsuarioContenido");

            HasKey(u => u.UsuarioContenidoId);

            HasRequired(u => u.Contenido)
                .WithMany(c => c.UsuariosRelacionados)
                .HasForeignKey(c => c.ContenidoId)
                .WillCascadeOnDelete(false);


            HasRequired(u => u.Usuario)
                .WithMany(us => us.ContenidosRelacionados)
                .HasForeignKey(us => us.UsuarioId)
                .WillCascadeOnDelete(false);
        }
    }
}
