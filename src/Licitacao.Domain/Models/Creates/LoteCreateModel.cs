namespace Licitacao.Domain.Models.Creates
{
    public class LoteCreateModel
    {
        public int Item { get; set; }
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }
        public int NeFisco { get; set; }
        public string UnidadeMedida { get; set; }
        public List<CotacaoCreateModel> Cotacoes { get; set; }
        public List<InternetCreateModel> Internets { get; set; }
        public List<PrecoEstimadoCreateModel> PrecosEstimados { get; set; }
        public List<PrecoPublicoCreateModel> PrecosPublicos { get; set; }
    }
}
