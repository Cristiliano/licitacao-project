using Licitacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Licitacao.Infraestructure.Mappings
{
    public class CotacaoMapping : IEntityTypeConfiguration<CotacaoEntity>
    {
        public void Configure(EntityTypeBuilder<CotacaoEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Fonte)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.Fornecedor)
                .HasMaxLength(100)
                .IsRequired();

            // Relacionamento N:1 (Cotacao -> Lote)
            builder.HasOne(c => c.Lote)
                .WithMany(l => l.Cotacoes)
                .HasForeignKey(c => c.LoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
