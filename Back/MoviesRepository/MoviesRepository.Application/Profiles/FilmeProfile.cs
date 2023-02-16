using AutoMapper;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Data.Repositories.Interfaces;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Profiles
{
    public class FilmeProfile : Profile
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public FilmeProfile()
        {
            CreateMap<FilmeInputModel, Filme>();
                //.AfterMap(async (filmeInputModel, filme) => await MapCategorias(filmeInputModel, filme));
        }
    }
}
