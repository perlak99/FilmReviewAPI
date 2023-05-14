using FilmReviewAPI.DAL;
using FilmReviewAPI.Repositories.Interfaces;

namespace FilmReviewAPI.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly FilmReviewDbContext _dbContext;

        public BaseRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
