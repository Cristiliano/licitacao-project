using Licitacao.Domain.Entities;
using Licitacao.Domain.Models;

namespace Licitacao.Application.Interfaces
{
    public interface ILoteService
    {
        Task<List<LoteEntity?>> GetAllAsync();
        Task<LoteEntity?> CreateAsync(LoteCreateModel model);
        Task<bool> RemoveByIdAsync(Guid loteId);
    }
}