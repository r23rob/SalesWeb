using SalesWeb.Domain.Entities;

namespace SalesWeb.Domain.Interfaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomer(string firstName, string lastName, string phone, string email);
}