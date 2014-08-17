﻿using LoginCol.Huellitas.Datos.Configuracion;
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
            
        }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Contenido>  Contenidos { get; set; }
        public DbSet<ZonaGeografica> ZonasGeograficas { get; set; }
        public DbSet<TipoContenido> TiposContenidos { get; set; }
        public DbSet<ValorCampo> ValoresCampos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

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

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            //Database.SetInitializer<Repositorio>(new GeneradorLlaveUnica<Repositorio>());
        }

    }
}
