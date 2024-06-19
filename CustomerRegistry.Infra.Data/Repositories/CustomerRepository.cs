using CustomerRegistry.Domain.Entities;
using CustomerRegistry.Domain.Interfaces;
using CustomerRegistry.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomerRegistry.Infra.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _customerContext;

    public CustomerRepository(ApplicationDbContext context)
    {
        _customerContext = context;
    }

    public async Task<Customer?> Create(Customer customer)
    {
        _customerContext.Add(customer);
        await _customerContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> GetById(int? id)
    {
        return await _customerContext.Customers.FindAsync(id);
    }

    public async Task<IEnumerable<Customer?>> GetAll()
    {
        return await _customerContext.Customers.ToListAsync();
    }

    public async Task<IEnumerable<Customer?>> GetByName(string name)
    {
        return await _customerContext.Customers.Where(c => c.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
    }

    public async Task<Customer?> Remove(Customer customer)
    {
        _customerContext.Remove(customer);
        await _customerContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> Update(Customer customer)
    {
        _customerContext.Update(customer);
        await _customerContext.SaveChangesAsync();
        return customer;
    }
}
