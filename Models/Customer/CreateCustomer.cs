namespace AD2_WEB_APP.Models.Customer;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateCustomer
{
    
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Phone_Number { get; set; }

    [Required]
    public int Billing_Address_ID { get; set; }

    [Required]
    public int Shipping_Address_ID { get; set; }

    
}