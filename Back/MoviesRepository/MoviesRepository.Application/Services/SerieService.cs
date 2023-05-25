using AutoMapper;
using MoviesRepository.Application.DTOs;
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
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IRepository _context;
        private readonly IMapper _mapper;

        public SerieService(IRepository context, ISerieRepository serieRepository, IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _context = context;
            _serieRepository = serieRepository;
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> AddSerie(SerieInputModel model)
        {
            try
            {
                if (model == null)
                    return false;

                var serie = _mapper.Map<Serie>(model);
                serie.Categorias = new List<Categoria>();
                var categorias = await MapCategorias(model.CategoriasId);
                foreach(var categoria in categorias){
                    serie.Categorias.Add(categoria);
                }

                _context.Add(serie);

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

        public async Task<List<Serie>> GetSeriesPopulares()
        {
            try
            {
               var series = await _serieRepository.GetSeriesPopulares();
                if (series.Count() == 0 || !series.Any())
                    return null;
                return series;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<List<Serie>> GetSerieByNome(string nome)
        {
            try
            {
                var series = await _serieRepository.GetSeriesByNome(nome);
                if(!series.Any())
                    return null;
                return series;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<bool> UpdateSerie(int id, SerieInputModel model)
        {
            try
            {
                var serieAntiga = await _serieRepository.GetSerieById(id, false, false);
                if (serieAntiga == null)
                    return false;
                
                var relacoesAtualizadasIds = model.CategoriasId;
                _mapper.Map(model, serieAntiga);
                serieAntiga.Id = id;
                await modificarRelacoes(serieAntiga, relacoesAtualizadasIds);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
         private async Task<List<Categoria>> MapCategorias(List<int> categoriasId)
        {
            var categorias = new List<Categoria>();
            foreach (var categoriaId in categoriasId)
            {
                var categoria = await _categoriaRepository.GetCategoriaById(categoriaId, false, false);
                if (categoria != null)
                    categorias.Add(categoria);
            }
            return categorias;
        }

        private async Task modificarRelacoes(Serie serie, List<int> idCategoriasAtualizadas)
        {
            var categoriasDeletadas = serie.Categorias.Where(x => !idCategoriasAtualizadas.Contains(x.Id)).ToList();
            var idCategoriasAdicionadas = idCategoriasAtualizadas.Where(x => !serie.Categorias.Select(s => s.Id).Contains(x)).ToList();
            var categoriasAdicionas = await MapCategorias(idCategoriasAdicionadas);
            serie.Categorias.RemoveAll(x => categoriasDeletadas.Contains(x));
            serie.Categorias.AddRange(categoriasAdicionas);
        }

    
    }
}
