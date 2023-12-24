using Application.SaleManagement.Commands.CreateSale;
using Application.SaleManagement.Queries.GetSales;
using Microsoft.AspNetCore.Mvc;

namespace N_M_S.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetSalesQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetSalesQueryResponse>> GetAllAsync(Guid? distributorId, DateTime? saleDate, string? productCode)
        {
            var request = new GetSalesQueryRequest { DistributorId = distributorId, SaleDate = saleDate, ProductCode = productCode };

            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateSaleCommand command)
        {
            _ = await Mediator.Send(command);

            return StatusCode(201);
        }
    }
}
