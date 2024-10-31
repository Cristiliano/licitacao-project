using Licitacao.Domain.Entities;
using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;

namespace Licitacao.Infraestructure.Repositories
{
    public class CotacaoRepository(LicitacaoContext context) : Repository<CotacaoEntity>(context), ICotacaoRepository
    {
    }
}
