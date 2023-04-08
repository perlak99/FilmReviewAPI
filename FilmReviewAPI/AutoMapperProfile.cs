using AutoMapper;
using FilmReviewAPI.DTOs;
using FilmReviewAPI.Models;

namespace FilmReviewAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FilmDto, Film>();
        }
    }
}
