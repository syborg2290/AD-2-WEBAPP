namespace AD2_WEB_APP.Models.Item;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestItem
{

    [Required]
    public string Name { get; set; }

    [Required]
    public int ConfigurationID { get; set; }

     [Required]
    public string ImagePath { get; set; }

}