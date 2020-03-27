using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;

namespace NettrimCh.Api.DataAccess.Models
{
    public partial class NettrimChContext : DbContext
    {
        public NettrimChContext()
        {
        }

        public NettrimChContext(DbContextOptions<NettrimChContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteModel> Clientes { get; set; }
        public virtual DbSet<CodigoOtModel> CodigosOt { get; set; }
        public virtual DbSet<RecursoModel> Recursos { get; set; }
        public virtual DbSet<TablaTipoTareaModel> TablaTipoTarea { get; set; }
        public virtual DbSet<TareaModel> Tareas { get; set; }
        public virtual DbSet<UsuarioOtsModel> UsuarioOts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cliente).HasMaxLength(255);

                entity.Property(e => e.Código).HasMaxLength(255);

                entity.Property(e => e.Dirección).HasMaxLength(255);

                entity.Property(e => e.Responsable).HasMaxLength(255);

                entity.Property(e => e.Telefono).HasMaxLength(255);
            });

            modelBuilder.Entity<CodigoOtModel>(entity =>
            {
                entity.HasKey(e => e.Cidentif);

                entity.ToTable("Codigos_OT");

                entity.Property(e => e.Cidentif)
                    .HasColumnName("CIDENTIF")
                    .HasMaxLength(5);

                entity.Property(e => e.Alias)
                    .HasColumnName("ALIAS")
                    .HasMaxLength(100);

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.Cliente).HasMaxLength(100);

                entity.Property(e => e.CodCliente).HasColumnName("COD_CLIENTE");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("FECHA_FIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("FECHA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Interna).HasColumnName("interna");

                entity.Property(e => e.Jp)
                    .HasColumnName("JP")
                    .HasMaxLength(4);

                entity.Property(e => e.Ot)
                    .HasColumnName("OT")
                    .HasMaxLength(11);

                entity.Property(e => e.Plataforma).HasMaxLength(255);

                entity.Property(e => e.Proyecto)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.TipoProyecto).HasMaxLength(50);
            });

            modelBuilder.Entity<RecursoModel>(entity =>
            {
                entity.HasKey(e => e.IdRecurso)
                    .HasName("PK_Recursos_1");

                entity.Property(e => e.IdRecurso).HasMaxLength(10);

                entity.Property(e => e.Ape1).HasMaxLength(50);

                entity.Property(e => e.Ape2).HasMaxLength(50);

                entity.Property(e => e.Clave).HasMaxLength(10);

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(9);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(160);
            });

            modelBuilder.Entity<TablaTipoTareaModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tabla_TipoTarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoTarea).HasMaxLength(255);
            });

            modelBuilder.Entity<TareaModel>(entity =>
            {
                entity.HasKey(e => e.IdIndice);

                entity.Property(e => e.IdIndice).ValueGeneratedNever();

                entity.Property(e => e.Alias).HasMaxLength(100);

                entity.Property(e => e.Bloqueo).HasMaxLength(1);

                entity.Property(e => e.Cidentif).HasMaxLength(5);

                entity.Property(e => e.DescTarea).HasMaxLength(125);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.IdDocumento).HasMaxLength(15);

                entity.Property(e => e.IdRecurso).HasMaxLength(10);

                entity.Property(e => e.Ot)
                    .HasColumnName("OT")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<UsuarioOtsModel>(entity =>
            {
                entity.HasKey(e => new { e.Idot, e.Recurso });

                entity.ToTable("Usuario_ots");

                entity.Property(e => e.Idot)
                    .HasColumnName("IDOT")
                    .HasMaxLength(5);

                entity.Property(e => e.Recurso).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
