using Moq;
using SalesWeb.Domain.Interfaces;
using SalesWeb.Domain.Services;

namespace SalesWeb.UnitTests;

public class UnitTest1
{
    [Fact]
    public async void Should_Create_New_Customer()
    {
        var customerRepository = new Mock<ICustomerRepository>();
        var customerService = new CustomerService(customerRepository.Object);

        var customer = await customerService.CreateCustomer("Rob", "Smith", "02392111222", "Rob.Smith@example.com");

        Assert.NotNull(customer);
        Assert.Equal("Rob", customer.FirstName);
    }
}