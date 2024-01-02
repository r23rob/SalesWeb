using Microsoft.AspNetCore.Mvc;
using SalesWeb.API.Models;
using SalesWeb.Domain.Entities;
using SalesWeb.Domain.Interfaces;

namespace SalesWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
    {
        try
        {
            // Should  use Automapper here
            var customer = new Customer()
            {
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Email = createCustomerDto.LastName,
                Phone = createCustomerDto.Phone
            };

            var newcustomer = await _customerService.CreateCustomer(createCustomerDto.FirstName, createCustomerDto.LastName, createCustomerDto.Phone, createCustomerDto.Email);

            return newcustomer;
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the customer");
        }
    }
}
