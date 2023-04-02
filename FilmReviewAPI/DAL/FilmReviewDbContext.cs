using FilmReviewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.DAL
{
    public class FilmReviewDbContext : DbContext
    {
        public FilmReviewDbContext(DbContextOptions<FilmReviewDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
    }

}
