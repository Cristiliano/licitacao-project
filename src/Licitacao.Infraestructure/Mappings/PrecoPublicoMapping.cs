using Licitacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Licitacao.Infraestructure.Mappings
{
    public class PrecoPublicoMapping : IEntityTypeConfiguration<PrecoPublicoEntity>
    {
        public void Configure(EntityTypeBuilder<PrecoPublicoEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Fonte)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.TipoDocumento)
                .IsRequired();

            builder.Property(p => p.Fornecedor)
                .HasMaxLength(100)
                .IsRequired();

            // Relacionamento N:1 (PrecoPublico -> Lote)
            builder.HasOne(p => p.Lote)
                .WithMany(l => l.PrecosPublicos)
                .HasForeignKey(p => p.LoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
