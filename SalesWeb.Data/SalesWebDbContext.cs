using Microsoft.EntityFrameworkCore;
using SalesWeb.Domain.Entities;

namespace SalesWeb.Data;

public class SalesWebDbContext : DbContext
{
    public SalesWebDbContext(DbContextOptions<SalesWebDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}