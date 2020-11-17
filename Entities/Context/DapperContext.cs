using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities.Models;

namespace Entities.Context
{
    public partial class DapperContext : DbContext
    {
        public DapperContext()
        {
        }

        public DapperContext(DbContextOptions<DapperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficios> Beneficios { get; set; }
        public virtual DbSet<BeneficiosPorOferta> BeneficiosPorOferta { get; set; }
        public virtual DbSet<Conocimientos> Conocimientos { get; set; }
        public virtual DbSet<ConocimientosPorOferta> ConocimientosPorOferta { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Fuentes> Fuentes { get; set; }
        public virtual DbSet<Habilidades> Habilidades { get; set; }
        public virtual DbSet<HabilidadesPorOferta> HabilidadesPorOferta { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<Ofertas> Ofertas { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<Requisitos> Requisitos { get; set; }
        public virtual DbSet<RequisitosPorOferta> RequisitosPorOferta { get; set; }
        public virtual DbSet<TiposConocimiento> TiposConocimiento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficios>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio);

                entity.HasIndex(e => e.Beneficio)
                    .HasName("IX_Beneficios")
                    .IsUnique();

                entity.Property(e => e.Beneficio)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BeneficiosPorOferta>(entity =>
            {
                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.BeneficiosPorOferta)
                    .HasForeignKey(d => d.IdBeneficio)
                    .HasConstraintName("FK_BeneficiosPorOferta_Beneficios");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.BeneficiosPorOferta)
                    .HasForeignKey(d => d.IdOferta)
                    .HasConstraintName("FK_BeneficiosPorOferta_Ofertas");
            });

            modelBuilder.Entity<Conocimientos>(entity =>
            {
                entity.HasKey(e => e.IdConocimiento);

                entity.HasIndex(e => e.Conocimiento)
                    .HasName("IX_Conocimientos")
                    .IsUnique();

                entity.Property(e => e.Conocimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoConocimientoNavigation)
                    .WithMany(p => p.Conocimientos)
                    .HasForeignKey(d => d.IdTipoConocimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conocimientos_TiposConocimiento");
            });

            modelBuilder.Entity<ConocimientosPorOferta>(entity =>
            {
                entity.HasOne(d => d.IdConocimientoNavigation)
                    .WithMany(p => p.ConocimientosPorOferta)
                    .HasForeignKey(d => d.IdConocimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConocimientosPorOferta_Conocimientos");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.ConocimientosPorOferta)
                    .HasForeignKey(d => d.IdOferta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConocimientosPorOferta_Ofertas");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.HasIndex(e => e.Empresa)
                    .HasName("IX_Empresas")
                    .IsUnique();

                entity.Property(e => e.Empresa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fuentes>(entity =>
            {
                entity.HasKey(e => e.IdFuente);

                entity.HasIndex(e => e.Fuente)
                    .HasName("IX_Fuentes")
                    .IsUnique();

                entity.Property(e => e.Fuente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidades>(entity =>
            {
                entity.HasKey(e => e.IdHabilidad);

                entity.HasIndex(e => e.Habilidad)
                    .HasName("IX_Habilidades")
                    .IsUnique();

                entity.Property(e => e.Habilidad)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HabilidadesPorOferta>(entity =>
            {
                entity.HasOne(d => d.IdHabilidadNavigation)
                    .WithMany(p => p.HabilidadesPorOferta)
                    .HasForeignKey(d => d.IdHabilidad)
                    .HasConstraintName("FK_HabilidadesPorOferta_Habilidades");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.HabilidadesPorOferta)
                    .HasForeignKey(d => d.IdOferta)
                    .HasConstraintName("FK_HabilidadesPorOferta_Ofertas");
            });

            modelBuilder.Entity<Municipios>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ofertas>(entity =>
            {
                entity.HasKey(e => e.IdOferta);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.SalarioMax)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalarioMin)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Ofertas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_Ofertas_Empresas");

                entity.HasOne(d => d.IdFuenteNavigation)
                    .WithMany(p => p.Ofertas)
                    .HasForeignKey(d => d.IdFuente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ofertas_Fuentes");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Ofertas)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ofertas_Perfiles");
            });

            modelBuilder.Entity<Perfiles>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.HasIndex(e => e.Perfil)
                    .HasName("IX_Perfiles")
                    .IsUnique();

                entity.Property(e => e.Perfil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requisitos>(entity =>
            {
                entity.HasKey(e => e.IdRequisito);

                entity.HasIndex(e => e.Requisito)
                    .HasName("IX_Requisitos")
                    .IsUnique();

                entity.Property(e => e.Requisito)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequisitosPorOferta>(entity =>
            {
                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.RequisitosPorOferta)
                    .HasForeignKey(d => d.IdOferta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequisitosPorOferta_Ofertas");

                entity.HasOne(d => d.IdRequisitoNavigation)
                    .WithMany(p => p.RequisitosPorOferta)
                    .HasForeignKey(d => d.IdRequisito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequisitosPorOferta_Requisitos");
            });

            modelBuilder.Entity<TiposConocimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoConocimiento);

                entity.HasIndex(e => e.TipoConocimiento)
                    .HasName("IX_TiposConocimiento")
                    .IsUnique();

                entity.Property(e => e.TipoConocimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
