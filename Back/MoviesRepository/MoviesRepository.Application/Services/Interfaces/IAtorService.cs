using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Services.Interfaces
{
    public interface IAtorService
    {
        Task<bool> AddAtor(Ator model);
        Task<bool> UpdateAtor(int id, Ator model);
        Task<bool> DeleteAtor(int id);
        Task<Ator> GetAtorById(int id, bool includeFilmes, bool includeSeries);
        Task<List<Ator>> GetAtores(bool includeFilmes, bool includeSeries);
    }
}
