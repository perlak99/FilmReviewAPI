using AutoMapper;
using FilmReviewAPI.DTOs;
using FilmReviewAPI.Models;

namespace FilmReviewAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddFilmDto, Film>();
            CreateMap<Film, FilmListDto>();
            CreateMap<Film, GetFilmDto>();
        }
    }
}
