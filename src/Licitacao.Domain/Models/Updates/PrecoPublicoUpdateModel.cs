namespace Licitacao.Domain.Models.Updates
{
    public class PrecoPublicoUpdateModel
    {
        public Guid Id { get; set; }
        public string Fonte { get; set; }
        public int TipoDocumento { get; set; }
        public string Fornecedor { get; set; }
        public Guid LoteId { get; set; }
    }
}
