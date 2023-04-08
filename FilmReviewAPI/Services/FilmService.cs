using AutoMapper;
using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs;
using FilmReviewAPI.Interfaces;
using FilmReviewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly FilmReviewDbContext _dbContext;

        public FilmService(IMapper mapper, FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddFilmAsync(FilmDto request)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == request.GenreId);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _dbContext.Directors.FirstOrDefaultAsync(x => x.Id == request.DirectorId);
                if (director == null)
                {
                    throw new Exception("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);
            await _dbContext.AddAsync(film);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Film> DeleteFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Film>> GetAllFilms()
        {
            throw new NotImplementedException();
        }

        public Task<Film> GetFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Film> UpdateFilmAsync(FilmDto request)
        {
            throw new NotImplementedException();
        }
    }
}
