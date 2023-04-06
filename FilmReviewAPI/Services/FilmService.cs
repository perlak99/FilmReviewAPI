using FilmReviewAPI.DTOs;
using FilmReviewAPI.Interfaces;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Services
{
    public class FilmService : IFilmService
    {
        public Task<Film> AddFilmAsync(FilmDto request)
        {
            throw new NotImplementedException();
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
