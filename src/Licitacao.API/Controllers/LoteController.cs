using Licitacao.Application.Interfaces;
using Licitacao.Domain.Models;
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
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
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
        public IActionResult Create([FromBody] List<LoteCreateModel> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = service.Create(models);

            return Ok(result);
        }

        [HttpDelete("{guid:guid}")]
        [SwaggerOperation("deleta o lote no banco")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid)
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
