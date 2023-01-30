using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRepository.Data.Migrations
{
    public partial class fixdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Ator_AtoresId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorFilme_Filme_FilmesId",
                table: "AtorFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorSerie_Ator_AtoresId",
                table: "AtorSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_AtorSerie_Serie_SeriesId",
                table: "AtorSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFilme_Categoria_CategoriasId",
                table: "CategoriaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFilme_Filme_FilmesId",
                table: "CategoriaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaSerie_Categoria_CategoriasId",
                table: "CategoriaSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaSerie_Serie_SeriesId",
                table: "CategoriaSerie");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodio_Temporada_TemporadaId",
                table: "Episodio");

            migrationBuilder.DropForeignKey(
                name: "FK_Temporada_Serie_SerieId",
                table: "Temporada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temporada",
                table: "Temporada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodio",
                table: "Episodio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ator",
                table: "Ator");

            migrationBuilder.RenameTable(
                name: "Temporada",
                newName: "Temporadas");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "Series");

            migrationBuilder.RenameTable(
                name: "Filme",
                newName: "Filmes");

            migrationBuilder.RenameTable(
                name: "Episodio",
                newName: "Episodios");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "Ator",
                newName: "Atores");

            migrationBuilder.RenameIndex(
                name: "IX_Temporada_SerieId",
                table: "Temporadas",
                newName: "IX_Temporadas_SerieId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodio_TemporadaId",
                table: "Episodios",
                newName: "IX_Episodios_TemporadaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temporadas",
                table: "Temporadas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodios",
                table: "Episodios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atores",
                table: "Atores",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Episodios_Temporadas_TemporadaId",
                table: "Episodios",
                column: "TemporadaId",
                principalTable: "Temporadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temporadas_Series_SerieId",
                table: "Temporadas",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Episodios_Temporadas_TemporadaId",
                table: "Episodios");

            migrationBuilder.DropForeignKey(
                name: "FK_Temporadas_Series_SerieId",
                table: "Temporadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temporadas",
                table: "Temporadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodios",
                table: "Episodios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atores",
                table: "Atores");

            migrationBuilder.RenameTable(
                name: "Temporadas",
                newName: "Temporada");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serie");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "Filme");

            migrationBuilder.RenameTable(
                name: "Episodios",
                newName: "Episodio");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.RenameTable(
                name: "Atores",
                newName: "Ator");

            migrationBuilder.RenameIndex(
                name: "IX_Temporadas_SerieId",
                table: "Temporada",
                newName: "IX_Temporada_SerieId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodios_TemporadaId",
                table: "Episodio",
                newName: "IX_Episodio_TemporadaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temporada",
                table: "Temporada",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodio",
                table: "Episodio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ator",
                table: "Ator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Ator_AtoresId",
                table: "AtorFilme",
                column: "AtoresId",
                principalTable: "Ator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorFilme_Filme_FilmesId",
                table: "AtorFilme",
                column: "FilmesId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorSerie_Ator_AtoresId",
                table: "AtorSerie",
                column: "AtoresId",
                principalTable: "Ator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtorSerie_Serie_SeriesId",
                table: "AtorSerie",
                column: "SeriesId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFilme_Categoria_CategoriasId",
                table: "CategoriaFilme",
                column: "CategoriasId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFilme_Filme_FilmesId",
                table: "CategoriaFilme",
                column: "FilmesId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaSerie_Categoria_CategoriasId",
                table: "CategoriaSerie",
                column: "CategoriasId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaSerie_Serie_SeriesId",
                table: "CategoriaSerie",
                column: "SeriesId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodio_Temporada_TemporadaId",
                table: "Episodio",
                column: "TemporadaId",
                principalTable: "Temporada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temporada_Serie_SerieId",
                table: "Temporada",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
