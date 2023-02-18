using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Domain
{
    public class Serie
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
        public string? TrailerUrl { get; set; }
        public string? TrailerEmbedUrl { get; set; }
        public string? CapaUrl { get; set; }
        public string? PosterUrl { get; set; }
        public List<Ator>? Atores { get; set; }
        public List<Temporada>? Temporadas { get; set; }
        public List<Categoria>? Categorias { get; set; }
        public List<AtorSerie> AtoresSeries { get; set; }
        public List<CategoriaSerie> CategoriasSeries { get; set; }
    }
}
