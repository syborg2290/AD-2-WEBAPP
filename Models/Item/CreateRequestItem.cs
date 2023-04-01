namespace AD2_WEB_APP.Models.Item;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestItem
{

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int ConfigurationID { get; set; }

}