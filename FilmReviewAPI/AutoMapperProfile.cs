using AutoMapper;
using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.DTOs.Rating;
using FilmReviewAPI.Models;

namespace FilmReviewAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Film
            CreateMap<AddFilmDto, Film>();
            CreateMap<Film, GetFilmListDto>();
            CreateMap<Film, GetFilmDto>();

            //Rating
            CreateMap<AddRatingDto, Rating>();
        }
    }
}
