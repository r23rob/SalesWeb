using System.ComponentModel.DataAnnotations;
using Moq;
using SalesWeb.Domain.Entities;
using SalesWeb.Domain.Interfaces;
using SalesWeb.Domain.Services;

namespace SalesWeb.UnitTests;

public class CustomerServiceTests
{
    private readonly Mock<ICustomerRepository> _mockRepository;
    private readonly CustomerService _customerService;

    public CustomerServiceTests()
    {
        _mockRepository = new Mock<ICustomerRepository>();
        _customerService = new CustomerService(_mockRepository.Object);
    }
    
    [Fact]
    public async Task CreateCustomer_WithValidDetails_ReturnsCreatedCustomer()
    {
        var customer = await _customerService.CreateCustomer("Rob", "Smith", "07954111222", "rob.smit@email.com");
        Assert.NotNull(customer);
    }
    
    [Fact]
    public async Task CreateCustomer_WithValidDetails_SetsAllPropertiesCorrectly()
    {
        var customer = await _customerService.CreateCustomer("Rob", "Smith", "07954111222", "rob.smit@email.com");
        Assert.Equal("Rob", customer.FirstName);
        Assert.Equal("Smith", customer.LastName);
        Assert.Equal("rob.smit@email.com", customer.Email);
        Assert.Equal("07954111222", customer.Phone);
    }
    
    [Fact]
    public async Task CreateCustomer_WithValidDetails_CallsCreateOnlyOnce()
    {
        var customer = await _customerService.CreateCustomer("Rob", "Smith", "07954111222", "rob.smit@email.com");
        _mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<Customer>()), Times.Once);
    }
    
    [Fact]
    public async Task CreateCustomerAsync_WithInvalidEmail_ThrowsValidationException()
    {
        var exception = await Assert.ThrowsAsync<ValidationException>(() => 
            _customerService.CreateCustomer("Rob", "Smith","07954111222", "rob.smit@email.com"));
        
        Assert.Equal("Invalid email format", exception.Message);
    }
    
    [Fact]
    public async Task CreateCustomerAsync_WithNullFirstName_ThrowsArgumentException()
    {
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => 
            _customerService.CreateCustomer(null, "Doe", "07954111222", "rob.smit@email.com"));

        Assert.Equal("firstName", exception.ParamName);
    }
    
    [Fact]
    public async Task CreateCustomerAsync_WithNullLastName_ThrowsArgumentException()
    {
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => 
            _customerService.CreateCustomer("Rob", null, "07954111222", "rob.smit@email.com"));

        Assert.Equal("lastName", exception.ParamName);
    }
    
    [Fact]
    public async Task CreateCustomerAsync_WithNullPhone_ThrowsArgumentException()
    {
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => 
            _customerService.CreateCustomer("Rob", "Smith",null, "rob.smit@email.com"));

        Assert.Equal("phone", exception.ParamName);
    }
    
    [Fact]
    public async Task CreateCustomerAsync_WithNullEmail_ThrowsArgumentNullException()
    {
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => 
            _customerService.CreateCustomer("Rob", "Smith","07954111222", null));

        Assert.Equal("email", exception.ParamName);
    }
}