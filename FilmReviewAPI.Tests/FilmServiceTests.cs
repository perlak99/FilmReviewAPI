namespace FilmReviewAPI.Tests
{
    public class FilmServiceTests
    {
        private IMapper _mapper;
        private DbContextOptions<FilmReviewDbContext> _dbContextOptions;

        public FilmServiceTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();

            _dbContextOptions = new DbContextOptionsBuilder<FilmReviewDbContext>()
                .UseInMemoryDatabase(databaseName: "FilmReviewDb")
                .Options;
        }

        [Fact]
        public async Task AddFilmAsync_GivenValidRequest_ShouldAddFilmToDatabase()
        {
            // Arrange
            using (var dbContext = new FilmReviewDbContext(_dbContextOptions))
            {
                var filmService = new FilmService(_mapper, dbContext);

                var genre = new Genre
                {
                    Id = 1,
                    Name = "Drama"
                };

                await dbContext.Genres.AddAsync(genre);
                await dbContext.SaveChangesAsync();

                var request = new AddFilmDto
                {
                    Title = "The Godfather",
                    GenreId = 1,
                    ReleaseYear = 1972
                };

                // Act
                await filmService.AddFilmAsync(request);

                // Assert
                var films = await dbContext.Films.ToListAsync();
                Assert.Single(films);
                Assert.Equal(request.Title, films[0].Title);
                Assert.Equal(request.GenreId, films[0].GenreId);
                Assert.Equal(request.ReleaseYear, films[0].ReleaseYear);
            }
        }
    }
}