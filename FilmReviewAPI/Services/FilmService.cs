using AutoMapper;
using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs;
using FilmReviewAPI.Interfaces;
using FilmReviewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly FilmReviewDbContext _dbContext;

        public FilmService(IMapper mapper, FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddFilmAsync(AddFilmDto request)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == request.GenreId);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _dbContext.Directors.FirstOrDefaultAsync(x => x.Id == request.DirectorId);
                if (director == null)
                {
                    throw new Exception("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);
            await _dbContext.AddAsync(film);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFilmAsync(int id)
        {
            var film = await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == id);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            _dbContext.Films.Remove(film);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFilmAsync(UpdateFilmDto request)
        {
            var film = await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == request.GenreId);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _dbContext.Directors.FirstOrDefaultAsync(x => x.Id == request.DirectorId);
                if (director == null)
                {
                    throw new Exception("Director not found");
                }
            }

            film = _mapper.Map<Film>(request);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FilmListDto>> GetFilmsAsync(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;

            var films = await _dbContext.Films
                .Include(f => f.Genre)
                .Include(f => f.Director)
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<List<FilmListDto>>(films);
        }

        public async Task<GetFilmDto> GetFilmAsync(int id)
        {
            var film = await _dbContext.Films
                .Include(f => f.Genre)
                .Include(f => f.Director)
                .Include(f => f.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            return _mapper.Map<GetFilmDto>(film);
        }
    }
}
