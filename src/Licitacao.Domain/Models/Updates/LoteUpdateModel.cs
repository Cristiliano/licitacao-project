namespace Licitacao.Domain.Models.Updates
{
    public class LoteUpdateModel
    {
        public Guid Id { get; set; }
        public int Item { get; set; }
        public int NeFisco { get; set; }
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }
        public string UnidadeMedida { get; set; }

        public List<CotacaoUpdateModel>? Cotacoes { get; set; }
        public List<InternetUpdateModel>? Internets { get; set; }
        public List<PrecoEstimadoUpdateModel>? PrecosEstimados { get; set; }
        public List<PrecoPublicoUpdateModel>? PrecosPublicos { get; set; }
    }
}