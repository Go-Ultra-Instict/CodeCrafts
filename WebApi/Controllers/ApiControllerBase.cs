using CodeCrafts.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafts.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[TypeFilter(typeof(ApiExceptionFilterAttribute))]
    [ApiExceptionFilterAttribute]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
