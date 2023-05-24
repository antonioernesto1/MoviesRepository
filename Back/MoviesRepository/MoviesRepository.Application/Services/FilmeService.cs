using AutoMapper;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly AppDbContext _teste;
        private readonly IRepository _context;
        private readonly IFilmeRepository _filmeRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public FilmeService(IRepository context, IFilmeRepository filmeRepository, IMapper mapper, ICategoriaRepository categoriaRepository, AppDbContext teste)
        {
            _context = context;
            _filmeRepository = filmeRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _teste = teste;
        }

        public async Task<bool> AddFilme(FilmeInputModel model)
        {
            try
            {
                if (model == null)
                    return false;

                var filme = _mapper.Map<Filme>(model);
                filme.Categorias = new List<Categoria>();
                var categorias = await MapCategorias(model.CategoriasId);
                foreach(var categoria in categorias){
                    filme.Categorias.Add(categoria);
                }

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

        public async Task<List<Filme>> GetLancamentos()
        {
            try
            {
                var filmes = await _filmeRepository.GetLancamentos();
                if(!filmes.Any())
                    return null;
                return filmes;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public async Task<List<Filme>> GetPopulares()
        {
            try
            {
                var filmes = await _filmeRepository.GetPopulares();
                if(!filmes.Any())
                    return null;
                return filmes;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<bool> UpdateFilme(int id, FilmeInputModel model)
        {
            try
            {
                var filmeAntigo = await _filmeRepository.GetFilmeById(id, false);
                if (filmeAntigo == null)
                    return false;
                
                var relacoesAtualizadasIds = model.CategoriasId;
                _mapper.Map(model, filmeAntigo);
                filmeAntigo.Id = id;
                await modificarRelacoes(filmeAntigo, relacoesAtualizadasIds);
                
                // filme.Categorias = null;
                // filme.Id = id;
                // _context.Update(filme);

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

        private async Task modificarRelacoes(Filme filme, List<int> idCategoriasAtualizadas)
        {
            var categoriasDeletadas = filme.Categorias.Where(x => !idCategoriasAtualizadas.Contains(x.Id)).ToList();
            var idCategoriasAdicionadas = idCategoriasAtualizadas.Where(x => !filme.Categorias.Select(s => s.Id).Contains(x)).ToList();
            var categoriasAdicionas = await MapCategorias(idCategoriasAdicionadas);
            filme.Categorias.RemoveAll(x => categoriasDeletadas.Contains(x));
            filme.Categorias.AddRange(categoriasAdicionas);
        }
    }
}
