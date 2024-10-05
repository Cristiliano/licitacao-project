namespace Licitacao.Domain.Entities
{
    public class PrecoEstimadoEntity : BaseEntity
    {
        public PrecoEstimadoEntity()
        {
        }

        public string MetodologiaCalculo { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        // Foreign Key
        public Guid LoteId { get; set; }
        public LoteEntity? Lote { get; set; }
    }
}
