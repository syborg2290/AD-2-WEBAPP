namespace AD2_WEB_APP.Models.Users;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class UpdateRequest
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 

    [EnumDataType(typeof(Role))]
    public string Role { get; set; } 

    [EmailAddress]
    public string Email { get; set; }

    // treat empty string as null for password fields to 
    // make them optional in front end apps
    private string _password;
    [MinLength(6)]
    public string Password { get; set; } 

    private string _confirmPassword;
    [Compare("Password")]
    public string ConfirmPassword { get; set; } 

    // helpers

    private string replaceEmptyWithNull(string value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;
    }
}