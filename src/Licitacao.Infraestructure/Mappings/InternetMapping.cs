using Licitacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Licitacao.Infraestructure.Mappings
{
    public class InternetMapping : IEntityTypeConfiguration<InternetEntity>
    {
        public void Configure(EntityTypeBuilder<InternetEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Fonte)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(i => i.NomeTabela)
                .HasMaxLength(100)
                .IsRequired();

            // Relacionamento N:1 (Internet -> Lote)
            builder.HasOne(i => i.Lote)
                .WithMany(l => l.Internets)
                .HasForeignKey(i => i.LoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
