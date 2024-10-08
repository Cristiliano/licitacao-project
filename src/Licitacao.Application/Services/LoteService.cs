using Licitacao.Application.Interfaces;
using Licitacao.Domain.Entities;
using Licitacao.Domain.Interfaces;
using Licitacao.Domain.Mappers;
using Licitacao.Domain.Models.Creates;
using Licitacao.Domain.Models.Updates;

namespace Licitacao.Application.Services
{
    public class LoteService(ILoteRepository loteRepository,
        ICotacaoRepository cotacaoRepository,
        IInternetRepository internetRepository,
        IPrecoEstimadoRepository precoEstimadoRepository,
        IPrecoPublicoRepository precoPublicoRepository, 
        IUnitOfWork unitOfWork) : ILoteService
    {
        public async Task<List<LoteEntity?>> GetAllAsync()
        {
            try
            {
                var lotes = await loteRepository.GetAllAsync();
                var loteIds = lotes.Select(l => l.Id).ToList();

                if (lotes.Count == 0) return [];

                var cotacoes = await cotacaoRepository.GetAllAsync();
                var cotacoesToLoteIdList = cotacoes.Where(c => loteIds.Contains(c.LoteId)).ToList();

                var internets = await internetRepository.GetAllAsync();
                var internetsToLoteIdList = internets.Where(c => loteIds.Contains(c.LoteId)).ToList();
                
                var precoEstimados = await precoEstimadoRepository.GetAllAsync();
                var precoEstimadosToLoteIdList = precoEstimados.Where(c => loteIds.Contains(c.LoteId)).ToList();
                
                var precopublicos = await precoPublicoRepository.GetAllAsync();
                var precoPublicosToLoteIdList = precopublicos.Where(c => loteIds.Contains(c.LoteId)).ToList();

                List<LoteEntity> lotesResponse = [];
                foreach (var item in lotes)
                {
                    var listCotacoes = cotacoesToLoteIdList.Where(c => c.LoteId == item.Id).ToList();
                    listCotacoes.ForEach(item.Cotacoes!.Add);

                    var listInternets = internetsToLoteIdList.Where(c => c.LoteId == item.Id).ToList();
                    listInternets.ForEach(item.Internets!.Add);

                    var listPrecoEstimados = precoEstimadosToLoteIdList.Where(c => c.LoteId == item.Id).ToList();
                    listPrecoEstimados.ForEach(item.PrecosEstimados!.Add);

                    var listPrecoPublicos = precoPublicosToLoteIdList.Where(c => c.LoteId == item.Id).ToList();
                    listPrecoPublicos.ForEach(item.PrecosPublicos!.Add);

                    lotesResponse.Add(item);
                }

                await unitOfWork.CommitAsync();

                return lotesResponse!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<LoteEntity>?> CreateAsync(List<LoteCreateModel> models)
        {
            try
            {
                if (models.Count == 0) return null;

                List<LoteEntity> lotes = [];

                models.ForEach(async item =>
                {
                    var lote = await AddLote(item);
                    lotes.Add(lote!);
                });

                await unitOfWork.CommitAsync();

                return lotes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<LoteUpdateModel>?> UpdateAsync(List<LoteUpdateModel> models)
        {
            try
            {
                if (models.Count == 0) return null;

                List<LoteUpdateModel> lotes = [];
                models.ForEach( item =>
                {
                    var lote = UpdateLote(item);
                    lotes.Add(lote!);
                });

                await unitOfWork.CommitAsync();

                return lotes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        public async Task<bool> RemoveByIdAsync(Guid loteId)
        {
            try
            {
                await RemoveCotacoes(loteId);
                await RemoveInternets(loteId);
                await RemovePrecosEstimados(loteId);
                await RemovePrecoPublicos(loteId);

                var result = await loteRepository.DeleteAsync(loteId);

                await unitOfWork.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private LoteUpdateModel UpdateLote(LoteUpdateModel model)
        {
            var lote = LoteMapper.LoteUpdateToLoteEntityMapper(model);
            loteRepository.Update(lote);

            var loteEntity = LoteMapper.LoteUpdateMapper(model);

            UpdateCotacoes(loteEntity);
            UpdateInternets(loteEntity);
            UpdatePrecosEstimados(loteEntity);
            UpdatePrecosPublicos(loteEntity);

            return model;
        }

        private async Task<LoteEntity?> AddLote(LoteCreateModel model)
        {
            var loteMapperCreate = LoteMapper.LoteCreateMapper(model);

            var lote = LoteMapper.LoteCreateToLoteEntityMapper(model);
            if (lote is null) return null;

            var loteEntityId = loteRepository.AddAsync(lote).Result.Id;

            await AddCotacoes(loteMapperCreate, loteEntityId);
            await AddInternets(loteMapperCreate, loteEntityId);
            await AddPrecosEstimados(loteMapperCreate, loteEntityId);
            await AddPrecosPublicos(loteMapperCreate, loteEntityId);

            return lote;
        }

        private async Task RemovePrecoPublicos(Guid loteId)
        {
            var precosPublicos = await precoPublicoRepository.GetAllAsync();
            var precosPublicosToRemovedId = precosPublicos.Where(i => i.LoteId == loteId)
                                                          .Select(i => i.Id)
                                                          .ToList();

            await precoPublicoRepository.DeleteAllByIdAsync(precosPublicosToRemovedId);
        }

        private async Task RemovePrecosEstimados(Guid loteId)
        {
            var precoEstimados = await precoEstimadoRepository.GetAllAsync();
            var precoEstimadosToRemovedId = precoEstimados.Where(i => i.LoteId == loteId)
                                                          .Select(i => i.Id)
                                                          .ToList();

            await precoEstimadoRepository.DeleteAllByIdAsync(precoEstimadosToRemovedId);
        }

        private async Task RemoveInternets(Guid loteId)
        {
            var internets = await internetRepository.GetAllAsync();
            var internetsToRemovedId = internets.Where(i => i.LoteId == loteId)
                                                .Select(i => i.Id)
                                                .ToList();

            await internetRepository.DeleteAllByIdAsync(internetsToRemovedId);
        }

        private async Task RemoveCotacoes(Guid loteId)
        {
            var cotacoes = await cotacaoRepository.GetAllAsync();
            var cotacoesToRemovedId = cotacoes.Where(c => c.LoteId == loteId)
                                              .Select(c => c.Id)
                                              .ToList();

            await cotacaoRepository.DeleteAllByIdAsync(cotacoesToRemovedId);
        }

        private async Task AddCotacoes(LoteEntity entity, Guid loteEntityId)
        {
            var cotacoes = entity.Cotacoes?
                                 .Select(c => { c.LoteId = loteEntityId; return c; })
                                 .ToList() ?? [];

            await cotacaoRepository.AddListAsync(cotacoes);
        }

        private async Task AddInternets(LoteEntity entity, Guid loteEntityId)
        {
            var internets = entity.Internets?
                                  .Select(i => { i.LoteId = loteEntityId; return i; })
                                  .ToList() ?? [];

            await internetRepository.AddListAsync(internets);
        }

        private async Task AddPrecosEstimados(LoteEntity entity, Guid loteEntityId)
        {
            var precoEstimados = entity.PrecosEstimados?
                                       .Select(p => { p.LoteId = loteEntityId; return p; })
                                       .ToList() ?? [];

            await precoEstimadoRepository.AddListAsync(precoEstimados);
        }

        private async Task AddPrecosPublicos(LoteEntity entity, Guid loteEntityId)
        {
            var precosPublicos = entity.PrecosPublicos?
                                       .Select(p => { p.LoteId = loteEntityId; return p; })
                                       .ToList() ?? [];

            await precoPublicoRepository.AddListAsync(precosPublicos);
        }

        private List<CotacaoEntity>? UpdateCotacoes(LoteEntity entity)
        {
            var cotacoes = entity.Cotacoes?.ToList();

            if (cotacoes?.Count == 0) return default;

            return cotacaoRepository.UpdateList(cotacoes!);
        }

        private List<InternetEntity>? UpdateInternets(LoteEntity entity)
        {
            var internets = entity.Internets?.ToList();

            if (internets?.Count == 0) return default;

            return internetRepository.UpdateList(internets!);
        }

        private List<PrecoEstimadoEntity>? UpdatePrecosEstimados(LoteEntity entity)
        {
            var precoEstimados = entity.PrecosEstimados?.ToList();

            if (precoEstimados?.Count == 0) return default;

            return precoEstimadoRepository.UpdateList(precoEstimados!);
        }

        private List<PrecoPublicoEntity>? UpdatePrecosPublicos(LoteEntity entity)
        {
            var precoPublicos = entity.PrecosPublicos?.ToList();

            if (precoPublicos?.Count == 0) return default;

            return precoPublicoRepository.UpdateList(precoPublicos!);
        }
    }
}
