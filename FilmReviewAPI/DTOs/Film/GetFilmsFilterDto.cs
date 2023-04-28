﻿namespace FilmReviewAPI.DTOs.Film
{
    public class GetFilmsFilterDto
    {
        public int? ReleaseYearFrom { get; set; }
        public int? ReleaseYearTo { get; set; }
        public int? DirectorId { get; set; }
        public int? GenreId { get; set; }
        public decimal? MinAverageRating { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
