using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class NettrimDbContext : DbContext
    {
        public NettrimDbContext()
        {
        }

        public NettrimDbContext(DbContextOptions<NettrimDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EmpleadoSetting> EmpleadoSetting { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<ProyectoEmpleado> ProyectoEmpleado { get; set; }
        public virtual DbSet<RegistroHoras> RegistroHoras { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<TareaAdjuntos> TareaAdjuntos { get; set; }
        public virtual DbSet<TipoTarea> TipoTarea { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Responsable).HasMaxLength(255);

                entity.Property(e => e.Telefono).HasMaxLength(15);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Apellido1).HasMaxLength(50);

                entity.Property(e => e.Apellido2).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EmpleadoSetting>(entity =>
            {
                entity.Property(e => e.HoraEntradaDefault).HasMaxLength(15);
                entity.Property(e => e.HoraSalidaDefault).HasMaxLength(15);
                entity.Property(e => e.TiempoDescansoDefault).HasMaxLength(15);

                entity.HasOne(d => d.Empleado)
                   .WithMany(p => p.EmpleadoSetting)
                   .HasForeignKey(d => d.EmpleadoId)
                   .HasConstraintName("FK_EmpleadoSetting_Empleado");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Area).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Plataforma).HasMaxLength(100);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Proyecto_Cliente");
            });

            modelBuilder.Entity<ProyectoEmpleado>(entity =>
            {
                entity.HasKey(e => new { e.ProyectoId, e.EmpleadoId });

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.ProyectoEmpleado)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProyectoEmpleado_Empleado");

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.ProyectoEmpleado)
                    .HasForeignKey(d => d.ProyectoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProyectoEmpleado_Proyecto");
            });

            modelBuilder.Entity<RegistroHoras>(entity =>
            {
                entity.Property(e => e.DiaRegistro).HasColumnType("date");

                entity.Property(e => e.HoraEntrada)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.HoraSalida)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.HorasTrabajadas)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TiempoDescanso)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Tarea)
                    .WithMany(p => p.RegistroHoras)
                    .HasForeignKey(d => d.TareaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistroHoras_Tarea");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.FechaInicio).HasColumnType("date");

               

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.ProyectoId)
                    .HasConstraintName("FK_Tarea_Proyecto");

                entity.HasOne(d => d.TipoTarea)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.TipoTareaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarea_TipoTarea");
            });

            modelBuilder.Entity<TareaAdjuntos>(entity =>
            {
                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Tarea)
                    .WithMany(p => p.TareaAdjuntos)
                    .HasForeignKey(d => d.TareaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TareaAdjuntos_Tarea");
            });

            modelBuilder.Entity<TipoTarea>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
