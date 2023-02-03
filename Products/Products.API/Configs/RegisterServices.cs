using Products.Middleware;

namespace Products.API.Configs
{
    public static class RegisterServices
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services)
        {
            Bootstrapper.RegisterServices(services);

            return services;
        }
    }
}
