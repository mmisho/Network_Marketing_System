using Application.ProductManagement.Commands.Create;
using Application.ProductManagement.Commands.Delete.DeleteById;
using Application.ProductManagement.Commands.Update;
using Application.ProductManagement.Queries.GetProduct.GetProductByCode;
using Application.ProductManagement.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace N_M_S.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetProductsQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetProductsQueryResponse>> GetAllAsync()
        {
            var request = new GetProductsQueryRequest();

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{code}")]
        [ProducesResponseType(typeof(GetProductByCodeQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetProductByCodeQueryResponse>> GetAsync(string code)
        {
            var request = new GetProductByCodeQueryRequest { Code = code };

            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateProductCommand command)
        {
            _ = await Mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
        {
            command.SetId(id);
            _ = await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteProductByIdCommand(id);
            await Mediator.Send(command);

            return Ok();
        }
    }
}
