namespace AD2_WEB_APP.Models.Address;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestAddress
{
   
    [Required]
    public string Street_Address { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    [EmailAddress]
    public string State { get; set; }

    [Required]
    public string Zip_Code { get; set; }

     [Required]
    public string Country { get; set; }
 
}