using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;

namespace MoviesRepository.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository _context;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(IRepository context, ICategoriaRepository categoriaRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> AddCategoria(Categoria model)
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

        public async Task<bool> DeleteCategoria(Categoria model)
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

        public async Task<Categoria> GetCategoriaById(int id, bool includeFilmes, bool includeSeries)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoriaById(id, includeFilmes, includeSeries);
                if (categoria == null)
                    return null;
                return categoria;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Categoria>> GetCategorias(bool includeFilmes, bool includeSeries)
        {
            try
            {
                var categorias = await _categoriaRepository.GetCategorias(includeFilmes, includeSeries);
                if (categorias.Count() == 0 || !categorias.Any())
                    return null;
                return categorias;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateCategoria(int id, Categoria model)
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
