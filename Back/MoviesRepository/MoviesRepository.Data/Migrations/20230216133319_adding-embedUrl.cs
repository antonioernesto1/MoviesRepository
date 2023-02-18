using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRepository.Data.Migrations
{
    public partial class addingembedUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrailerEmbedUrl",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerEmbedUrl",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerEmbedUrl",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "TrailerEmbedUrl",
                table: "Filmes");
        }
    }
}
