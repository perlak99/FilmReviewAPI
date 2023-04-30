namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task AddAsync(T entity);

        public void Update(T entity);

        public void Remove(T entity);

        public Task SaveAsync();
    }
}
