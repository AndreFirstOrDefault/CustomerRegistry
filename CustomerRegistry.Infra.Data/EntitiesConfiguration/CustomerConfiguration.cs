using CustomerRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerRegistry.Infra.Data.EntitiesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.CustomerId);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(17).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.Plan).HasMaxLength(10).IsRequired();
        builder.Property(x => x.PlanPrice).HasPrecision(5,2).IsRequired();
        builder.Property(x => x.LastPaymentDate).IsRequired();

        builder.HasData(
            new Customer(1, "Antônio", "(22)5666-7856", "antonio@gmail.com", true, "Monthly", 30m, DateTime.Now),
            new Customer(2, "Beatriz", "(11)9455-1234", "beatriz@yahoo.com", false, "Annual", 120m, DateTime.Now.AddMonths(-1)),
            new Customer(3, "Carlos", "(21)9876-5432", "carlos@outlook.com", true, "Annual", 7.5m, DateTime.Now.AddDays(-10)),
            new Customer(4, "Daniela", "(31)9988-7766", "daniela@gmail.com", true, "Monthly", 25m, DateTime.Now.AddMonths(-2)),
            new Customer(5, "Eduardo", "(41)9234-5678", "eduardo@gmail.com", false, "Annual", 150m, DateTime.Now.AddMonths(-3))

        );
    }
}
