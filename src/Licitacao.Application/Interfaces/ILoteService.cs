using Licitacao.Domain.Entities;
using Licitacao.Domain.Models.Creates;
using Licitacao.Domain.Models.Updates;

namespace Licitacao.Application.Interfaces
{
    public interface ILoteService
    {
        Task<List<LoteEntity?>> GetAllAsync();
        Task<List<LoteEntity>?> CreateAsync(List<LoteCreateModel> models);
        Task<bool> RemoveByIdAsync(Guid loteId);
        Task<List<LoteUpdateModel>?> UpdateAsync(List<LoteUpdateModel> models);
    }
}