using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface ICategoriaFilmeRepository
    {
        public IEnumerable<CategoriaFilme> GetCategoriaFilmeByCategoria(int categoriaId);
        public IEnumerable<CategoriaFilme> GetCategoriaFilmeByFilme(int filmeId);
        public CategoriaFilme GetCategoriaFilmeById(int filmeId, int categoriaId);
    }
}
