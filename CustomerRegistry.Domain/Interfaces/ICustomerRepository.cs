using CustomerRegistry.Domain.Entities;

namespace CustomerRegistry.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer?>> GetAll();
    Task<Customer?> GetById(int? id);
    Task<IEnumerable<Customer?>> GetByName(string name);

    Task<Customer?> Create(Customer customer);
    Task<Customer?> Update(Customer customer);
    Task<Customer?> Remove(Customer customer);
}
