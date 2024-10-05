
namespace Licitacao.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task AddListAsync(List<T> entities);
        Task<bool> DeleteAllByIdAsync(List<Guid> ids);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        T Update(T entity);
    }
}