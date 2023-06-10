using FilmReviewAPI.Models;
using FilmReviewAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.DAL
{
    public class FilmReviewDbContext : DbContext
    {
        public FilmReviewDbContext(DbContextOptions<FilmReviewDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CONFIGURATION
            modelBuilder.Entity<Film>()
                .HasMany(f => f.FavouriteUsers)
                .WithMany(u => u.FavouriteFilms)
                .UsingEntity<Dictionary<string, object>>(
                    "FavouriteFilmUser",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId")
                );

            modelBuilder.Entity<User>()
               .HasMany(u => u.AddedFilms)
               .WithOne(f => f.AddedByUser)
               .HasForeignKey(f => f.AddedByUserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
              .HasOne(c => c.ParentComment)
              .WithMany(c => c.Replies)
              .HasForeignKey(c => c.ParentCommentId)
              .OnDelete(DeleteBehavior.Restrict);

            SeedData(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // ROLES
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" }
            );

            // USERS
            PasswordHashUtils.CreatePasswordHash("admin", out var passwordHash, out var passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                }
            );

            // USERS ROLES
            modelBuilder.Entity<User>()
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>("RoleUser",
                    x => x.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    y => y.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    xy => {
                        xy.HasKey("RoleId", "UserId");
                        xy.HasData(new { UserId = 1, RoleId = 1 });
                    }
                );

            // GENRES
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Comedy"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Horror"
                }
            );

            // FILMS
            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Title = "FilmTest",
                    DirectorId = null,
                    GenreId = 1,
                    ReleaseYear = 2012,
                    AddedByUserId = 1
                }
            );
        }
    }

}
