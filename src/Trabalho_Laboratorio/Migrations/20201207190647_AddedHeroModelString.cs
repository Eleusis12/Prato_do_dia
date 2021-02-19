using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalho_Laboratorio.Migrations
{
    public partial class AddedHeroModelString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Hero",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Titulo",
                table: "Hero",
                type: "int",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
