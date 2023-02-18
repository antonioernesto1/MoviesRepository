using AutoMapper;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IRepository _context;
        private readonly IFilmeRepository _filmeRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaFilmeRepository _categoriasFilmeRepository;
        private readonly IMapper _mapper;

        public FilmeService(IRepository context, IFilmeRepository filmeRepository, ICategoriaFilmeRepository categoriasFilmeRepository, IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _context = context;
            _filmeRepository = filmeRepository;
            _categoriasFilmeRepository = categoriasFilmeRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddFilme(FilmeInputModel model)
        {
            try
            {
                if (model == null)
                    return false;

                var filme = _mapper.Map<Filme>(model);
                filme.Categorias = new List<Categoria>();
                filme.Categorias = await MapCategorias(model.CategoriasId, true);

                _context.UpdateRange(filme.Categorias);
                _context.Add(filme);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> DeleteFilme(Filme model)
        {
            try
            {
                _context.Delete(model);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Filme> GetFilmeById(int id, bool includeAtores)
        {
            try
            {
                var filme = await _filmeRepository.GetFilmeById(id, includeAtores);
                if (filme == null)
                    return null;
                return filme;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Filme>> GetFilmes(bool includeAtores)
        {
            try
            {
                var filmes = await _filmeRepository.GetFilmes(includeAtores);
                if (filmes.Count() == 0 || !filmes.Any())
                    return null;
                return filmes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateFilme(int id, FilmeInputModel model)
        {
            try
            {
                var filmeAntigo = await _filmeRepository.GetFilmeById(id, false);
                if (filmeAntigo == null)
                    return false;

                var filme = _mapper.Map<Filme>(model);
                var relacoesAtualizadasIds = model.CategoriasId;
                var relacoesRemovidas = RelacoesRemovidas(id, relacoesAtualizadasIds, filmeAntigo.CategoriasFilmes);
                var relacoesAdicionadas = RelacoesAdicionadas(id, relacoesAtualizadasIds, filmeAntigo.CategoriasFilmes.Select(x => x.CategoriaId).ToList());
 
                foreach(var relacaoRemovida in relacoesRemovidas)
                {
                    _context.Delete(relacaoRemovida);
                }
                foreach (var relacaoAdicionada in relacoesAdicionadas)
                {
                    _context.Add(relacaoAdicionada);
                }
                filme.Categorias = null;
                filme.Id = id;
                _context.Update(filme);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private async Task<List<Categoria>> MapCategorias(List<int> categoriasId, bool track)
        {
            var categorias = new List<Categoria>();
            foreach (var categoriaId in categoriasId)
            {
                var categoria = await _categoriaRepository.GetCategoriaById(categoriaId, false, false, track);
                if (categoria != null)
                    categorias.Add(categoria);
            }
            return categorias;
        }

        private List<CategoriaFilme> RelacoesAdicionadas(int filmeId, List<int> relacoesAtualizadas, List<int> relacoesExistentes)
        {
            //var relacoes = _categoriasFilmeRepository.GetCategoriaFilmeByFilme(id).Select(r => r.CategoriaId).ToList();
            var relacoesParaAdicionar = relacoesAtualizadas.Except(relacoesExistentes);
            /*if (relacoesParaAdicionar.Count() == 0)
                return null;*/
            List<CategoriaFilme> relacoesAdicionadas = new List<CategoriaFilme>();
            foreach (var relacaoParaAdicionar in relacoesParaAdicionar)
            {
                relacoesAdicionadas.Add(new CategoriaFilme { CategoriaId = relacaoParaAdicionar, FilmeId = filmeId });
            }
            return relacoesAdicionadas;

        }

        private List<CategoriaFilme> RelacoesRemovidas(int id, List<int> relacoesAtualizadas, List<CategoriaFilme> relacoesExistentes)
        {
            //var relacoes = _categoriasFilmeRepository.GetCategoriaFilmeByFilme(id).ToList();
            var relacoesRemovidas = relacoesExistentes.Where(r => !relacoesAtualizadas.Contains(r.CategoriaId)).ToList();
            return relacoesRemovidas;
        }
    }
}
