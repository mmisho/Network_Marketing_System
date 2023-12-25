#nullable disable
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Application.Shared.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                var errorTypeName = ex.GetType().Name;
                response.ContentType = "application/json";

                switch (errorTypeName)
                {
                    case nameof(KeyNotFoundException):
                        await HandleKeyNotFoundException(ex as KeyNotFoundException, response);
                        break;
                    case nameof(InvalidOperationException):
                        await HandleInvalidOperationException(ex as InvalidOperationException, response);
                        break;
                    default:
                        await HandleUnknownException(ex, response);
                        break;
                }
            }
        }

        private async Task HandleKeyNotFoundException(KeyNotFoundException exception, HttpResponse response)
        {
            await HandleException(response, HttpStatusCode.NotFound, new List<string> { exception.Message }, "Key not found error");
        }

        private async Task HandleInvalidOperationException(InvalidOperationException exception, HttpResponse response)
        {
            await HandleException(response, HttpStatusCode.BadRequest, new List<string> { exception.Message });
        }

        private async Task HandleUnknownException(Exception exception, HttpResponse response)
        {
            await HandleException(response, HttpStatusCode.InternalServerError, new List<string> { exception.Message });
        }

        private async Task HandleException(
                HttpResponse response,
                HttpStatusCode httpStatusCode,
                IEnumerable<string> errors,
                string message = "Internal System Error")
        {
            var responseModel = new BaseExceptionResponse(message, httpStatusCode) { Errors = errors?.ToList() };
            response.StatusCode = (int)httpStatusCode;

            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}
