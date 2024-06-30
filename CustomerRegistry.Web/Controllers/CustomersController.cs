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

        return View(customerDto);

    }


    
    public async Task<IActionResult> GetByName(string name)
    {
      
        if (string.IsNullOrEmpty(name))
        {
            return NotFound();
        }

        var customers = await _customerService.GetByName(name);

        ViewBag.Quantidade = customers.Count(); // Retorna um dado com a quantidade de itens encontrados

        return View("~/Views/Customers/GetByName.cshtml", customers); // Caminho da View e o objeto que será impresso
    }
        

}
