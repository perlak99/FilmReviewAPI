namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task AddAsync(T entity);

        public Task UpdateAsync(T entity);

        public Task RemoveAsync(T entity);

        public Task<T> GetByIdNonTrackedAsync(int id);

        public Task<T> GetByIdAsync(int id);
    }
}
