using Licitacao.Domain.Entities;

namespace Licitacao.Domain.Interfaces
{
    public interface ILoteRepository : IRepository<LoteEntity>
    {
        Task<bool> DeleteLoteAsync(Guid loteId);
        Task<List<LoteEntity>> GetAllLotesAsync();
    }
}
