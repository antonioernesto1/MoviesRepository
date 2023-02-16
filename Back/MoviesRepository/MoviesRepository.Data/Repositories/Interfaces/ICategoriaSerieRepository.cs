using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface ICategoriaSerieRepository
    {
        public IEnumerable<CategoriaSerie> GetCategoriaSerieByCategoria(int categoriaId);
        public IEnumerable<CategoriaSerie> GetCategoriaSerieBySerie(int serieId);
        public CategoriaSerie GetCategoriaSerieById(int serieId, int categoriaId);
    }
}
