using Microsoft.EntityFrameworkCore;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Episodio> Episodios { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<AtorSerie> AtorSerie { get; set; }
        public DbSet<AtorFilme> AtorFilme { get; set; }
        public DbSet<CategoriaFilme> CategoriaFilme { get; set; }
        public DbSet<CategoriaSerie> CategoriaSerie { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AtorSerie>().HasKey(x => new { x.AtorId, x.SerieId });

            builder.Entity<AtorFilme>().HasKey(x => new { x.AtorId, x.FilmeId });

            builder.Entity<CategoriaFilme>().HasKey(x => new { x.CategoriaId, x.FilmeId });

            builder.Entity<CategoriaSerie>().HasKey(x => new { x.CategoriaId, x.SerieId });

            /*builder.Entity<AtorFilme>()
                .HasOne(x => x.Filme)
                .WithMany(x => x.AtoresFilmes)
                .HasForeignKey(x => x.FilmeId);

            builder.Entity<AtorFilme>()
                .HasOne(x => x.Ator)
                .WithMany(x => x.AtoresFilmes)
                .HasForeignKey(x => x.AtorId);

            builder.Entity<AtorSerie>()
                .HasOne(x => x.Serie)
                .WithMany(x => x.AtoresSeries)
                .HasForeignKey(x => x.SerieId);

            builder.Entity<AtorSerie>()
                .HasOne(x => x.Ator)
                .WithMany(x => x.AtoresSeries)
                .HasForeignKey(x => x.AtorId);

            builder.Entity<CategoriaFilme>()
                .HasOne(x => x.Filme)
                .WithMany(x => x.CategoriasFilmes)
                .HasForeignKey(x => x.FilmeId);

            builder.Entity<CategoriaFilme>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.CategoriasFilmes)
                .HasForeignKey(x => x.CategoriaId);

            builder.Entity<CategoriaSerie>()
                .HasOne(x => x.Serie)
                .WithMany(x => x.CategoriasSeries)
                .HasForeignKey(x => x.SerieId);

            builder.Entity<CategoriaSerie>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.CategoriasSeries)
                .HasForeignKey(x => x.CategoriaId);
            */
            builder.Entity<Categoria>()
                .HasMany(x => x.Filmes)
                .WithMany(x => x.Categorias)
                .UsingEntity<CategoriaFilme>();

            builder.Entity<Categoria>()
                .HasMany(x => x.Series)
                .WithMany(x => x.Categorias)
                .UsingEntity<CategoriaSerie>();

            builder.Entity<Temporada>()
                .HasOne(x => x.Serie)
                .WithMany(x => x.Temporadas)
                .HasForeignKey(x => x.SerieId);

            builder.Entity<Episodio>()
                .HasOne(x => x.Temporada)
                .WithMany(x => x.Episodios)
                .HasForeignKey(x => x.TemporadaId);

            builder.Entity<Ator>()
                .HasMany(x => x.Filmes)
                .WithMany(x => x.Atores)
                .UsingEntity<AtorFilme>();

            builder.Entity<Ator>()
                .HasMany(x => x.Series)
                .WithMany(x => x.Atores)
                .UsingEntity<AtorSerie>();            
        }
    }
}
