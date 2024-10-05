using Licitacao.Domain.Entities;
using Licitacao.Domain.Models;

namespace Licitacao.Domain.Mappers
{
    public static class LoteMapper
    {
        public static LoteEntity LoteCreateMapper(LoteCreateModel model)
        {
            return new ()
            {
                Item = model.Item,
                Quantidade = model.Quantidade,
                Descricao = model.Descricao,
                UnidadeMedida = model.UnidadeMedida,

                Cotacoes = model.Cotacoes?.Select(c => new CotacaoEntity
                {
                    Fonte = c.Fonte,
                    Fornecedor = c.Fornecedor,
                }).ToList() ?? [],

                Internets = model.Internets?.Select(i => new InternetEntity
                {
                    Fonte = i.Fonte,
                    NomeTabela = i.NomeTabela,
                }).ToList() ?? [],

                PrecosEstimados = model.PrecosEstimados?.Select(p => new PrecoEstimadoEntity
                {
                    MetodologiaCalculo = p.MetodologiaCalculo,
                    ValorUnitario = p.ValorUnitario,
                    ValorTotal = p.ValorTotal,
                }).ToList() ?? [],

                PrecosPublicos = model.PrecosPublicos?.Select(p => new PrecoPublicoEntity
                {
                    Fonte = p.Fonte,
                    TipoDocumento = p.TipoDocumento,
                    Fornecedor = p.Fornecedor,
                }).ToList() ?? []
            };
        }

        public static LoteEntity LoteCreateToLoteEntityMapper(LoteCreateModel model)
        {
            return new()
            {
                Item = model.Item,
                Descricao = model.Descricao,
                Quantidade = model.Quantidade,
                UnidadeMedida = model.UnidadeMedida,
            };
        }
    }
}
