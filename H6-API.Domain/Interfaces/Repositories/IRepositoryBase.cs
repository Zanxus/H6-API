namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {


        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetAsync(int id);

        Task AddAsync(T entity);

        IReadOnlyList<T> GetAll();
        T? Get(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
