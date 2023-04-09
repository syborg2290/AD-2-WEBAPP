namespace AD2_WEB_APP.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Register
{

    [Required]
    [DataType(DataType.EmailAddress)]

    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password and comfirm password did not match!")]
    public string ConfirmPassword { get; set; }


}