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
            if(context.Exception is ErrorOnValidationException)
            {
                var ex = (ErrorOnValidationException)context.Exception;
                var errorResponse = new ResponseErrorJson(ex.Errors);

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else
            {
                ThrowUnknowError(context);
            }
               
        }
        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.ERRO_DESCONHECIDO);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(errorResponse);
        }
    }
}
