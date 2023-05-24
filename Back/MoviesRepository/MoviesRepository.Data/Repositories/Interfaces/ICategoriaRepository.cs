using MoviesRepository.Domain;
using System;
using System.Collections.Generic;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetCategorias(bool includeFilmes, bool includeSeries);
        Task<Categoria> GetCategoriaById(int id, bool includeFilmes, bool includeSeries);
    }
}
