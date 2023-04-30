using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs.Film;

namespace FilmReviewAPI.Tests
{
    public class FilmServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly FilmService _filmService;

        public FilmServiceTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = configuration.CreateMapper();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _filmService = new FilmService(_mapper, _unitOfWorkMock.Object);
        }
        [Fact]
        public async Task AddFilmAsync_GenreNotFound_ThrowsException()
        {
            // Arrange
            var request = new AddFilmDto { GenreId = 1 };
            _unitOfWorkMock.Setup(uow => uow.GenreRepository.GetGenreByIdAsync(request.GenreId)).ReturnsAsync(() => null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => _filmService.AddFilmAsync(request));
        }

        [Fact]
        public async Task AddFilmAsync_DirectorNotFound_ThrowsException()
        {
            // Arrange
            var request = new AddFilmDto { GenreId = 1, DirectorId = 1 };
            _unitOfWorkMock.Setup(uow => uow.GenreRepository.GetGenreByIdAsync(request.GenreId)).ReturnsAsync(new Genre());
            _unitOfWorkMock.Setup(uow => uow.DirectorRepository.GetDirectorByIdAsync((int)request.DirectorId)).ReturnsAsync(() => null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => _filmService.AddFilmAsync(request));
        }

        [Fact]
        public async Task AddFilmAsync_ValidRequest_AddsFilm()
        {
            // Arrange
            var request = new AddFilmDto { GenreId = 1 };
            _unitOfWorkMock.Setup(uow => uow.GenreRepository.GetGenreByIdAsync(request.GenreId)).ReturnsAsync(new Genre());
            _unitOfWorkMock.Setup(uow => uow.FilmRepository.AddAsync(It.IsAny<Film>())).Returns(Task.CompletedTask);

            // Act
            await _filmService.AddFilmAsync(request);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.FilmRepository.AddAsync(It.IsAny<Film>()), Times.Once);
        }

        [Fact]
        public async Task DeleteFilmAsync_FilmNotFound_ThrowsException()
        {
            // Arrange
            var filmId = 1;
            _unitOfWorkMock.Setup(uow => uow.FilmRepository.GetFilmByIdAsync(filmId)).ReturnsAsync(() => null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => _filmService.DeleteFilmAsync(filmId));
        }

        [Fact]
        public async Task DeleteFilmAsync_ValidRequest_DeletesFilm()
        {
            // Arrange
            var filmId = 1;
            _unitOfWorkMock.Setup(uow => uow.FilmRepository.GetFilmByIdAsync(filmId)).ReturnsAsync(new Film());
            _unitOfWorkMock.Setup(uow => uow.FilmRepository.Remove(It.IsAny<Film>()))
                .Callback((Film film) => _unitOfWorkMock.Object.FilmRepository.Remove(film));

            // Act
            await _filmService.DeleteFilmAsync(filmId);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.FilmRepository.Remove(It.IsAny<Film>()), Times.Once);
        }
    }
}