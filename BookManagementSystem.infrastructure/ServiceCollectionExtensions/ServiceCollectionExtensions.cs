using BookManagementSystem.Domain.Models;
using BookManagementSystem.infrastructure.DataAccess.Implementation;
using BookManagementSystem.infrastructure.DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSystem.infrastructure.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.AddScoped<IConnectionManager, ConnectionManager>();
            services.AddScoped<IDapperContext, DapperContext>();

            return services;
        }
    }
}

