using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos.Configuracion
{
    public class DatoTablaBasicaConfig : EntityTypeConfiguration<DatoTablaBasica>
    {
        public DatoTablaBasicaConfig(){
            ToTable("DatoTablaBasica");

            HasMany(dt => dt.Respuestas)
                .WithRequired(r => r.Pregunta)
                .HasForeignKey(r => r.PreguntaId)
                .WillCascadeOnDelete(false);

            HasMany(dt => dt.EstadosCiviles)
                .WithOptional(u => u.EstadoCivil)
                .HasForeignKey(u => u.EstadoCivilId)
                .WillCascadeOnDelete(false);


            HasMany(dt => dt.Ocupaciones)
                .WithOptional(u => u.Ocupacion)
                .HasForeignKey(u => u.OcupacionId)
                .WillCascadeOnDelete(false);
        }
    }
}
