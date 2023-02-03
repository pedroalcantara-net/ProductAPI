using Newtonsoft.Json;
using Products.Domain.Exceptions;
using System.Net;

namespace Products.API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ProductException productException)
            {
                await HandleProductExceptionAsync(context, productException);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleProductExceptionAsync(HttpContext context, Exception exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.NotFound;

            var response = JsonConvert.SerializeObject(exception.Message);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var response = JsonConvert.SerializeObject(exception.Message);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }
    }
}
