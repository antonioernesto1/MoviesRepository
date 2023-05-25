using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface ISerieRepository
    {
        Task<List<Serie>> GetSeries(bool includeAtores, bool includeTemporadas);
        Task<Serie> GetSerieById(int id, bool includeAtores, bool includeTemporadas);
        Task<List<Serie>> GetSeriesPopulares();
        Task<List<Serie>> GetSeriesByNome(string nome);
    }
}
