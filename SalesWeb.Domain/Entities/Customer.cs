namespace SalesWeb.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}