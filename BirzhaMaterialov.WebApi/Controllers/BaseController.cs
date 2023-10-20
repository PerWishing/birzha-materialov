using BirzhaMaterialov.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BirzhaMaterialov.WebApi.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    public abstract class BaseController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
