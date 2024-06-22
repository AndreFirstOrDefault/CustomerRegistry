using CustomerRegistry.Application.DTOs;

namespace CustomerRegistry.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDTO>> GetAll();
    Task<CustomerDTO> GetById(int? id);
    Task<IEnumerable<CustomerDTO>> GetByName(string name);
    Task Add(CustomerDTO customerDTO);
    Task Update(CustomerDTO customerDTO);
    Task Remove(int? id);
}
