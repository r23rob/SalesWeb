namespace SalesWeb.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Should_Create_New_Customer()
    {
        var customerRepository = new Mock<ICustomerRepository>();
        var customerService = new CustomerService(customerRepository.Object);

        var customer = customerService.CreateCustomer("Rob", "Smith", "02392111222", "Rob.Smith@example.com");

        Assert.NotNull(customer);
        Assert.Equal("John", customer.FirstName);
        // Additional assertions...
    }
}