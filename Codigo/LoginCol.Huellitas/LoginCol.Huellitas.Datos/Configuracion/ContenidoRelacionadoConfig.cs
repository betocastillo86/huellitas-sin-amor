using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class ContenidoRelacionadoConfig : EntityTypeConfiguration<ContenidoRelacionado>
    {
        public ContenidoRelacionadoConfig()
        {
            ToTable("ContenidoRelacionado");
            
            HasKey(e => e.ContenidoRelacionadoId);

            HasRequired(cr => cr.TipoRelacionContenido).WithMany(t => t.ContenidosRelacionados).WillCascadeOnDelete(false);

            HasRequired(cr => cr.Contenido).WithMany(c => c.ContenidosRelacionados).HasForeignKey(c => c.ContenidoId).WillCascadeOnDelete(false);
            HasRequired(cr => cr.ContenidoPadre).WithMany(c => c.ContenidosRelacionadosPadre).HasForeignKey(c => c.ContenidoPadreId).WillCascadeOnDelete(false);
        }
    }
}
