using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Serie>? Series { get; set; }
        public List<Filme>? Filmes { get; set; }
        public List<CategoriaFilme>? CategoriasFilmes { get; set; }
        public List<CategoriaSerie>? CategoriasSeries { get; set; }
    }
}
