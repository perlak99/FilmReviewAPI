﻿using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IFilmRepository : IBaseRepository<Film>
    {
        public Task<List<Film>> GetFilmsAsync(FilmsFilterDto filter);
        public Task<Film> GetFilmByIdWithDetails(int id);
    }
}
