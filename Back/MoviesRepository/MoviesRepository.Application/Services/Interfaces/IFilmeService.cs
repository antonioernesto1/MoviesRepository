using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<bool> AddFilme(Filme model);
        Task<bool> UpdateFilme(int id, Filme model);
        Task<bool> DeleteFilme(Filme model);
        Task<Filme> GetFilmeById(int id, bool includeAtores);
        Task<List<Filme>> GetFilmes(bool includeAtores);
    }
}
