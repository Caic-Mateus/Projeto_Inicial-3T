using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.technos.webApi.Domains;

#nullable disable

namespace senai.technos.webApi.Contexts
{
    public partial class TechnoContext : DbContext
    {
        public TechnoContext()
        {
        }

        public TechnoContext(DbContextOptions<TechnoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Relacao> Relacaos { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<TipoEquipamento> TipoEquipamentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CAIC-MATEUS-DEV; initial catalog=TechnoGear; user Id=sa; pwd=Ca07ic05;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento)
                    .HasName("PK__Equipame__75940D343E7374EA");

                entity.ToTable("Equipamento");

                entity.Property(e => e.IdEquipamento).HasColumnName("idEquipamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.IdTipoEquipamento).HasColumnName("idTipoEquipamento");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__Equipamen__idSal__46E78A0C");

                entity.HasOne(d => d.IdTipoEquipamentoNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdTipoEquipamento)
                    .HasConstraintName("FK__Equipamen__idTip__44FF419A");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Equipamen__idUsu__45F365D3");
            });

            modelBuilder.Entity<Relacao>(entity =>
            {
                entity.HasKey(e => e.IdRelacao)
                    .HasName("PK__Relacao__636378600DD19408");

                entity.ToTable("Relacao");

                entity.Property(e => e.IdRelacao).HasColumnName("idRelacao");

                entity.Property(e => e.DataEntrada).HasColumnType("date");

                entity.Property(e => e.DataSaida).HasColumnType("date");

                entity.Property(e => e.IdEquipamento).HasColumnName("idEquipamento");

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.HasOne(d => d.IdEquipamentoNavigation)
                    .WithMany(p => p.Relacaos)
                    .HasForeignKey(d => d.IdEquipamento)
                    .HasConstraintName("FK__Relacao__idEquip__49C3F6B7");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Relacaos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__Relacao__idSala__4AB81AF0");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__Sala__C4AEB19CCCEA9857");

                entity.ToTable("Sala");

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEquipamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEquipamento)
                    .HasName("PK__TipoEqui__38B9B7E3450BF7D2");

                entity.ToTable("TipoEquipamento");

                entity.Property(e => e.IdTipoEquipamento).HasColumnName("idTipoEquipamento");

                entity.Property(e => e.NomeEquipamento)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A649DA2AB7");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
