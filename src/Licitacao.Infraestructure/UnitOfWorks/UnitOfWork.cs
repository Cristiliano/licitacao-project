using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;

namespace Licitacao.Infraestructure.UnitOfWorks
{
    public class UnitOfWork(LicitacaoContext context) : IDisposable, IUnitOfWork
    {
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            context.Dispose();
        }
    }
}
