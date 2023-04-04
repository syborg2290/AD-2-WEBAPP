namespace AD2_WEB_APP.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;  

[Index(nameof(Category.Name), IsUnique = true)]
public class Category{
    public int Id { get; set; }
 
    public string Name { get; set; } = null!;
}