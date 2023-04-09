using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShabbaToDoo.Application.Common.Errors;

namespace ShabbaToDoo.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [HttpGet("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceExceptions serviceExceptions => ((int)serviceExceptions.StatusCode, serviceExceptions.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}