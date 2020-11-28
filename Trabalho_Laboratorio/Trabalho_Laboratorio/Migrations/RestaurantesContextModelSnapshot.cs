﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trabalho_Laboratorio.Data;

namespace Trabalho_Laboratorio.Migrations
{
    [DbContext(typeof(RestaurantesContext))]
    partial class RestaurantesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Administrador", b =>
                {
                    b.Property<int>("IdAdmin")
                        .HasColumnType("int")
                        .HasColumnName("ID_Admin");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdAdmin")
                        .HasName("PK__Administ__69F56766CDF5DCEB");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.AgendarPrato", b =>
                {
                    b.Property<int>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Agendamento")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataMarcacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Data_Marcacao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DataDoAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Data_Do_Agendamento")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdRestaurante")
                        .HasColumnType("int")
                        .HasColumnName("ID_Restaurante");

                    b.Property<int>("IdPrato")
                        .HasColumnType("int")
                        .HasColumnName("ID_Prato");

                    b.Property<string>("DescricaoExtra")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Descricao_Extra");

                    b.Property<bool>("Destaque")
                        .HasColumnType("bit");

                    b.Property<string>("FotoExtra")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Foto_Extra");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.HasKey("IdAgendamento", "DataMarcacao", "DataDoAgendamento", "IdRestaurante", "IdPrato")
                        .HasName("PK__Agendar___28954093FF2705E9");

                    b.HasIndex("IdPrato");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Agendar_Prato");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Bloqueio", b =>
                {
                    b.Property<int>("IdBloqueio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Bloqueio")
                        .UseIdentityColumn();

                    b.Property<int>("IdUtilizador")
                        .HasColumnType("int")
                        .HasColumnName("ID_Utilizador");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IdBloqueio", "IdUtilizador")
                        .HasName("PK__Bloqueio__02479986E2A213CD");

                    b.HasIndex("IdUtilizador");

                    b.ToTable("Bloqueio");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("ID_Cliente");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCliente")
                        .HasName("PK__Clientes__E005FBFFEF97B660");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClientePratoFavorito", b =>
                {
                    b.Property<int>("IdClientePratoFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Cliente_Prato_Favorito")
                        .UseIdentityColumn();

                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("ID_Cliente");

                    b.Property<int>("IdPrato")
                        .HasColumnType("int")
                        .HasColumnName("ID_Prato");

                    b.HasKey("IdClientePratoFavorito", "IdCliente", "IdPrato")
                        .HasName("PK__Guardar___80B846306A355AF2");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPrato");

                    b.ToTable("Guardar_Cliente_Prato_Favorito");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClienteRestauranteFavorito", b =>
                {
                    b.Property<int>("IdClienteRestauranteFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Cliente_Restaurante_Favorito")
                        .UseIdentityColumn();

                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("ID_Cliente");

                    b.Property<int>("IdRestaurante")
                        .HasColumnType("int")
                        .HasColumnName("ID_Restaurante");

                    b.HasKey("IdClienteRestauranteFavorito", "IdCliente", "IdRestaurante")
                        .HasName("PK__Guardar___137DC26A0DA3AF18");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Guardar_Cliente_Restaurante_Favorito");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Horario")
                        .UseIdentityColumn();

                    b.Property<int>("IdRestaurante")
                        .HasColumnType("int")
                        .HasColumnName("ID_Restaurante");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("int")
                        .HasColumnName("Dia_Semana");

                    b.Property<TimeSpan>("HoraDeEntrada")
                        .HasColumnType("time")
                        .HasColumnName("Hora_De_Entrada");

                    b.Property<TimeSpan>("HoraDeSaida")
                        .HasColumnType("time")
                        .HasColumnName("Hora_De_Saida");

                    b.HasKey("IdHorario", "IdRestaurante")
                        .HasName("PK__Horario__79FF2F4AF51280AD");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.PalavrasChave", b =>
                {
                    b.Property<int>("IdPalavrasChave")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Palavras_Chave")
                        .UseIdentityColumn();

                    b.Property<int>("IdUtilizador")
                        .HasColumnType("int")
                        .HasColumnName("ID_Utilizador");

                    b.Property<string>("Palavra")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdPalavrasChave", "IdUtilizador")
                        .HasName("PK__Palavras__19432DABA6CD5B87");

                    b.HasIndex("IdUtilizador");

                    b.ToTable("Palavras_Chave");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Prato", b =>
                {
                    b.Property<int>("IdPrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Prato")
                        .UseIdentityColumn();

                    b.Property<string>("DescricaoDefault")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Descricao_Default");

                    b.Property<string>("FotoDefault")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Foto_Default");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Nome");

                    b.Property<string>("TipoPrato")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Tipo_Prato");

                    b.HasKey("IdPrato")
                        .HasName("PK__Prato__7B3DC2D2BFF287A7");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Restaurante", b =>
                {
                    b.Property<int>("IdRestaurante")
                        .HasColumnType("int")
                        .HasColumnName("ID_Restaurante");

                    b.Property<string>("DiaDeDescanso")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Dia_De_Descanso");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NomeRestaurante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome_Restaurante");

                    b.Property<bool>("StatusRestaurante")
                        .HasColumnType("bit")
                        .HasColumnName("Status_Restaurante");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TipoServico")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Tipo_Servico");

                    b.HasKey("IdRestaurante")
                        .HasName("PK__Restaura__E5F26F71AA70A2FC");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Utilizador", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Utilizador")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.Property<string>("EnderecoCodigoPostal")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Endereco_CodigoPostal");

                    b.Property<string>("EnderecoLocalidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Endereco_Localidade");

                    b.Property<string>("EnderecoMorada")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Endereco_Morada");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("_Password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdUtilizador")
                        .HasName("PK__Utilizad__020698178DEB059E");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Administrador", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdAdminNavigation")
                        .WithOne("Administrador")
                        .HasForeignKey("Trabalho_Laboratorio.Models.Administrador", "IdAdmin")
                        .HasConstraintName("FK__Administr__ID_Ad__2F10007B")
                        .IsRequired();

