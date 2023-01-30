using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.Application.Services
{
    public class AtorService : IAtorService
    {
        private readonly IRepository _context;
        private readonly IAtorRepository _atorRepository;

        public AtorService(IRepository context, IAtorRepository atorRepository)
        {
            _context = context;
            _atorRepository = atorRepository;
        }

        public async Task<bool> AddAtor(Ator model)
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

        public async Task<bool> DeleteAtor(int id)
        {
            try
            {
                var ator = await _atorRepository.GetAtorById(id, false, false);
                if (ator == null)
                    return false;

                _context.Delete(ator);

                if (await _context.SaveChangesAsync() == true)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Ator> GetAtorById(int id, bool includeFilmes, bool includeSeries)
        {
            try
            {
                var ator = await _atorRepository.GetAtorById(id, includeFilmes, includeSeries);
                if (ator == null)
                    return null;
                return ator;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Ator>> GetAtores(bool includeFilmes, bool includeSeries)
        {
            try
            {
                var atores = await _atorRepository.GetAtores(includeFilmes, includeSeries);
                if (atores.Count() == 0 || !atores.Any())
                    return null;
                return atores;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateAtor(int id, Ator model)
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
