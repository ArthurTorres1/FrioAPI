using FrioAPI.Communication.Responses;
using FrioAPI.Exception;
using FrioAPI.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FrioAPI.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is FrioApiException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context); 
            }
        }

        private void HandleProjectException(ExceptionContext context) 
        {
            var frioException = (FrioApiException)context.Exception;
            var errorResponse = new ResponseErrorJson(frioException.GetErrors());

            context.HttpContext.Response.StatusCode = frioException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }
        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.ERRO_DESCONHECIDO);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(errorResponse);
        }
    }
}
