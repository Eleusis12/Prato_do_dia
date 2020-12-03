using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trabalho_Laboratorio.Models;

#nullable disable

namespace Trabalho_Laboratorio.Data
{
    public partial class RestaurantesContext : DbContext
    {
        public RestaurantesContext()
        {
        }

        public RestaurantesContext(DbContextOptions<RestaurantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<AgendarPrato> AgendarPratos { get; set; }
        public virtual DbSet<Bloqueio> Bloqueios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<GuardarClientePratoFavorito> GuardarClientePratoFavoritos { get; set; }
        public virtual DbSet<GuardarClienteRestauranteFavorito> GuardarClienteRestauranteFavoritos { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<PalavrasChave> PalavrasChaves { get; set; }
        public virtual DbSet<Prato> Pratos { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<Utilizador> Utilizadors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Trabalho_LaboratorioContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Administ__69F56766CDF5DCEB");

                entity.Property(e => e.IdAdmin).ValueGeneratedNever();

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithOne(p => p.Administrador)
                    .HasForeignKey<Administrador>(d => d.IdAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__ID_Ad__2F10007B");
            });

            modelBuilder.Entity<AgendarPrato>(entity =>
            {
                entity.HasKey(e => new { e.IdAgendamento, e.DataMarcacao, e.DataDoAgendamento, e.IdRestaurante, e.IdPrato })
                    .HasName("PK__Agendar___28954093FF2705E9");

                entity.Property(e => e.IdAgendamento).ValueGeneratedOnAdd();

                entity.Property(e => e.DataMarcacao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataDoAgendamento).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithMany(p => p.AgendarPratos)
                    .HasForeignKey(d => d.IdPrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agendar_P__ID_Pr__44FF419A");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.AgendarPratos)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agendar_P__ID_Re__440B1D61");
            });

            modelBuilder.Entity<Bloqueio>(entity =>
            {
                entity.HasKey(e => new { e.IdBloqueio, e.IdUtilizador })
                    .HasName("PK__Bloqueio__02479986E2A213CD");

                entity.Property(e => e.IdBloqueio).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithMany(p => p.Bloqueios)
                    .HasForeignKey(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bloqueio__ID_Uti__267ABA7A");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__E005FBFFEF97B660");

                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clientes__ID_Cli__2C3393D0");
            });

            modelBuilder.Entity<GuardarClientePratoFavorito>(entity =>
            {
                entity.HasKey(e => new { e.IdClientePratoFavorito, e.IdCliente, e.IdPrato })
                    .HasName("PK__Guardar___80B846306A355AF2");

                entity.Property(e => e.IdClientePratoFavorito).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.GuardarClientePratoFavoritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guardar_C__ID_Cl__398D8EEE");

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithMany(p => p.GuardarClientePratoFavoritos)
                    .HasForeignKey(d => d.IdPrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guardar_C__ID_Pr__3A81B327");
            });

            modelBuilder.Entity<GuardarClienteRestauranteFavorito>(entity =>
            {
                entity.HasKey(e => new { e.IdClienteRestauranteFavorito, e.IdCliente, e.IdRestaurante })
                    .HasName("PK__Guardar___137DC26A0DA3AF18");

                entity.Property(e => e.IdClienteRestauranteFavorito).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.GuardarClienteRestauranteFavoritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guardar_C__ID_Cl__3D5E1FD2");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.GuardarClienteRestauranteFavoritos)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Guardar_C__ID_Re__3E52440B");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => new { e.IdHorario, e.IdRestaurante })
                    .HasName("PK__Horario__79FF2F4AF51280AD");

                entity.Property(e => e.IdHorario).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Horario__ID_Rest__34C8D9D1");
            });

            modelBuilder.Entity<PalavrasChave>(entity =>
            {
                entity.HasKey(e => new { e.IdPalavrasChave, e.IdUtilizador })
                    .HasName("PK__Palavras__19432DABA6CD5B87");

                entity.Property(e => e.IdPalavrasChave).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithMany(p => p.PalavrasChaves)
                    .HasForeignKey(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Palavras___ID_Ut__29572725");
            });

            modelBuilder.Entity<Prato>(entity =>
            {
                entity.HasKey(e => e.IdPrato)
                    .HasName("PK__Prato__7B3DC2D2BFF287A7");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante)
                    .HasName("PK__Restaura__E5F26F71AA70A2FC");

                entity.Property(e => e.IdRestaurante).ValueGeneratedNever();

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithOne(p => p.Restaurante)
                    .HasForeignKey<Restaurante>(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__ID_Re__31EC6D26");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador)
                    .HasName("PK__Utilizad__020698178DEB059E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
