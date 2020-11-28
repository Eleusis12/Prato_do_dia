using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalho_Laboratorio.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    ID_Prato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Prato = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descricao_Default = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Foto_Default = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prato__7B3DC2D2BFF287A7", x => x.ID_Prato);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    ID_Utilizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    _Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Morada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco_CodigoPostal = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Endereco_Localidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Utilizad__020698178DEB059E", x => x.ID_Utilizador);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    ID_Admin = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__69F56766CDF5DCEB", x => x.ID_Admin);
                    table.ForeignKey(
                        name: "FK__Administr__ID_Ad__2F10007B",
                        column: x => x.ID_Admin,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bloqueio",
                columns: table => new
                {
                    ID_Bloqueio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Utilizador = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bloqueio__02479986E2A213CD", x => new { x.ID_Bloqueio, x.ID_Utilizador });
                    table.ForeignKey(
                        name: "FK__Bloqueio__ID_Uti__267ABA7A",
                        column: x => x.ID_Utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_Cliente = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__E005FBFFEF97B660", x => x.ID_Cliente);
                    table.ForeignKey(
                        name: "FK__Clientes__ID_Cli__2C3393D0",
                        column: x => x.ID_Cliente,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Palavras_Chave",
                columns: table => new
                {
                    ID_Palavras_Chave = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Utilizador = table.Column<int>(type: "int", nullable: false),
                    Palavra = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Palavras__19432DABA6CD5B87", x => new { x.ID_Palavras_Chave, x.ID_Utilizador });
                    table.ForeignKey(
                        name: "FK__Palavras___ID_Ut__29572725",
                        column: x => x.ID_Utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    ID_Restaurante = table.Column<int>(type: "int", nullable: false),
                    Owner_ID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Nome_Restaurante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status_Restaurante = table.Column<bool>(type: "bit", nullable: false),
                    Tipo_Servico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Dia_De_Descanso = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__E5F26F71AA70A2FC", x => x.ID_Restaurante);
                    table.ForeignKey(
                        name: "FK__Restauran__ID_Re__31EC6D26",
                        column: x => x.ID_Restaurante,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guardar_Cliente_Prato_Favorito",
                columns: table => new
                {
                    ID_Cliente_Prato_Favorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Cliente = table.Column<int>(type: "int", nullable: false),
                    ID_Prato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guardar___80B846306A355AF2", x => new { x.ID_Cliente_Prato_Favorito, x.ID_Cliente, x.ID_Prato });
                    table.ForeignKey(
                        name: "FK__Guardar_C__ID_Cl__398D8EEE",
                        column: x => x.ID_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Guardar_C__ID_Pr__3A81B327",
                        column: x => x.ID_Prato,
                        principalTable: "Prato",
                        principalColumn: "ID_Prato",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendar_Prato",
                columns: table => new
                {
                    ID_Agendamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Marcacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Data_Do_Agendamento = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ID_Restaurante = table.Column<int>(type: "int", nullable: false),
                    ID_Prato = table.Column<int>(type: "int", nullable: false),
                    Descricao_Extra = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Foto_Extra = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Destaque = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agendar___28954093FF2705E9", x => new { x.ID_Agendamento, x.Data_Marcacao, x.Data_Do_Agendamento, x.ID_Restaurante, x.ID_Prato });
                    table.ForeignKey(
                        name: "FK__Agendar_P__ID_Pr__44FF419A",
                        column: x => x.ID_Prato,
                        principalTable: "Prato",
                        principalColumn: "ID_Prato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Agendar_P__ID_Re__440B1D61",
                        column: x => x.ID_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "ID_Restaurante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guardar_Cliente_Restaurante_Favorito",
                columns: table => new
                {
                    ID_Cliente_Restaurante_Favorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Cliente = table.Column<int>(type: "int", nullable: false),
                    ID_Restaurante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guardar___137DC26A0DA3AF18", x => new { x.ID_Cliente_Restaurante_Favorito, x.ID_Cliente, x.ID_Restaurante });
                    table.ForeignKey(
                        name: "FK__Guardar_C__ID_Cl__3D5E1FD2",
                        column: x => x.ID_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Guardar_C__ID_Re__3E52440B",
                        column: x => x.ID_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "ID_Restaurante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    ID_Horario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Restaurante = table.Column<int>(type: "int", nullable: false),
                    Dia_Semana = table.Column<int>(type: "int", nullable: false),
                    Hora_De_Entrada = table.Column<TimeSpan>(type: "time", nullable: false),
                    Hora_De_Saida = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Horario__79FF2F4AF51280AD", x => new { x.ID_Horario, x.ID_Restaurante });
                    table.ForeignKey(
                        name: "FK__Horario__ID_Rest__34C8D9D1",
                        column: x => x.ID_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "ID_Restaurante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendar_Prato_ID_Prato",
                table: "Agendar_Prato",
                column: "ID_Prato");

            migrationBuilder.CreateIndex(
                name: "IX_Agendar_Prato_ID_Restaurante",
                table: "Agendar_Prato",
                column: "ID_Restaurante");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqueio_ID_Utilizador",
                table: "Bloqueio",
                column: "ID_Utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Guardar_Cliente_Prato_Favorito_ID_Cliente",
                table: "Guardar_Cliente_Prato_Favorito",
                column: "ID_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Guardar_Cliente_Prato_Favorito_ID_Prato",
                table: "Guardar_Cliente_Prato_Favorito",
                column: "ID_Prato");

            migrationBuilder.CreateIndex(
                name: "IX_Guardar_Cliente_Restaurante_Favorito_ID_Cliente",
                table: "Guardar_Cliente_Restaurante_Favorito",
                column: "ID_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Guardar_Cliente_Restaurante_Favorito_ID_Restaurante",
                table: "Guardar_Cliente_Restaurante_Favorito",
                column: "ID_Restaurante");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_ID_Restaurante",
                table: "Horario",
                column: "ID_Restaurante");

            migrationBuilder.CreateIndex(
                name: "IX_Palavras_Chave_ID_Utilizador",
                table: "Palavras_Chave",
                column: "ID_Utilizador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Agendar_Prato");

            migrationBuilder.DropTable(
                name: "Bloqueio");

            migrationBuilder.DropTable(
                name: "Guardar_Cliente_Prato_Favorito");

            migrationBuilder.DropTable(
                name: "Guardar_Cliente_Restaurante_Favorito");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Palavras_Chave");

            migrationBuilder.DropTable(
                name: "Prato");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
