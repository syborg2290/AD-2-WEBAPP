namespace AD2_WEB_APP.Models.Configuration;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestConfiguration
{

    [Required]
    public string Name { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double Price { get; set; }

}