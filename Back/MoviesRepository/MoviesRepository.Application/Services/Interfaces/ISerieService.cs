using MoviesRepository.Application.DTOs;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Services.Interfaces
{
    public interface ISerieService
    {
        Task<bool> AddSerie(SerieInputModel model);
        Task<bool> UpdateSerie(int id, SerieInputModel model);
        Task<bool> DeleteSerie(int id);
        Task<Serie> GetSerieById(int id, bool includeAtores, bool includeTemporadas);
        Task<List<Serie>> GetSeries(bool includeAtores, bool includeTemporadas);
    }
}
