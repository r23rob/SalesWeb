using SalesWeb.Domain.Entities;

namespace SalesWeb.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> CreateAsync(Customer customer);
}