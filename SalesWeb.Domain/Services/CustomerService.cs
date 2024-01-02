using System.ComponentModel.DataAnnotations;
using SalesWeb.Domain.Entities;
using SalesWeb.Domain.Interfaces;

namespace SalesWeb.Domain.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateCustomer(string firstName, string lastName, string phone, string email)
    {
        ValidateCustomerDetails(firstName, lastName, email, phone);
        
        var customer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Email = email
        };
        
        await _customerRepository.CreateAsync(customer);
        return customer;
    }
    
    private void ValidateCustomerDetails(string firstName, string lastName, string email, string phone)
    {
        // Note this would use a validation package like Fluent in the UI Layer and basic validation here
        // It would also be its own class
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name is required.", nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name is required.", nameof(lastName));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email is required", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Phone is invalid.", nameof(phone));
        }
        
        // Crude Example would use regexp or fluent validation really
        if (!email.Contains("@"))
        {
            throw new ArgumentException("Invalid email format", nameof(email));
        }
    }
}