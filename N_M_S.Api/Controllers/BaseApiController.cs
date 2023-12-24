using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace N_M_S.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IMediator Mediator  => HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
