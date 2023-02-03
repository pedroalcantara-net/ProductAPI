using Microsoft.Extensions.DependencyInjection;
using Products.Middleware.IoC;

namespace Products.Middleware
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection container)
        {
            MiddlewareModule.SetModules(container);
            RepositoryModule.SetModules(container);
            ServiceModule.SetModules(container);
        }
    }
}
