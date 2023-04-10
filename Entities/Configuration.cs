namespace AD2_WEB_APP.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;  

[Index(nameof(Configuration.Name), IsUnique = true)]
public class Configuration{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public string Description { get; set; } = null;
    public double Price { get; set; } = 0.0!;

    public double ComparePrice { get; set; } = 0.0!;
}