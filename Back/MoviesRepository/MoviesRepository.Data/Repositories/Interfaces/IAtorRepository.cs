using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface IAtorRepository
    {
        Task<List<Ator>> GetAtores(bool includeFilmes, bool includeSeries);
        Task<Ator> GetAtorById(int id, bool includeFilmes, bool includeSeries);
    }
}
