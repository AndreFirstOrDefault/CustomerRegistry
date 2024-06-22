using AutoMapper;
using CustomerRegistry.Application.DTOs;
using CustomerRegistry.Application.Interfaces;
using CustomerRegistry.Domain.Entities;
using CustomerRegistry.Domain.Interfaces;

namespace CustomerRegistry.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDTO>> GetAll()
    {
        var customers = await _customerRepository.GetAll();
        return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
    }

    public async Task<CustomerDTO> GetById(int? id)
    {
        var customer = await _customerRepository.GetById(id);
        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<IEnumerable<CustomerDTO>> GetByName(string name)
    {
        var customer = await _customerRepository.GetByName(name);
        return _mapper.Map<IEnumerable<CustomerDTO>>(customer);
    }

    public async Task Add(CustomerDTO customerDTO)
    {
        var customer = _mapper.Map<Customer>(customerDTO);
        await _customerRepository.Create(customer);
    }

    public async Task Update(CustomerDTO customerDTO)
    {
        var customer = _mapper.Map<Customer>(customerDTO);
        await _customerRepository.Update(customer);
    }

    public async Task Remove(int? id)
    {
        var customer = _customerRepository.GetById(id).Result;
        await _customerRepository.Remove(customer);
        
    }
   
}
