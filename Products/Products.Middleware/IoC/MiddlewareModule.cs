using Microsoft.Extensions.DependencyInjection;
using Products.API.Middleware;

namespace Products.Middleware.IoC
{
    public static class MiddlewareModule
    {
        public static void SetModules(IServiceCollection container)
        {
            container.AddTransient<ErrorHandlingMiddleware>();
        }
    }
}
