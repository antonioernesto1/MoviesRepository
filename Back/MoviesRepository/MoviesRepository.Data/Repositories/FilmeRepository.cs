using Microsoft.EntityFrameworkCore;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;
        public FilmeRepository(AppDbContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Filme> GetFilmeById(int id, bool includeAtores)
        {
            var query = _context.Filmes.AsQueryable();
            if (includeAtores == true)
                query = query.Include(x => x.Atores);
            query = query.Include(x => x.Categorias).Include(x => x.CategoriasFilmes);
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Filme>> GetFilmes(bool includeAtores)
        {
            var query = _context.Filmes.AsQueryable();
            if (includeAtores == true)
                query = query.Include(x => x.Atores);
            query = query.Include(x => x.Categorias);
            return await query.ToListAsync();
        }

        public async Task<List<Filme>> GetLancamentos()
        {
            var query = _context.Filmes.AsQueryable();
            return await query.Where(x => x.isLancamento == true).OrderByDescending(x => x.AnoLancamento).Take(6).ToListAsync();
        }
        public async Task<List<Filme>> GetPopulares()
        {
            var query = _context.Filmes.AsQueryable();
            return await query.Where(x => x.isPopular == true).OrderByDescending(x => x.AnoLancamento).Take(6).ToListAsync();
        }

        public async Task<List<Filme>> GetFilmesByNome(string nome)
        {
            var query = _context.Filmes.AsQueryable();
            return await query.Where(x => x.Nome.Contains(nome)).OrderByDescending(x => x.isPopular).ToListAsync();
        }
    }
}
