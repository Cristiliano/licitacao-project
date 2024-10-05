namespace Licitacao.Domain.Entities
{
    public class CotacaoEntity : BaseEntity
    {
        public CotacaoEntity()
        {
        }

        public string Fonte { get; set; }
        public string Fornecedor { get; set; }

        // Foreign Key
        public Guid LoteId { get; set; }
        public virtual LoteEntity? Lote { get; set; }
    }
}
