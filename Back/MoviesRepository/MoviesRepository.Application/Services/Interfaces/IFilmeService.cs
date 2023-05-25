using MoviesRepository.Application.DTOs;
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
        Task<bool> AddFilme(FilmeInputModel model);
        Task<bool> UpdateFilme(int id, FilmeInputModel model);
        Task<bool> DeleteFilme(Filme model);
        Task<Filme> GetFilmeById(int id, bool includeAtores);
        Task<List<Filme>> GetFilmes(bool includeAtores);
        Task<List<Filme>> GetLancamentos();
        Task<List<Filme>> GetPopulares();
        Task<List<Filme>> GetFilmesByNome(string nome);
    }
}
