namespace FilmReviewAPI.Tests
{
    public class FilmServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IFilmRepository> _filmRepositoryMock;
        private readonly Mock<IGenreRepository> _genreRepositoryMock;
        private readonly Mock<IDirectorRepository> _directorRepositoryMock;
        private readonly FilmService _filmService;

        public FilmServiceTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = configuration.CreateMapper();
            _filmRepositoryMock = new Mock<IFilmRepository>();
            _genreRepositoryMock = new Mock<IGenreRepository>();
            _directorRepositoryMock = new Mock<IDirectorRepository>();
            _filmService = new FilmService(_mapper, _filmRepositoryMock.Object, _genreRepositoryMock.Object, _directorRepositoryMock.Object);
        }

        [Fact]
        public async Task AddFilmAsync_GenreNotFound_ThrowsException()
        {
            // Arrange
            var request = new AddFilmDto { GenreId = 1 };
            _genreRepositoryMock.Setup(repo => repo.GetGenreByIdAsync(request.GenreId)).ReturnsAsync(() => null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => _filmService.AddFilmAsync(request));
        }

        [Fact]
        public async Task AddFilmAsync_DirectorNotFound_ThrowsException()
        {
            // Arrange
            var request = new AddFilmDto { GenreId = 1, DirectorId = 1 };
            _genreRepositoryMock.Setup(repo => repo.GetGenreByIdAsync(request.GenreId)).ReturnsAsync(new Genre());
            _directorRepositoryMock.Setup(repo => repo.GetDirectorByIdAsync((int)request.DirectorId)).ReturnsAsync(() => null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => _filmService.AddFilmAsync(request));
        }

        [Fact]
        public async Task AddFilmAsync_ValidRequest_AddsFilm()
        {
            // Arrange
            var request = new AddFilmDto { GenreId = 1 };
            _genreRepositoryMock.Setup(repo => repo.GetGenreByIdAsync(request.GenreId)).ReturnsAsync(new Genre());
            _filmRepositoryMock.Setup(repo => repo.AddFilmAsync(It.IsAny<Film>())).Returns(Task.CompletedTask);

            // Act
            await _filmService.AddFilmAsync(request);

            // Assert
            _filmRepositoryMock.Verify(repo => repo.AddFilmAsync(It.IsAny<Film>()), Times.Once);
        }

        [Fact]
        public async Task DeleteFilmAsync_FilmNotFound_ThrowsException()
        {
            // Arrange
            var filmId = 1;
            _filmRepositoryMock.Setup(repo => repo.GetFilmByIdAsync(filmId)).ReturnsAsync(() => null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => _filmService.DeleteFilmAsync(filmId));
        }

        [Fact]
        public async Task DeleteFilmAsync_ValidRequest_DeletesFilm()
        {
            // Arrange
            var filmId = 1;
            _filmRepositoryMock.Setup(repo => repo.GetFilmByIdAsync(filmId)).ReturnsAsync(new Film());
            _filmRepositoryMock.Setup(repo => repo.DeleteFilmAsync(It.IsAny<Film>())).Returns(Task.CompletedTask);

            // Act
            await _filmService.DeleteFilmAsync(filmId);

            // Assert
            _filmRepositoryMock.Verify(repo => repo.DeleteFilmAsync(It.IsAny<Film>()), Times.Once);
        }
    }
}