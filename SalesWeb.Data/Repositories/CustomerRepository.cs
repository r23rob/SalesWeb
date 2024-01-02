using SalesWeb.Domain.Entities;

namespace SalesWeb.Data.Repositories;

public class CustomerRepository
{
    private readonly SalesWebDbContext _context;

    public CustomerRepository(SalesWebDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

}