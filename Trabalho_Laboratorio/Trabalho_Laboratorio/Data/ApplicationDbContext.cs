using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Data
{
	public partial class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Administrador> Administrador { get; set; }
		public virtual DbSet<AgendarPrato> AgendarPrato { get; set; }
		public virtual DbSet<Bloqueio> Bloqueio { get; set; }
		public virtual DbSet<Clientes> Clientes { get; set; }
		public virtual DbSet<GuardarClientePratoFavorito> GuardarClientePratoFavorito { get; set; }
		public virtual DbSet<GuardarClienteRestauranteFavorito> GuardarClienteRestauranteFavorito { get; set; }
		public virtual DbSet<Horario> Horario { get; set; }
		public virtual DbSet<PalavrasChave> PalavrasChave { get; set; }
		public virtual DbSet<Prato> Prato { get; set; }
		public virtual DbSet<Restaurante> Restaurante { get; set; }
		public virtual DbSet<Utilizador> Utilizador { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//if (!optionsBuilder.IsConfigured)
			//{
			//	optionsBuilder.UseSqlServer("name=DefaultConnection");
			//}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Administrador>(entity =>
			{
				entity.HasKey(e => e.IdAdmin)
					.HasName("PK__Administ__69F56766F47002BB");

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
					.HasName("PK__Agendar___28954093A2E8B8AC");

				entity.Property(e => e.IdAgendamento).ValueGeneratedOnAdd();

				entity.Property(e => e.DataMarcacao).HasDefaultValueSql("(getdate())");

				entity.Property(e => e.DataDoAgendamento).HasDefaultValueSql("(getdate())");

				entity.HasOne(d => d.IdPratoNavigation)
					.WithMany(p => p.AgendarPrato)
					.HasForeignKey(d => d.IdPrato)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Agendar_P__ID_Pr__44FF419A");

				entity.HasOne(d => d.IdRestauranteNavigation)
					.WithMany(p => p.AgendarPrato)
					.HasForeignKey(d => d.IdRestaurante)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Agendar_P__ID_Re__440B1D61");
			});

			modelBuilder.Entity<Bloqueio>(entity =>
			{
				entity.HasKey(e => new { e.IdBloqueio, e.IdUtilizador })
					.HasName("PK__Bloqueio__0247998668B16990");

				entity.Property(e => e.IdBloqueio).ValueGeneratedOnAdd();

				entity.HasOne(d => d.IdUtilizadorNavigation)
					.WithMany(p => p.Bloqueio)
					.HasForeignKey(d => d.IdUtilizador)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Bloqueio__ID_Uti__267ABA7A");
			});

			modelBuilder.Entity<Clientes>(entity =>
			{
				entity.HasKey(e => e.IdCliente)
					.HasName("PK__Clientes__E005FBFF45F8C6B5");

				entity.Property(e => e.IdCliente).ValueGeneratedNever();

				entity.HasOne(d => d.IdClienteNavigation)
					.WithOne(p => p.Clientes)
					.HasForeignKey<Clientes>(d => d.IdCliente)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Clientes__ID_Cli__2C3393D0");
			});

			modelBuilder.Entity<GuardarClientePratoFavorito>(entity =>
			{
				entity.HasKey(e => new { e.IdClientePratoFavorito, e.IdCliente, e.IdPrato })
					.HasName("PK__Guardar___80B846309A59961E");

				entity.Property(e => e.IdClientePratoFavorito).ValueGeneratedOnAdd();

				entity.HasOne(d => d.IdClienteNavigation)
					.WithMany(p => p.GuardarClientePratoFavorito)
					.HasForeignKey(d => d.IdCliente)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Guardar_C__ID_Cl__398D8EEE");

				entity.HasOne(d => d.IdPratoNavigation)
					.WithMany(p => p.GuardarClientePratoFavorito)
					.HasForeignKey(d => d.IdPrato)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Guardar_C__ID_Pr__3A81B327");
			});

			modelBuilder.Entity<GuardarClienteRestauranteFavorito>(entity =>
			{
				entity.HasKey(e => new { e.IdClienteRestauranteFavorito, e.IdCliente, e.IdRestaurante })
					.HasName("PK__Guardar___137DC26AC4AA310F");

				entity.Property(e => e.IdClienteRestauranteFavorito).ValueGeneratedOnAdd();

				entity.HasOne(d => d.IdClienteNavigation)
					.WithMany(p => p.GuardarClienteRestauranteFavorito)
					.HasForeignKey(d => d.IdCliente)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Guardar_C__ID_Cl__3D5E1FD2");

				entity.HasOne(d => d.IdRestauranteNavigation)
					.WithMany(p => p.GuardarClienteRestauranteFavorito)
					.HasForeignKey(d => d.IdRestaurante)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Guardar_C__ID_Re__3E52440B");
			});

			modelBuilder.Entity<Horario>(entity =>
			{
				entity.HasKey(e => new { e.IdHorario, e.IdRestaurante })
					.HasName("PK__Horario__79FF2F4A0349A45A");

				entity.Property(e => e.IdHorario).ValueGeneratedOnAdd();

				entity.HasOne(d => d.IdRestauranteNavigation)
					.WithMany(p => p.Horario)
					.HasForeignKey(d => d.IdRestaurante)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Horario__ID_Rest__34C8D9D1");
			});

			modelBuilder.Entity<PalavrasChave>(entity =>
			{
				entity.HasKey(e => new { e.IdPalavrasChave, e.IdUtilizador })
					.HasName("PK__Palavras__19432DAB64C5CEFA");

				entity.Property(e => e.IdPalavrasChave).ValueGeneratedOnAdd();

				entity.HasOne(d => d.IdUtilizadorNavigation)
					.WithMany(p => p.PalavrasChave)
					.HasForeignKey(d => d.IdUtilizador)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Palavras___ID_Ut__29572725");
			});

			modelBuilder.Entity<Prato>(entity =>
			{
				entity.HasKey(e => e.IdPrato)
					.HasName("PK__Prato__7B3DC2D27A5A6DF4");
			});

			modelBuilder.Entity<Restaurante>(entity =>
			{
				entity.HasKey(e => e.IdRestaurante)
					.HasName("PK__Restaura__E5F26F71819C7641");

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
					.HasName("PK__Utilizad__020698175D4E0795");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}