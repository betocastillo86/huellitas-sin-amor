using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class ContenidoConfig : EntityTypeConfiguration<Contenido>
    {
        public ContenidoConfig()
        {
            ToTable("Contenido");
            
            HasKey(c => c.ContenidoId);

            HasRequired(c => c.TipoContenido).WithMany(c => c.Contenidos).WillCascadeOnDelete(false);
            
            
            //HasMany(c => c.ContenidosRelacionados).WithRequired(cr => cr.Contenido).HasForeignKey(c => c.ContenidoId).WillCascadeOnDelete(false);
            //HasMany(c => c.ContenidosRelacionados).WithRequired(cr => cr.ContenidoPadre).HasForeignKey(cr => cr.ContenidoPadreId).WillCascadeOnDelete(false);

            //HasMany(c => c.Campos).WithRequired(v => v.Contenido).HasForeignKey(v => v.ContenidoId).WillCascadeOnDelete(false);
        }
    }
}
