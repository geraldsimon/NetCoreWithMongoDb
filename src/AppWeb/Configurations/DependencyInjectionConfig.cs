using Microsoft.Extensions.DependencyInjection;
using Mongo.Data.Repository;
using Mongo.Domain.Intefaces;

namespace AppWeb.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
             services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}