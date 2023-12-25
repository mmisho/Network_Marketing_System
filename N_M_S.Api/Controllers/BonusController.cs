using Application.BonusManagement.Commands.Create;
using Application.BonusManagement.Dtos.Enums;
using Application.BonusManagement.Queries.GetBonuses;
using Microsoft.AspNetCore.Mvc;

namespace N_M_S.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetBonusQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetBonusQueryResponse>> GetAllAsync(string? firstName, string? lastName, BonusFilterEnum? BonusFilter)
        {
            var request = new GetBonusQueryRequest()
            {
                FirstName = firstName,
                LastName = lastName,
                BonusFilter = BonusFilter
            };

            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CalCulateAsync()
        {
            _ = await Mediator.Send(new CreateBonusCommand());

            return StatusCode(201);
        }
    }
}
