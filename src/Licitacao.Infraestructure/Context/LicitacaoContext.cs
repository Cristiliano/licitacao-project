using Licitacao.Domain.Entities;
using Licitacao.Infraestructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Licitacao.Infraestructure.Context
{
    public class LicitacaoContext(DbContextOptions<LicitacaoContext> options) : DbContext(options)
    {
        public virtual DbSet<LoteEntity> Lotes { get; private set; }
        public virtual DbSet<PrecoPublicoEntity> PrecosPublicos { get; private set; }
        public virtual DbSet<CotacaoEntity> Cotacoes { get; private set; }
        public virtual DbSet<InternetEntity> Internets { get; private set; }
        public virtual DbSet<PrecoEstimadoEntity> PrecosEstimados { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LicitacaoContext).Assembly);

            modelBuilder.ApplyConfiguration(new LoteMapping());
            modelBuilder.ApplyConfiguration(new PrecoPublicoMapping());
            modelBuilder.ApplyConfiguration(new CotacaoMapping());
            modelBuilder.ApplyConfiguration(new InternetMapping());
            modelBuilder.ApplyConfiguration(new PrecoEstimadoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
