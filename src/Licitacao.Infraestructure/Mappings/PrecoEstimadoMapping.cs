using Licitacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Licitacao.Infraestructure.Mappings
{
    public class PrecoEstimadoMapping : IEntityTypeConfiguration<PrecoEstimadoEntity>
    {
        public void Configure(EntityTypeBuilder<PrecoEstimadoEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.MetodologiaCalculo)
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(p => p.ValorUnitario)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasPrecision(18, 2)
                .IsRequired();

            // Relacionamento N:1 (PrecoEstimado -> Lote)
            builder.HasOne(p => p.Lote)
                .WithMany(l => l.PrecosEstimados)
                .HasForeignKey(p => p.LoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
