using CustomerRegistry.Application.Interfaces;
using CustomerRegistry.Application.Mappings;
using CustomerRegistry.Application.Services;
using CustomerRegistry.Domain.Interfaces;
using CustomerRegistry.Infra.Data.Context;
using CustomerRegistry.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerRegistry.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
     
        //options.UseMySql(configuration.GetConnectionString("DefaultConnection2"),
        //MySqlServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection2")),
        //                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
