using Licitacao.Domain.Entities;
using Licitacao.Domain.Models;

namespace Licitacao.Application.Interfaces
{
    public interface ILoteService
    {
        Task<List<LoteEntity?>> GetAllAsync();
        List<LoteEntity>? Create(List<LoteCreateModel> models);
        Task<bool> RemoveByIdAsync(Guid loteId);
    }
}