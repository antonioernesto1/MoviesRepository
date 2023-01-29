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
    public class AtorRepository : IAtorRepository
    {
        private readonly AppDbContext _context;
        public AtorRepository(AppDbContext context)
        {
            _context = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Ator> GetAtorById(int id, bool includeFilmes, bool includeSeries)
        {
            var query = _context.Atores.AsQueryable();
            if (includeFilmes == true)
                query = query.Include(x => x.Filmes);
            if (includeSeries == true)
                query = query.Include(x => x.Series);
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Ator>> GetAtores(bool includeFilmes, bool includeSeries)
        {
            var query = _context.Atores.AsQueryable();
            if (includeFilmes == true)
                query = query.Include(x => x.Filmes);
            if (includeSeries == true)
                query = query.Include(x => x.Series);
            return await query.ToListAsync();
        }
    }
}
