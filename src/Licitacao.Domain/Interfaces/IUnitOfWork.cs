
namespace Licitacao.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}