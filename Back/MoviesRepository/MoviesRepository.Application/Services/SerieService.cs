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
                serie.Categorias = null;
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

        public async Task<bool> UpdateSerie(int id, SerieInputModel model)
        {
            try
            {
                var serieAntiga = await _serieRepository.GetSerieById(id, false, false);
                if (serieAntiga == null)
                    return false;

                var serie = _mapper.Map<Serie>(model);
                serie.Categorias = await MapCategorias(model.CategoriasId);
                //var ids = filme.Categorias.Select(x => x.Id).ToList();
                var relacoesAtualizadasIds = model.CategoriasId;
                var relacoesRemovidas = RelacoesRemovidas(id, relacoesAtualizadasIds, serieAntiga.CategoriasSeries);
                var relacoesAdicionadas = RelacoesAdicionadas(id, relacoesAtualizadasIds, serieAntiga.CategoriasSeries.Select(x => x.CategoriaId).ToList());
                foreach (var relacaoRemovida in relacoesRemovidas)
                {
                    _context.Delete(relacaoRemovida);
                }
                foreach (var relacaoAdicionada in relacoesAdicionadas)
                {
                    _context.Add(relacaoAdicionada);
                }
                serie.Id = id;
                _context.Update(serie);

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
                var categoria = await _categoriaRepository.GetCategoriaById(categoriaId, false, false, false);
                if (categoria != null)
                    categorias.Add(categoria);
            }
            return categorias;
        }

        private List<CategoriaSerie> RelacoesAdicionadas(int serieId, List<int> relacoesAtualizadas, List<int> relacoesExistentes)
        {
            //var relacoes = _categoriasFilmeRepository.GetCategoriaFilmeByFilme(id).Select(r => r.CategoriaId).ToList();
            var relacoesParaAdicionar = relacoesAtualizadas.Except(relacoesExistentes);
            if (relacoesParaAdicionar.Count() == 0)
                return null;
            List<CategoriaSerie> relacoesAdicionadas = new List<CategoriaSerie>();
            foreach (var relacaoParaAdicionar in relacoesParaAdicionar)
            {
                relacoesAdicionadas.Add(new CategoriaSerie { CategoriaId = relacaoParaAdicionar, SerieId = serieId });
            }
            return relacoesAdicionadas;

        }

        private List<CategoriaSerie> RelacoesRemovidas(int id, List<int> relacoesAtualizadas, List<CategoriaSerie> relacoesExistentes)
        {
            //var relacoes = _categoriasFilmeRepository.GetCategoriaFilmeByFilme(id).ToList();
            var relacoesRemovidas = relacoesExistentes.Where(r => !relacoesAtualizadas.Contains(r.CategoriaId)).ToList();
            return relacoesRemovidas;
        }
    }
}
