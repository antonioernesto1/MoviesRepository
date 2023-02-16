using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories
{
    public class CategoriaSerieRepository : ICategoriaSerieRepository
    {
        private readonly AppDbContext _context;
        public CategoriaSerieRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<CategoriaSerie> GetCategoriaSerieByCategoria(int categoriaId)
        {
            return _context.CategoriaSerie.Where(x => x.CategoriaId == categoriaId);
        }

        public CategoriaSerie GetCategoriaSerieById(int serieId, int categoriaId)
        {
            return _context.CategoriaSerie.FirstOrDefault(x => x.CategoriaId == categoriaId && x.SerieId == serieId);
        }

        public IEnumerable<CategoriaSerie> GetCategoriaSerieBySerie(int serieId)
        {
            return _context.CategoriaSerie.Where(x => x.SerieId == serieId);
        }
    }
}
