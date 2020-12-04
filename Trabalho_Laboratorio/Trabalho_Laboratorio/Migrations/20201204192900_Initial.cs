using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalho_Laboratorio.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    ID_Prato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo_Prato = table.Column<string>(maxLength: 40, nullable: false),
                    Descricao_Default = table.Column<string>(maxLength: 300, nullable: false),
                    Foto_Default = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prato__7B3DC2D27A5A6DF4", x => x.ID_Prato);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    ID_Utilizador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    EmailConfirmado = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    _Password = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco_Morada = table.Column<string>(maxLength: 50, nullable: false),
                    Endereco_CodigoPostal = table.Column<string>(maxLength: 8, nullable: false),
                    Endereco_Localidade = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Utilizad__020698175D4E0795", x => x.ID_Utilizador);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    ID_Admin = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__69F56766F47002BB", x => x.ID_Admin);
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
                    ID_Bloqueio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Utilizador = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bloqueio__0247998668B16990", x => new { x.ID_Bloqueio, x.ID_Utilizador });
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
                    ID_Cliente = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__E005FBFF45F8C6B5", x => x.ID_Cliente);
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
                    ID_Palavras_Chave = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Utilizador = table.Column<int>(nullable: false),
                    Palavra = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Palavras__19432DAB64C5CEFA", x => new { x.ID_Palavras_Chave, x.ID_Utilizador });
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
                    ID_Restaurante = table.Column<int>(nullable: false),
                    Nome_Restaurante = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Foto = table.Column<string>(maxLength: 500, nullable: false),
                    Status_Restaurante = table.Column<bool>(nullable: false),
                    Tipo_Servico = table.Column<string>(maxLength: 40, nullable: false),
                    Dia_De_Descanso = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__E5F26F71819C7641", x => x.ID_Restaurante);
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
                    ID_Cliente_Prato_Favorito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Cliente = table.Column<int>(nullable: false),
                    ID_Prato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guardar___80B846309A59961E", x => new { x.ID_Cliente_Prato_Favorito, x.ID_Cliente, x.ID_Prato });
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
                    ID_Agendamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Marcacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Data_Do_Agendamento = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ID_Restaurante = table.Column<int>(nullable: false),
                    ID_Prato = table.Column<int>(nullable: false),
                    Descricao_Extra = table.Column<string>(maxLength: 300, nullable: false),
                    Foto_Extra = table.Column<string>(maxLength: 500, nullable: false),
                    Preco = table.Column<float>(nullable: false),
                    Destaque = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agendar___28954093A2E8B8AC", x => new { x.ID_Agendamento, x.Data_Marcacao, x.Data_Do_Agendamento, x.ID_Restaurante, x.ID_Prato });
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
                    ID_Cliente_Restaurante_Favorito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Cliente = table.Column<int>(nullable: false),
                    ID_Restaurante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guardar___137DC26AC4AA310F", x => new { x.ID_Cliente_Restaurante_Favorito, x.ID_Cliente, x.ID_Restaurante });
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
                    ID_Horario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Restaurante = table.Column<int>(nullable: false),
                    Dia_Semana = table.Column<int>(nullable: false),
                    Hora_De_Entrada = table.Column<TimeSpan>(nullable: false),
                    Hora_De_Saida = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Horario__79FF2F4A0349A45A", x => new { x.ID_Horario, x.ID_Restaurante });
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