                    b.Navigation("IdAdminNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.AgendarPrato", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Prato", "IdPratoNavigation")
                        .WithMany("AgendarPratos")
                        .HasForeignKey("IdPrato")
                        .HasConstraintName("FK__Agendar_P__ID_Pr__44FF419A")
                        .IsRequired();

                    b.HasOne("Trabalho_Laboratorio.Models.Restaurante", "IdRestauranteNavigation")
                        .WithMany("AgendarPratos")
                        .HasForeignKey("IdRestaurante")
                        .HasConstraintName("FK__Agendar_P__ID_Re__440B1D61")
                        .IsRequired();

                    b.Navigation("IdPratoNavigation");

                    b.Navigation("IdRestauranteNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Bloqueio", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdUtilizadorNavigation")
                        .WithMany("Bloqueios")
                        .HasForeignKey("IdUtilizador")
                        .HasConstraintName("FK__Bloqueio__ID_Uti__267ABA7A")
                        .IsRequired();

                    b.Navigation("IdUtilizadorNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Cliente", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdClienteNavigation")
                        .WithOne("Cliente")
                        .HasForeignKey("Trabalho_Laboratorio.Models.Cliente", "IdCliente")
                        .HasConstraintName("FK__Clientes__ID_Cli__2C3393D0")
                        .IsRequired();

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClientePratoFavorito", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Cliente", "IdClienteNavigation")
                        .WithMany("GuardarClientePratoFavoritos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Guardar_C__ID_Cl__398D8EEE")
                        .IsRequired();

                    b.HasOne("Trabalho_Laboratorio.Models.Prato", "IdPratoNavigation")
                        .WithMany("GuardarClientePratoFavoritos")
                        .HasForeignKey("IdPrato")
                        .HasConstraintName("FK__Guardar_C__ID_Pr__3A81B327")
                        .IsRequired();

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdPratoNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.GuardarClienteRestauranteFavorito", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Cliente", "IdClienteNavigation")
                        .WithMany("GuardarClienteRestauranteFavoritos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Guardar_C__ID_Cl__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("Trabalho_Laboratorio.Models.Restaurante", "IdRestauranteNavigation")
                        .WithMany("GuardarClienteRestauranteFavoritos")
                        .HasForeignKey("IdRestaurante")
                        .HasConstraintName("FK__Guardar_C__ID_Re__3E52440B")
                        .IsRequired();

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdRestauranteNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Horario", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Restaurante", "IdRestauranteNavigation")
                        .WithMany("Horarios")
                        .HasForeignKey("IdRestaurante")
                        .HasConstraintName("FK__Horario__ID_Rest__34C8D9D1")
                        .IsRequired();

                    b.Navigation("IdRestauranteNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.PalavrasChave", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdUtilizadorNavigation")
                        .WithMany("PalavrasChaves")
                        .HasForeignKey("IdUtilizador")
                        .HasConstraintName("FK__Palavras___ID_Ut__29572725")
                        .IsRequired();

                    b.Navigation("IdUtilizadorNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Restaurante", b =>
                {
                    b.HasOne("Trabalho_Laboratorio.Models.Utilizador", "IdRestauranteNavigation")
                        .WithOne("Restaurante")
                        .HasForeignKey("Trabalho_Laboratorio.Models.Restaurante", "IdRestaurante")
                        .HasConstraintName("FK__Restauran__ID_Re__31EC6D26")
                        .IsRequired();

                    b.Navigation("IdRestauranteNavigation");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Cliente", b =>
                {
                    b.Navigation("GuardarClientePratoFavoritos");

                    b.Navigation("GuardarClienteRestauranteFavoritos");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Prato", b =>
                {
                    b.Navigation("AgendarPratos");

                    b.Navigation("GuardarClientePratoFavoritos");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Restaurante", b =>
                {
                    b.Navigation("AgendarPratos");

                    b.Navigation("GuardarClienteRestauranteFavoritos");

                    b.Navigation("Horarios");
                });

            modelBuilder.Entity("Trabalho_Laboratorio.Models.Utilizador", b =>
                {
                    b.Navigation("Administrador");

                    b.Navigation("Bloqueios");

                    b.Navigation("Cliente");

                    b.Navigation("PalavrasChaves");

                    b.Navigation("Restaurante");
                });
#pragma warning restore 612, 618
        }
    }
}
