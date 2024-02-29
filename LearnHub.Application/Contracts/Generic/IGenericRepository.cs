namespace LearnHub.Application.Contracts.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(List<int> ids);
        void Save();
        Task SaveAsync();
        Task<bool> Exists(int id);
    }
}
