using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        private readonly IRepository _context;

        public SerieService(IRepository context, ISerieRepository serieRepository)
        {
            _context = context;
            _serieRepository = serieRepository;
        }

        public async Task<bool> AddSerie(Serie model)
        {
            try
            {
                if (model == null)
                    return false;

                _context.Add(model);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteSerie(int id)
        {
            try
            {
                var serie = await _serieRepository.GetSerieById(id, false, false);
                if (serie == null)
                    return false;

                _context.Delete(serie);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Serie> GetSerieById(int id, bool includeAtores, bool includeTemporadas)
        {
            try
            {
                var serie = await _serieRepository.GetSerieById(id, includeAtores, includeTemporadas);
                if (serie == null)
                    return null;
                return serie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Serie>> GetSeries(bool includeAtores, bool includeTemporadas)
        {
            var series = await _serieRepository.GetSeries(includeAtores, includeTemporadas);
            if (series.Count() == 0 || !series.Any())
                return null;
            return series;
        }

        public async Task<bool> UpdateSerie(int id, Serie model)
        {
            try
            {
                var serie = await _serieRepository.GetSerieById(id, false, false);
                if (serie == null)
                    return false;

                model.Id = id;
                _context.Update(model);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
