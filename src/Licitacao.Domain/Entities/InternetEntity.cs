namespace Licitacao.Domain.Entities
{
    public class InternetEntity : BaseEntity
    {
        public InternetEntity()
        {
        }

        public string Fonte { get; set; }
        public string NomeTabela { get; set; }

        // Foreign Key
        public Guid LoteId { get; set; }
        public LoteEntity? Lote { get; set; }
    }
}
