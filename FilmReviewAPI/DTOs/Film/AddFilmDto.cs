﻿using FilmReviewAPI.Models;

namespace FilmReviewAPI.DTOs.Film
{
    public class AddFilmDto
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int? DirectorId { get; set; }
    }
}
