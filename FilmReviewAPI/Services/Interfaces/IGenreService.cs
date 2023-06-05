using FilmReviewAPI.Models;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<List<Genre>> GetGenres();
    }
}
