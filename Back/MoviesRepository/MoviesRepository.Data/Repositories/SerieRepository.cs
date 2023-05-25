using Microsoft.EntityFrameworkCore;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;
namespace MoviesRepository.Data.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly AppDbContext _context;
        public SerieRepository(AppDbContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Serie> GetSerieById(int id, bool includeAtores, bool includeTemporadas)
        {
            var query = _context.Series.AsQueryable();
            if (includeAtores == true)
                query = query.Include(x => x.Atores);
            if (includeTemporadas == true)
                query = query.Include(x => x.Temporadas).ThenInclude(x => x.Episodios);
            query = query.Include(x => x.Categorias);
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Serie>> GetSeries(bool includeAtores, bool includeTemporadas)
        {
            var query = _context.Series.AsQueryable();
            if (includeAtores == true)
                query = query.Include(x => x.Atores);
            if (includeTemporadas == true)
                query = query.Include(x => x.Temporadas).ThenInclude(x => x.Episodios);
            query = query.Include(x => x.Categorias);
            return await query.ToListAsync();
        }

        public async Task<List<Serie>> GetSeriesPopulares()
        {
            var query = _context.Series.AsQueryable();
            query = query.Include(x => x.Categorias);
            return await query.Where(x => x.isPopular == true).OrderByDescending(x => x.AnoLancamento).Take(6).ToListAsync();
        }

        public async Task<List<Serie>> GetSeriesByNome(string nome)
        {
            var query = _context.Series.AsQueryable();
            return await query.Where(x => x.Nome.Contains(nome)).OrderByDescending(x => x.isPopular).ToListAsync();
        }
    }
}
