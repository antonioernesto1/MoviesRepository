using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRepository.Data.Migrations
{
    public partial class addingrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Atores_AtoresId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Filmes_FilmesId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorSerie_Atores_AtoresId",
                table: "AtorSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorSerie_Series_SeriesId",
                table: "AtorSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFilme_Categorias_CategoriasId",
                table: "CategoriaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFilme_Filmes_FilmesId",
                table: "CategoriaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaSerie_Categorias_CategoriasId",
                table: "CategoriaSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaSerie_Series_SeriesId",
                table: "CategoriaSerie");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "CategoriaSerie",
                newName: "SerieId");

            migrationBuilder.RenameColumn(
                name: "CategoriasId",
                table: "CategoriaSerie",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaSerie_SeriesId",
                table: "CategoriaSerie",
                newName: "IX_CategoriaSerie_SerieId");

            migrationBuilder.RenameColumn(
                name: "FilmesId",
                table: "CategoriaFilme",
                newName: "FilmeId");

            migrationBuilder.RenameColumn(
                name: "CategoriasId",
                table: "CategoriaFilme",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaFilme_FilmesId",
                table: "CategoriaFilme",
                newName: "IX_CategoriaFilme_FilmeId");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "AtorSerie",
                newName: "SerieId");

            migrationBuilder.RenameColumn(
                name: "AtoresId",
                table: "AtorSerie",
                newName: "AtorId");

            migrationBuilder.RenameIndex(
                name: "IX_AtorSerie_SeriesId",
                table: "AtorSerie",
                newName: "IX_AtorSerie_SerieId");

            migrationBuilder.RenameColumn(
                name: "FilmesId",
                table: "AtorFilme",
                newName: "FilmeId");

            migrationBuilder.RenameColumn(
                name: "AtoresId",
                table: "AtorFilme",
                newName: "AtorId");

            migrationBuilder.RenameIndex(
                name: "IX_AtorFilme_FilmesId",
                table: "AtorFilme",
                newName: "IX_AtorFilme_FilmeId");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Atores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Atores_AtorId",
                table: "AtorFilme",
                column: "AtorId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Filmes_FilmeId",
                table: "AtorFilme",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorSerie_Atores_AtorId",
                table: "AtorSerie",
                column: "AtorId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorSerie_Series_SerieId",
                table: "AtorSerie",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFilme_Categorias_CategoriaId",
                table: "CategoriaFilme",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFilme_Filmes_FilmeId",
                table: "CategoriaFilme",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaSerie_Categorias_CategoriaId",
                table: "CategoriaSerie",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaSerie_Series_SerieId",
                table: "CategoriaSerie",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Atores_AtorId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Filmes_FilmeId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorSerie_Atores_AtorId",
                table: "AtorSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorSerie_Series_SerieId",
                table: "AtorSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFilme_Categorias_CategoriaId",
                table: "CategoriaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFilme_Filmes_FilmeId",
                table: "CategoriaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaSerie_Categorias_CategoriaId",
                table: "CategoriaSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaSerie_Series_SerieId",
                table: "CategoriaSerie");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Atores");

            migrationBuilder.RenameColumn(
                name: "SerieId",
                table: "CategoriaSerie",
                newName: "SeriesId");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "CategoriaSerie",
                newName: "CategoriasId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaSerie_SerieId",
                table: "CategoriaSerie",
                newName: "IX_CategoriaSerie_SeriesId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "CategoriaFilme",
                newName: "FilmesId");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "CategoriaFilme",
                newName: "CategoriasId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaFilme_FilmeId",
                table: "CategoriaFilme",
                newName: "IX_CategoriaFilme_FilmesId");

            migrationBuilder.RenameColumn(
                name: "SerieId",
                table: "AtorSerie",
                newName: "SeriesId");

            migrationBuilder.RenameColumn(
                name: "AtorId",
                table: "AtorSerie",
                newName: "AtoresId");

            migrationBuilder.RenameIndex(
                name: "IX_AtorSerie_SerieId",
                table: "AtorSerie",
                newName: "IX_AtorSerie_SeriesId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "AtorFilme",
                newName: "FilmesId");

            migrationBuilder.RenameColumn(
                name: "AtorId",
                table: "AtorFilme",
                newName: "AtoresId");

            migrationBuilder.RenameIndex(
                name: "IX_AtorFilme_FilmeId",
                table: "AtorFilme",
                newName: "IX_AtorFilme_FilmesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Atores_AtoresId",
                table: "AtorFilme",
                column: "AtoresId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Filmes_FilmesId",
                table: "AtorFilme",
                column: "FilmesId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorSerie_Atores_AtoresId",
                table: "AtorSerie",
                column: "AtoresId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorSerie_Series_SeriesId",
                table: "AtorSerie",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFilme_Categorias_CategoriasId",
                table: "CategoriaFilme",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFilme_Filmes_FilmesId",
                table: "CategoriaFilme",
                column: "FilmesId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaSerie_Categorias_CategoriasId",
                table: "CategoriaSerie",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaSerie_Series_SeriesId",
                table: "CategoriaSerie",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
