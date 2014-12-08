using LoginCol.Huellitas.Datos.Configuracion;
using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public  partial class Repositorio : DbContext
    {

        public Repositorio()
            : base("Name=ConexionHuellitas")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Contenido>  Contenidos { get; set; }

        public DbSet<ContenidoRelacionado> ContenidosRelacionados { get; set; }
        public DbSet<ZonaGeografica> ZonasGeograficas { get; set; }
        public DbSet<TipoContenido> TiposContenidos { get; set; }
        public DbSet<ValorCampo> ValoresCampos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoRelacionContenido> TiposRelacionContenidos { get; set; }
        public DbSet<CampoTipoContenido> CamposTiposContenidos { get; set; }

        public DbSet<Parametrizacion> Parametrizaciones { get; set; }

        public DbSet<TipoRelacionTipoContenido> TiposDeRelacionPorTiposDeContenidos { get; set; }
        

        public DbSet<OpcionCampo> OpcionesCampos { get; set; }

        public DbSet<FormularioAdopcion> FormulariosAdopciones { get; set; }

        public DbSet<TablaBasica> TablasBasicas { get; set; }

        public DbSet<DatoTablaBasica> DatosTablasBasicas { get; set; }

        public DbSet<TipoRelacion> TiposRelaciones { get; set; }

        public DbSet<UsuarioContenido> UsuariosContenidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContenidoConfig());
            modelBuilder.Configurations.Add(new CampoConfig());
            modelBuilder.Configurations.Add(new ContenidoRelacionadoConfig());
            modelBuilder.Configurations.Add(new ValorCampoConfig());
            modelBuilder.Configurations.Add(new TipoContenidoConfig());
            modelBuilder.Configurations.Add(new TipoRelacionContenidoConfig());
            modelBuilder.Configurations.Add(new ZonaGeograficaConfig());
            modelBuilder.Configurations.Add(new ComentarioConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new CampoTipoContenidoConfig());
            modelBuilder.Configurations.Add(new OpcionCampoConfig());
            modelBuilder.Configurations.Add(new ParametrizacionConfig());
            modelBuilder.Configurations.Add(new TablaBasicaConfig());
            modelBuilder.Configurations.Add(new DatoTablaBasicaConfig());
            modelBuilder.Configurations.Add(new TipoRelacionConfig());
            modelBuilder.Configurations.Add(new UsuarioContenidoConfig());
            

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            this.Configuration.LazyLoadingEnabled = false;
           

            //Database.SetInitializer<Repositorio>(new GeneradorLlaveUnica<Repositorio>());
        }

    }
}
