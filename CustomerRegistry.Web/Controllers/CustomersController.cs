using CustomerRegistry.Application.DTOs;
using CustomerRegistry.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistry.Web.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
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
            
            await _customerService.Add(customerDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(customerDTO);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

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
