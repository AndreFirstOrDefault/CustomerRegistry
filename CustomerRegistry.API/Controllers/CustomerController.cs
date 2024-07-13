using CustomerRegistry.Application.DTOs;
using CustomerRegistry.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistry.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IDateService _dateService;

    public CustomerController(ICustomerService customerService, IDateService dateService)
    {
        _customerService = customerService;
        _dateService = dateService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
    {
        var customers = await _customerService.GetAll();
        if (customers == null)
        {
            return NotFound("Customers not found");
        }

        return Ok(customers);
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get(string name)
    {
        var customers = await _customerService.GetByName(name);
        
        if (customers == null)
        {
            return NotFound("Customers not found");
        }

        return Ok(customers);
    }

    // Nome alternativo GetCustomer usado no Post
    [HttpGet("{id:int}", Name = "GetCustomer")]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get(int id)
    {
        var customer = await _customerService.GetById(id);
        
        if (customer == null)
        {
            return NotFound("Customer not found");
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]CustomerDTO customerDTO)
    {
        if(customerDTO == null)
        {
            return BadRequest("Invalid data");
        }

        customerDTO.NextPaymentDate = _dateService.nextPay(customerDTO.LastPaymentDate, customerDTO.Plan ?? "");

        await _customerService.Add(customerDTO);

        //  return new CreatedAtRouteResult("NomeDoMétodo", new {id = ObjetoAdicionadoId}, TípoObjeto);
        return new CreatedAtRouteResult("GetCustomer", new {id = customerDTO.CustomerId}, customerDTO);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] CustomerDTO customerDTO)
    {
        if(id != customerDTO.CustomerId)
        {
            return BadRequest();
        }

        if(customerDTO == null)
        {
            return BadRequest();
        }

        customerDTO.NextPaymentDate = _dateService.nextPay(customerDTO.LastPaymentDate,customerDTO.Plan ?? "");

        await _customerService.Update(customerDTO);
        return Ok(customerDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CustomerDTO>> Delete(int id)
    {
        var customer = await _customerService.GetById(id);
        if(customer == null)
        {
            return NotFound("Customer not found");
        }

        await _customerService.Remove(id);
        return Ok(customer);
    }

}

