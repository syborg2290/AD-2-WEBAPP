namespace AD2_WEB_APP.Models.Customer;

using System.ComponentModel.DataAnnotations;

public class CustomerLogin
{

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

}