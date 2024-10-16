namespace Licitacao.Domain.Entities
{
    public class LoteEntity : BaseEntity
    {
        public LoteEntity() { }

        public int Item { get; set; }
        public int NeFisco { get; set; }
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }
        public string UnidadeMedida { get; set; }

        // Relacionamentos 1:N
        public ICollection<CotacaoEntity>? Cotacoes { get; set; }
        public ICollection<InternetEntity>? Internets { get; set; }
        public ICollection<PrecoEstimadoEntity>? PrecosEstimados { get; set; }
        public ICollection<PrecoPublicoEntity>? PrecosPublicos { get; set; }
    }
}
