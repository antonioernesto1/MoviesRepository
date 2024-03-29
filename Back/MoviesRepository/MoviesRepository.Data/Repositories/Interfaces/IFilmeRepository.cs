﻿using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> GetFilmes(bool includeAtores);
        Task<Filme> GetFilmeById(int id, bool includeAtores);
        Task<List<Filme>> GetLancamentos();
        Task<List<Filme>> GetPopulares();
        Task<List<Filme>> GetFilmesByNome(string nome);
    }
}
