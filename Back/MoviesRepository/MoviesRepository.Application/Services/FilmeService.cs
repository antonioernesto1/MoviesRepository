using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IRepository _context;
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IRepository context, IFilmeRepository filmeRepository)
        {
            _context = context;
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> AddFilme(Filme model)
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

        public async Task<bool> UpdateFilme(int id, Filme model)
        {
            try
            {
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
