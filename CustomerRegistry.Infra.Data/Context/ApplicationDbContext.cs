using CustomerRegistry.Domain.Entities;
using CustomerRegistry.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistry.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
