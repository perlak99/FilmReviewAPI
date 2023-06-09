﻿using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {

        public RatingRepository(FilmReviewDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckIfRatingByUserAndFilmExistsAsync(int filmId, int userId)
        {
            return await _dbContext.Ratings.AnyAsync(x => x.FilmId == filmId && x.UserId == userId);
        }
    }
}
