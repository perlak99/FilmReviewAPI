using AutoMapper;
using FilmReviewAPI.DTOs.Comment;
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
            CreateMap<Film, GetFilmListDto>()
                 .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director));
            CreateMap<Film, GetFilmDto>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            CreateMap<UpdateFilmDto, Film>();

            //Rating
            CreateMap<AddRatingDto, Rating>();

            //Comment
            CreateMap<Comment, SimpleCommentDto>();
            CreateMap<AddCommentDto, Comment>();
        }
    }
}
