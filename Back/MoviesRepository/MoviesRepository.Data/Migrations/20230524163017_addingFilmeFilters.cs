using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRepository.Data.Migrations
{
    public partial class addingFilmeFilters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLancamento",
                table: "Filmes",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPopular",
                table: "Filmes",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLancamento",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "isPopular",
                table: "Filmes");
        }
    }
}
