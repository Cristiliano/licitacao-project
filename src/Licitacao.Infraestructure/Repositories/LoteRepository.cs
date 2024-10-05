using Licitacao.Domain.Entities;
using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;

namespace Licitacao.Infraestructure.Repositories
{
    public class LoteRepository(LicitacaoContext context) : Repository<LoteEntity>(context), ILoteRepository
    {
    }
}
