using SalesWeb.Domain.Entities;
using SalesWeb.Domain.Interfaces;

namespace SalesWeb.Domain.Services;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateCustomer(string firstName, string lastName, string phone, string email)
    {
        var customer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Email = email
        };
        // to Add Validation
        await _customerRepository.CreateAsync(customer);
        return customer;
    }
}