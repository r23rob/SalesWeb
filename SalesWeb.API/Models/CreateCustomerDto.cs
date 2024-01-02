using System.ComponentModel.DataAnnotations;

namespace SalesWeb.API.Models;

public class CreateCustomerDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [StringLength(100)]
    public string LastName { get; set; }
    
    [Required]
    [Phone]
    public string Phone { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}