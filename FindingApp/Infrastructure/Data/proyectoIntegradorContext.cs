using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FindingApp.Domain.Entities;

#nullable disable

namespace FindingApp.Infrastructure.Data
{
    public partial class proyectoIntegradorContext : DbContext
    {
        public proyectoIntegradorContext()
        {
        }

        public proyectoIntegradorContext(DbContextOptions<proyectoIntegradorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblClub> TblClubs { get; set; }
        public virtual DbSet<TblService> TblServices { get; set; }
        public virtual DbSet<TblTournament> TblTournaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=proyectoIntegrador");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.ToTable("tbl_Account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(150)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            modelBuilder.Entity<TblClub>(entity =>
            {
                entity.ToTable("tbl_Club");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Horario).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<TblService>(entity =>
            {
                entity.ToTable("tbl_Services");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CantidadPersonas).HasMaxLength(50);

                entity.Property(e => e.Disciplina).HasMaxLength(50);

                entity.Property(e => e.EquipoEspecial).HasMaxLength(50);

                entity.Property(e => e.Horario).HasColumnType("datetime");

                entity.Property(e => e.PracticaDiscapacidad)
                    .HasMaxLength(50)
                    .HasColumnName("practicaDiscapacidad");
            });

            modelBuilder.Entity<TblTournament>(entity =>
            {
                entity.ToTable("tbl_Tournaments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bases).HasMaxLength(200);

                entity.Property(e => e.CantidadEquipo).HasMaxLength(50);

                entity.Property(e => e.CostoIns)
                    .HasMaxLength(50)
                    .HasColumnName("costoIns");

                entity.Property(e => e.Disciplina).HasMaxLength(50);

                entity.Property(e => e.Lugares).HasMaxLength(100);

                entity.Property(e => e.NumRondas)
                    .HasMaxLength(50)
                    .HasColumnName("numRondas");

                entity.Property(e => e.Tipo).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
