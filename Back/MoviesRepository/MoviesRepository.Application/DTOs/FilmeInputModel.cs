using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.DTOs
{
    public class FilmeInputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
        public string Duracao { get; set; }
        public string? TrailerUrl { get; set; }
        public string? TrailerEmbedUrl { get; set; }
        public string? CapaUrl { get; set; }
        public string? PosterUrl { get; set; }
        //public List<int>? Atores { get; set; }
        public List<int>? CategoriasId { get; set; }
    }
}
