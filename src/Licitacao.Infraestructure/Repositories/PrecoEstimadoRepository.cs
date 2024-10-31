using Licitacao.Domain.Entities;
using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;

namespace Licitacao.Infraestructure.Repositories
{
    public class PrecoEstimadoRepository(LicitacaoContext context) : Repository<PrecoEstimadoEntity>(context), IPrecoEstimadoRepository
    {
    }
}
