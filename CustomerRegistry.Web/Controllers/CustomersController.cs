using CustomerRegistry.Application.DTOs;
using CustomerRegistry.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistry.Web.Controllers;
[Authorize]
public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IDateService _dateService;

    public CustomersController(ICustomerService customerService, IDateService dateService)
    {
        _customerService = customerService;
        _dateService = dateService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var customers = await _customerService.GetAll();
        return View(customers);
    }
        
    [HttpPost]
    public async Task<IActionResult> Create(CustomerDTO customerDTO)
    {
        if(ModelState.IsValid)
        {
            customerDTO.NextPaymentDate = _dateService.nextPay(customerDTO.LastPaymentDate, customerDTO.Plan);
            await _customerService.Add(customerDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(customerDTO);
    }

    [Authorize]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var customerDto = await _customerService.GetById(id);

        if(customerDto == null)
        {
            return NotFound();
        }
        
        return View(customerDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CustomerDTO customerDTO)
    {
        if (ModelState.IsValid)
        {
            customerDTO.NextPaymentDate = _dateService.nextPay(customerDTO.LastPaymentDate, customerDTO.Plan);
            await _customerService.Update(customerDTO);
            return RedirectToAction(nameof(Index));
        }
        return View(customerDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var customerDto = await _customerService.GetById(id);

        if(customerDto == null)
        {
            return NotFound();
        }

        return View(customerDto);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _customerService.Remove(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var customerDto = await _customerService.GetById(id);

       
        if(customerDto == null)
        {
            return NotFound();
        }
        var customer = new CustomerDTO();
        ViewBag.Date = customer.NextPaymentDate;
        return View(customerDto);

    }
     
    [HttpGet("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            ViewBag.Message = "Name parameter is required.";
            return View("Error");
            
        }

        var customers = await _customerService.GetByName(name);
        if (customers == null || !customers.Any())
        {
            ViewBag.Message = "No customers found with the given name.";
            return View("Error");
        }

        return View(customers);
    }   
       
    
}
