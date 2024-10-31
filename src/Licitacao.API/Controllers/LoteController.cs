using Licitacao.Application.Interfaces;
using Licitacao.Domain.Entities;
using Licitacao.Domain.Models.Creates;
using Licitacao.Domain.Models.Updates;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licitacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public class LoteController(ILoteService service) : Controller
    {
        [HttpGet]
        [SwaggerOperation("busca todos os lotes")]
        [ProducesResponseType(typeof(IEnumerable<LoteEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation("cria os lotes")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] List<LoteCreateModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.CreateAsync(models);

            return Ok(result);
        }

        [HttpPut]
        [SwaggerOperation("atualiza os lotes")]
        [ProducesResponseType(typeof(IEnumerable<List<LoteUpdateModel>?>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateListAsync([FromBody] List<LoteUpdateModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.UpdateAsync(models);

            return Ok(result);
        }

        [HttpDelete("{guid:guid}")]
        [SwaggerOperation("deleta o lote no banco")]
        [ProducesResponseType(typeof(IEnumerable<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.RemoveByIdAsync(guid);

            return Ok(result);
        }
    }
}
