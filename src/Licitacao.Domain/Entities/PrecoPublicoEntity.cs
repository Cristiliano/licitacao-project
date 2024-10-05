namespace Licitacao.Domain.Entities
{
    public class PrecoPublicoEntity : BaseEntity
    {
        public PrecoPublicoEntity()
        {
        }

        public string Fonte { get; set; }
        public int TipoDocumento { get; set; }
        public string Fornecedor { get; set; }

        // Foreign Key
        public Guid LoteId { get; set; }
        public LoteEntity? Lote { get; set; }
    }
}
