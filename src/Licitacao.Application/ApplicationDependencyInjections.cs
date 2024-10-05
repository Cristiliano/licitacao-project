using Licitacao.Application.Interfaces;
using Licitacao.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Licitacao.Application
{
    public static class ApplicationDependencyInjections
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddServices();
        }

        private static void AddServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<ILoteService, LoteService>();
        }
    }
}
