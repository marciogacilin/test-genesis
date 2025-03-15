using Microsoft.AspNetCore.Diagnostics;
using TestGenesis.Server.Domain.Responses;

namespace TestGenesis.Server.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        int statusCode;
        ResultErrorResponse result;
        if (exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            statusCode = StatusCodes.Status400BadRequest;

            result = new(statusCode, errors);
        }
        else
        {
            statusCode = StatusCodes.Status500InternalServerError;

            result = new(statusCode, ["Ocorreu um erro inesperado"]);
        }
        
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(result);

        return true;
    }
}
