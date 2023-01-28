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
        public Filme Filmes { get; set; }
        public Serie Series { get; set; }
        public Ator Atores { get; set; }
        public Episodio Episodios { get; set; }
        public Temporada Temporadas { get; set; }
        public Categoria Categorias { get; set; }

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
