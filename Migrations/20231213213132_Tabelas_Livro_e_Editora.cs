using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Migrations
{
    public partial class Tabelas_Livro_e_Editora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ano",
                table: "Livro",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "EditoraServices",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "EditoraServices");
        }
    }
}
