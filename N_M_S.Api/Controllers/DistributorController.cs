using Application.DistributorManagement.Commands.Create;
using Application.DistributorManagement.Commands.Delete;
using Application.DistributorManagement.Commands.Update;
using Application.DistributorManagement.Queries.GetDistributor;
using Application.DistributorManagement.Queries.GetDistributors;
using Microsoft.AspNetCore.Mvc;

namespace N_M_S.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetDistributorsQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetDistributorsQueryResponse>> GetAllAsync()
        {
            var request = new GetDistributorsQueryRequest();

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetDistributorQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDistributorQueryResponse>> GetAsync(Guid id)
        {
            var request = new GetDistributorQueryRequest { Id = id };

            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateAsync([FromForm] CreateDistributorCommand command)
        {
            _ = await Mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateDistributorCommand command)
        {
            command.SetId(id);
            _ = await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteDistributorCommand(id);
            await Mediator.Send(command);

            return Ok();
        }
    }
}
