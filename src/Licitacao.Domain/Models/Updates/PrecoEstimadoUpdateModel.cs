namespace Licitacao.Domain.Models.Updates
{
    public class PrecoEstimadoUpdateModel
    {
        public Guid Id { get; set; }
        public string MetodologiaCalculo { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
