using Microsoft.Extensions.DependencyInjection;
using Products.Repository;
using Products.Repository.Interface;

namespace Products.Middleware.IoC
{
    public static class RepositoryModule
    {
        public static void SetModules(IServiceCollection container)
        {
            container.AddTransient<IProductRepository, ProductRepository>();
            container.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
