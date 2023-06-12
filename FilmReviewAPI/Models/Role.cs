﻿namespace FilmReviewAPI.Models
{
    public class Role : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
