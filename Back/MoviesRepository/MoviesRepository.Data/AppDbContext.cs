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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>()
                .HasMany(x => x.Filmes)
                .WithMany(x => x.Categorias);

            builder.Entity<Categoria>()
                .HasMany(x => x.Series)
                .WithMany(x => x.Categorias);

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
                .WithMany(x => x.Atores);

            builder.Entity<Ator>()
                .HasMany(x => x.Series)
                .WithMany(x => x.Atores);            
        }
    }
}
