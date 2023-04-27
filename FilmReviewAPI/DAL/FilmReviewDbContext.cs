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
            modelBuilder.Entity<User>()
                .HasMany(s => s.Roles)
                .WithMany(c => c.Users)
                .UsingEntity(j => j.ToTable("RoleUser"));

            modelBuilder.Entity<Film>()
                .Property(f => f.DirectorId)
                .IsRequired(false);

            // GENERATING DATA
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            PasswordHashUtils.CreatePasswordHash("admin", out var passwordHash, out var passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1,
                    Username = "Admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            );

            modelBuilder.Entity<User>()
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleUser",
                    x => x.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    y => y.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    xy =>
                    {
                        xy.HasKey("RoleId", "UserId");
                        xy.HasData(
                            new { UserId = 1, RoleId = 1 }
                        );
                    });

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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }

}
