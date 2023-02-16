using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories
{
    public class CategoriaFilmeRepository : ICategoriaFilmeRepository
    {
        private readonly AppDbContext _context;

        public CategoriaFilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaFilme> GetCategoriaFilmeByCategoria(int categoriaId)
        {
            return _context.CategoriaFilme.Where(x => x.CategoriaId == categoriaId);
        }

        public IEnumerable<CategoriaFilme> GetCategoriaFilmeByFilme(int filmeId)
        {
            return _context.CategoriaFilme.Where(x => x.FilmeId == filmeId);
        }

        public CategoriaFilme GetCategoriaFilmeById(int filmeId, int categoriaId)
        {
            return _context.CategoriaFilme.FirstOrDefault(x => x.CategoriaId == categoriaId && x.FilmeId == filmeId);
        }
    }
}
