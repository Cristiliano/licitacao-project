
namespace Licitacao.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task AddListAsync(List<T> entities);
        Task<bool> DeleteAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        List<T> UpdateList(List<T> entities);
        T Update(T entity);
    }
}