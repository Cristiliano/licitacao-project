using Licitacao.Domain.Entities;
using Licitacao.Domain.Models.Creates;
using Licitacao.Domain.Models.Updates;

namespace Licitacao.Domain.Mappers
{
    public static class LoteMapper
    {
        public static LoteEntity LoteCreateMapper(LoteCreateModel model)
        {
            return new ()
            {
                Item = model.Item,
                NeFisco = model.NeFisco,
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
                NeFisco = model.NeFisco,
                Descricao = model.Descricao,
                Quantidade = model.Quantidade,
                UnidadeMedida = model.UnidadeMedida,
            };
        }

        public static LoteEntity LoteUpdateMapper(LoteUpdateModel model)
        {
            return new()
            {
                Id = model.Id,
                NeFisco = model.NeFisco,
                Item = model.Item,
                Quantidade = model.Quantidade,
                Descricao = model.Descricao,
                UnidadeMedida = model.UnidadeMedida,

                Cotacoes = model.Cotacoes?.Select(c => new CotacaoEntity
                {
                    Id = c.Id,
                    Fonte = c.Fonte,
                    Fornecedor = c.Fornecedor,
                    LoteId = model.Id,
                }).ToList() ?? [],

                Internets = model.Internets?.Select(i => new InternetEntity
                {
                    Id = i.Id,
                    Fonte = i.Fonte,
                    NomeTabela = i.NomeTabela,
                    LoteId = model.Id
                }).ToList() ?? [],

                PrecosEstimados = model.PrecosEstimados?.Select(p => new PrecoEstimadoEntity
                {
                    Id = p.Id,
                    MetodologiaCalculo = p.MetodologiaCalculo,
                    ValorUnitario = p.ValorUnitario,
                    ValorTotal = p.ValorTotal,
                    LoteId = model.Id
                }).ToList() ?? [],

                PrecosPublicos = model.PrecosPublicos?.Select(p => new PrecoPublicoEntity
                {
                    Id = p.Id,  
                    Fonte = p.Fonte,
                    TipoDocumento = p.TipoDocumento,
                    Fornecedor = p.Fornecedor,
                    LoteId = model.Id
                }).ToList() ?? []
            };
        }

        public static LoteEntity LoteUpdateToLoteEntityMapper(LoteUpdateModel model)
        {
            return new()
            {
                Id = model.Id,
                NeFisco = model.NeFisco,
                Item = model.Item,
                Descricao = model.Descricao,
                Quantidade = model.Quantidade,
                UnidadeMedida = model.UnidadeMedida,
            };
        }
    }
}
