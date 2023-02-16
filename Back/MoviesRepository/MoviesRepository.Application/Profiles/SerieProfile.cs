using AutoMapper;
using MoviesRepository.Application.DTOs;
using MoviesRepository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Application.Profiles
{
    public class SerieProfile : Profile
    {
        public SerieProfile()
        {
            CreateMap<SerieInputModel, Serie>();
        }
    }
}
