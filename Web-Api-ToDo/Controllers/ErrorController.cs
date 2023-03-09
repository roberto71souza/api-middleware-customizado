using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web_Api_ToDo.Models;
using Microsoft.AspNetCore.Diagnostics;
using Web_Api_ToDo.Helper;
using System.Threading.Tasks;

namespace Web_Api_ToDo.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public async Task<ErrorResponseMiddleware> Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = context?.Error;

            var errorMiddleare = new ErrorResponseMiddleware
            {
                StackTrace = exception.StackTrace,
                ExceptionType = exception.GetType().Name,
                Mensagem = exception.Message
            };

            if (errorMiddleare.ExceptionType.Equals("DbContextException"))
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else if (errorMiddleare.ExceptionType.Equals("ValidationDomainException"))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            errorMiddleare.StatusCode = (HttpStatusCode)Response.StatusCode;

            await LogExceptionHelper.SaveLogException(errorMiddleare);

            return errorMiddleare;
        }
    }
}
