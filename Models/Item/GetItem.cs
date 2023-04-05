namespace AD2_WEB_APP.Models.Item;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class GetRequestItem
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string ImagePath { get; set; }

    [Required]
    public List<Configuration> Configuration { get; set; }

    [Required]
    public List<Category> Category { get; set; }

}