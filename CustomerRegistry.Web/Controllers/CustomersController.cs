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
}
