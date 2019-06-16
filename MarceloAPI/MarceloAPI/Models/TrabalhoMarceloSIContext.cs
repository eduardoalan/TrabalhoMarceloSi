using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarceloAPI.Models
{
    public partial class TrabalhoMarceloSIContext : DbContext
    {
        public TrabalhoMarceloSIContext()
        {
        }

        public TrabalhoMarceloSIContext(DbContextOptions<TrabalhoMarceloSIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Imobiliaria> Imobiliaria { get; set; }
        public virtual DbSet<Imovel> Imovel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=TrabalhoMarceloSI;Port=5433;User Id=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Imobiliaria>(entity =>
            {
                entity.HasKey(e => e.IdImobiliaria)
                    .HasName("imobiliaria_pk");

                entity.ToTable("imobiliaria");

                entity.Property(e => e.IdImobiliaria)
                    .HasColumnName("id_imobiliaria")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("character varying(100)");
            });

            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.HasKey(e => e.IdImovel)
                    .HasName("imovel_pk");

                entity.ToTable("imovel");

                entity.Property(e => e.IdImovel)
                    .HasColumnName("id_imovel")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasColumnType("character varying(15)");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.IdImobiliaria).HasColumnName("id_imobiliaria");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasColumnType("character varying(100)");

                entity.HasOne(d => d.IdImobiliariaNavigation)
                    .WithMany(p => p.Imovel)
                    .HasForeignKey(d => d.IdImobiliaria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imobiliaria_imovel_fk");
            });
        }
    }
}
