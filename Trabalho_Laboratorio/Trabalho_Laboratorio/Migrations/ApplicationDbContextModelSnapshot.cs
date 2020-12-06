﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trabalho_Laboratorio.Data;

namespace Trabalho_Laboratorio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Administrador", b =>
                {
                    b.Property<int>("IdAdmin")
                        .HasColumnName("ID_Admin")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdAdmin")
                        .HasName("PK__Administ__69F56766F47002BB");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.AgendarPrato", b =>
                {
                    b.Property<int>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Agendamento")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataMarcacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Data_Marcacao")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DataDoAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Data_Do_Agendamento")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdRestaurante")
                        .HasColumnName("ID_Restaurante")
                        .HasColumnType("int");

                    b.Property<int>("IdPrato")
                        .HasColumnName("ID_Prato")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoExtra")
                        .IsRequired()
                        .HasColumnName("Descricao_Extra")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Destaque")
                        .HasColumnType("bit");

                    b.Property<string>("FotoExtra")
                        .IsRequired()
                        .HasColumnName("Foto_Extra")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<decimal>("Preco")
                        .HasColumnName("Preco")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("IdAgendamento", "DataMarcacao", "DataDoAgendamento", "IdRestaurante", "IdPrato")
                        .HasName("PK__Agendar___28954093A2E8B8AC");

                    b.HasIndex("IdPrato");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Agendar_Prato");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Bloqueio", b =>
                {
                    b.Property<int>("IdBloqueio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Bloqueio")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUtilizador")
                        .HasColumnName("ID_Utilizador")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("IdBloqueio", "IdUtilizador")
                        .HasName("PK__Bloqueio__0247998668B16990");

                    b.HasIndex("IdUtilizador");

                    b.ToTable("Bloqueio");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Clientes", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_Cliente")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdCliente")
                        .HasName("PK__Clientes__E005FBFF45F8C6B5");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClientePratoFavorito", b =>
                {
                    b.Property<int>("IdClientePratoFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Cliente_Prato_Favorito")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("IdPrato")
                        .HasColumnName("ID_Prato")
                        .HasColumnType("int");

                    b.HasKey("IdClientePratoFavorito", "IdCliente", "IdPrato")
                        .HasName("PK__Guardar___80B846309A59961E");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPrato");

                    b.ToTable("Guardar_Cliente_Prato_Favorito");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClienteRestauranteFavorito", b =>
                {
                    b.Property<int>("IdClienteRestauranteFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Cliente_Restaurante_Favorito")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("IdRestaurante")
                        .HasColumnName("ID_Restaurante")
                        .HasColumnType("int");

                    b.HasKey("IdClienteRestauranteFavorito", "IdCliente", "IdRestaurante")
                        .HasName("PK__Guardar___137DC26AC4AA310F");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Guardar_Cliente_Restaurante_Favorito");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Horario")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRestaurante")
                        .HasColumnName("ID_Restaurante")
                        .HasColumnType("int");

                    b.Property<int>("DiaSemana")
                        .HasColumnName("Dia_Semana")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HoraDeEntrada")
                        .HasColumnName("Hora_De_Entrada")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraDeSaida")
                        .HasColumnName("Hora_De_Saida")
                        .HasColumnType("time");

                    b.HasKey("IdHorario", "IdRestaurante")
                        .HasName("PK__Horario__79FF2F4A0349A45A");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.PalavrasChave", b =>
                {
                    b.Property<int>("IdPalavrasChave")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Palavras_Chave")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUtilizador")
                        .HasColumnName("ID_Utilizador")
                        .HasColumnType("int");

                    b.Property<string>("Palavra")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdPalavrasChave", "IdUtilizador")
                        .HasName("PK__Palavras__19432DAB64C5CEFA");

                    b.HasIndex("IdUtilizador");

                    b.ToTable("Palavras_Chave");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Prato", b =>
                {
                    b.Property<int>("IdPrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Prato")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoDefault")
                        .IsRequired()
                        .HasColumnName("Descricao_Default")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("FotoDefault")
                        .IsRequired()
                        .HasColumnName("Foto_Default")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("TipoPrato")
                        .IsRequired()
                        .HasColumnName("Tipo_Prato")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdPrato")
                        .HasName("PK__Prato__7B3DC2D27A5A6DF4");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Restaurante", b =>
                {
                    b.Property<int>("IdRestaurante")
                        .HasColumnName("ID_Restaurante")
                        .HasColumnType("int");

                    b.Property<string>("DiaDeDescanso")
                        .IsRequired()
                        .HasColumnName("Dia_De_Descanso")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("GPS")
                        .HasColumnName("GPS")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("NomeRestaurante")
                        .IsRequired()
                        .HasColumnName("Nome_Restaurante")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("StatusRestaurante")
                        .HasColumnName("Status_Restaurante")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TipoServico")
                        .IsRequired()
                        .HasColumnName("Tipo_Servico")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdRestaurante")
                        .HasName("PK__Restaura__E5F26F71819C7641");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Utilizador", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Utilizador")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.Property<string>("EnderecoCodigoPostal")
                        .IsRequired()
                        .HasColumnName("Endereco_CodigoPostal")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("EnderecoLocalidade")
                        .IsRequired()
                        .HasColumnName("Endereco_Localidade")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("EnderecoMorada")
                        .IsRequired()
                        .HasColumnName("Endereco_Morada")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("_Password")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdUtilizador")
                        .HasName("PK__Utilizad__020698175D4E0795");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Administrador", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdAdminNavigation")
                        .WithOne("Administrador")
                        .HasForeignKey("Trabalho_Laboratorio.Models.Administrador", "IdAdmin")
                        .HasConstraintName("FK__Administr__ID_Ad__2F10007B")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.AgendarPrato", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Prato", "IdPratoNavigation")
                        .WithMany("AgendarPrato")
                        .HasForeignKey("IdPrato")
                        .HasConstraintName("FK__Agendar_P__ID_Pr__44FF419A")
                        .IsRequired();

                    b.HasOne("Trabalho_Laboratorio.Models.Restaurante", "IdRestauranteNavigation")
                        .WithMany("AgendarPrato")
                        .HasForeignKey("IdRestaurante")
                        .HasConstraintName("FK__Agendar_P__ID_Re__440B1D61")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Bloqueio", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdUtilizadorNavigation")
                        .WithMany("Bloqueio")
                        .HasForeignKey("IdUtilizador")
                        .HasConstraintName("FK__Bloqueio__ID_Uti__267ABA7A")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Clientes", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdClienteNavigation")
                        .WithOne("Clientes")
                        .HasForeignKey("Trabalho_Laboratorio.Models.Clientes", "IdCliente")
                        .HasConstraintName("FK__Clientes__ID_Cli__2C3393D0")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClientePratoFavorito", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Clientes", "IdClienteNavigation")
                        .WithMany("GuardarClientePratoFavorito")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Guardar_C__ID_Cl__398D8EEE")
                        .IsRequired();

                    b.HasOne("Trabalho_Laboratorio.Models.Prato", "IdPratoNavigation")
                        .WithMany("GuardarClientePratoFavorito")
                        .HasForeignKey("IdPrato")
                        .HasConstraintName("FK__Guardar_C__ID_Pr__3A81B327")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClienteRestauranteFavorito", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Clientes", "IdClienteNavigation")
                        .WithMany("GuardarClienteRestauranteFavorito")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Guardar_C__ID_Cl__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("Trabalho_Laboratorio.Models.Restaurante", "IdRestauranteNavigation")
                        .WithMany("GuardarClienteRestauranteFavorito")
                        .HasForeignKey("IdRestaurante")
                        .HasConstraintName("FK__Guardar_C__ID_Re__3E52440B")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Horario", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Restaurante", "IdRestauranteNavigation")
                        .WithMany("Horario")
                        .HasForeignKey("IdRestaurante")
                        .HasConstraintName("FK__Horario__ID_Rest__34C8D9D1")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.PalavrasChave", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdUtilizadorNavigation")
                        .WithMany("PalavrasChave")
                        .HasForeignKey("IdUtilizador")
                        .HasConstraintName("FK__Palavras___ID_Ut__29572725")
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Restaurante", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdRestauranteNavigation")
                        .WithOne("Restaurante")
                        .HasForeignKey("Trabalho_Laboratorio.Models.Restaurante", "IdRestaurante")
                        .HasConstraintName("FK__Restauran__ID_Re__31EC6D26")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
