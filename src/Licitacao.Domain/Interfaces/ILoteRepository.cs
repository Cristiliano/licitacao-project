using Licitacao.Domain.Entities;

namespace Licitacao.Domain.Interfaces
{
    public interface ILoteRepository : IRepository<LoteEntity>
    {
        Task<List<LoteEntity>> GetAllLotesAsync();
    }
}
