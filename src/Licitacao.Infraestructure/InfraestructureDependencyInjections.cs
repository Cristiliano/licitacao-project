using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;
using Licitacao.Infraestructure.Repositories;
using Licitacao.Infraestructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;

namespace Licitacao.Infraestructure
{
    public static class InfraestructureDependencyInjections
    {
        public static void AddInfraestructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddRepositories();
            serviceCollection.AddContext();
            serviceCollection.AddUnitOfWork();
        }

        private static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILoteRepository, LoteRepository>();
            serviceCollection.AddScoped<ICotacaoRepository, CotacaoRepository>();
            serviceCollection.AddScoped<IInternetRepository, InternetRepository>();
            serviceCollection.AddScoped<IPrecoEstimadoRepository, PrecoEstimadoRepository>();
            serviceCollection.AddScoped<IPrecoPublicoRepository, PrecoPublicoRepository>();
        }

        private static void AddContext(this IServiceCollection serviceCollection)
        {
            var configuration = serviceCollection
                .BuildServiceProvider()
                .GetRequiredService<IConfiguration>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            serviceCollection.AddDbContext<LicitacaoContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options =>
                {
                    options.CommandTimeout(30);
                });
            });

            serviceCollection.AddScoped<IDbConnection>(p => new MySqlConnection(connectionString));
        }

        private static void AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
