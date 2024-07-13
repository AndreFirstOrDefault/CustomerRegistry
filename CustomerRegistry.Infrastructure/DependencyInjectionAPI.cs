using CustomerRegistry.Application.Interfaces;
using CustomerRegistry.Application.Mappings;
using CustomerRegistry.Application.Services;
using CustomerRegistry.Domain.Account;
using CustomerRegistry.Domain.Interfaces;
using CustomerRegistry.Infra.Data.Context;
using CustomerRegistry.Infra.Data.Identity;
using CustomerRegistry.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerRegistry.Infra.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(configuration.GetConnectionString("DefaultConnection2"),
        MySqlServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection2")),
                         b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDateService, DateService>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        services.AddIdentity<ApplicationUser, IdentityRole>().
                            AddEntityFrameworkStores<ApplicationDbContext>().
                            AddDefaultTokenProviders();

        services.AddScoped<IAuthenticate, AuthenticateService>();
        
        return services;
    }
}
