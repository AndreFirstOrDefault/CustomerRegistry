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
}
