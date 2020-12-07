using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalho_Laboratorio.Migrations
{
    public partial class AddedHeroModelç : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    ID_Hero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<int>(maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(maxLength: 400, nullable: false),
                    HeroPhoto = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.ID_Hero);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");
        }
    }
}
