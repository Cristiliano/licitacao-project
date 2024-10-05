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
        [SwaggerOperation("busca o lote no banco")]
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
        [SwaggerOperation("cria o lote no banco")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] LoteCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.CreateAsync(model);

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
