namespace AD2_WEB_APP.Models.Customer;

using System.ComponentModel.DataAnnotations;

public class CreateRequestCustomer
{
   
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Phone_Number { get; set; }

    //Billing address details

    [Required]
    public string Street_Address_billing { get; set; }
    [Required]
    public string City_billing { get; set; }
    [Required]
    public string State_billing { get; set; }
    [Required]
    public string Zip_Code_billing { get; set; }
    [Required]
    public string Country_billing { get; set; }

    
     //Shipping address details

    [Required]
    public string Street_Address_shipping { get; set; }
    [Required]
    public string City_shipping { get; set; } 
    [Required]
    public string State_shipping { get; set; }
    [Required]
    public string Zip_Code_shipping { get; set; } 
    [Required]
    public string Country_shipping { get; set; } 
 
}