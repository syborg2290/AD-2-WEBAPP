namespace AD2_WEB_APP.Models.Category;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestCategory
{

    [Required]
    public string Name { get; set; } = null!;

}