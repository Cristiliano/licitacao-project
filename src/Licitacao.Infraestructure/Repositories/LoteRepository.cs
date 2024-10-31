using Licitacao.Domain.Entities;
using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Licitacao.Infraestructure.Repositories
{
    public class LoteRepository(LicitacaoContext context) : Repository<LoteEntity>(context), ILoteRepository
    {
        public async Task<List<LoteEntity>> GetAllLotesAsync()
        {
            return await context.Lotes
                .Include(x => x.Internets)
                .Include(x => x.Cotacoes)
                .Include(x => x.PrecosPublicos)
                .Include(x => x.PrecosEstimados)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> DeleteLoteAsync(Guid loteId)
        {
            return await context.Lotes
                .Where(l => l.Id == loteId)
                    .Include(x => x.Internets)
                    .Include(x => x.Cotacoes)
                    .Include(x => x.PrecosPublicos)
                    .Include(x => x.PrecosEstimados)
                .AsNoTracking()
                .ExecuteDeleteAsync() > 0;
        }
    }
}
