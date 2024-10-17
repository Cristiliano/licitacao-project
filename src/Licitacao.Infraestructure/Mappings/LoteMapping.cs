using Licitacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Licitacao.Infraestructure.Mappings
{
    public class LoteMapping : IEntityTypeConfiguration<LoteEntity>
    {
        public void Configure(EntityTypeBuilder<LoteEntity> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Item)
                .IsRequired();

            builder.Property(l => l.Descricao)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(l => l.UnidadeMedida)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.NeFisco)    
               .HasMaxLength(30)
               .IsRequired();

            // Relacionamento 1:N (Lote -> Cotacoes)
            builder.HasMany(l => l.Cotacoes)
                .WithOne(c => c.Lote)
                .HasForeignKey(c => c.LoteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento 1:N (Lote -> Internets)
            builder.HasMany(l => l.Internets)
                .WithOne(i => i.Lote)
                .HasForeignKey(i => i.LoteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento 1:N (Lote -> PrecosEstimados)
            builder.HasMany(l => l.PrecosEstimados)
                .WithOne(p => p.Lote)
                .HasForeignKey(p => p.LoteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento 1:N (Lote -> PrecosPublicos)
            builder.HasMany(l => l.PrecosPublicos)
                .WithOne(p => p.Lote)
                .HasForeignKey(p => p.LoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
