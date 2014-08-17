using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class ComentarioConfig : EntityTypeConfiguration<Comentario>
    {
        public ComentarioConfig()
        {
            ToTable("Comentario");

            HasRequired(c => c.Usuario).WithMany(u => u.Comentarios).HasForeignKey(c => c.UsuarioId).WillCascadeOnDelete(false);
        }
    }
}
