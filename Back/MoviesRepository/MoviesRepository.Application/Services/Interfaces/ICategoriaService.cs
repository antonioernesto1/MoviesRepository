﻿using MoviesRepository.Application.DTOs;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<bool> AddCategoria(CategoriaInputModel model);
        Task<bool> UpdateCategoria(int id, Categoria model);
        Task<bool> DeleteCategoria(Categoria model);
        Task<Categoria> GetCategoriaById(int id, bool includeFilmes, bool includeSeries);
        Task<List<Categoria>> GetCategorias(bool includeFilmes, bool includeSeries);

    }
}
