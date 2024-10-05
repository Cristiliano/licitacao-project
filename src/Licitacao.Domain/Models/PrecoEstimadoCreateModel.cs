namespace Licitacao.Domain.Models
{
    public class PrecoEstimadoCreateModel
    {
        public string MetodologiaCalculo { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
