using Microsoft.Extensions.DependencyInjection;
using Products.Service;
using Products.Service.Interface;

namespace Products.Middleware.IoC
{
    public static class ServiceModule
    {
        public static void SetModules(IServiceCollection container)
        {
            container.AddTransient<IProductService, ProductService>();
            container.AddTransient<IUserService, UserService>();
        }
    }
}
