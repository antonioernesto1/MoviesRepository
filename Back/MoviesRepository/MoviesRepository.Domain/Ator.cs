using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Domain
{
    public class Ator
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<AtorFilme> AtoresFilmes { get; set; }
        public List<AtorSerie> AtoresSeries { get; set; }
        public List<Filme>? Filmes { get; set; }
        public List<Serie>? Series { get; set; }
    }
}
