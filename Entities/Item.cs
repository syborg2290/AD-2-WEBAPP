namespace AD2_WEB_APP.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

[Index(nameof(Item.Name), IsUnique = true)]
public class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ConfigurationID { get; set; }

    public string ImagePath { get; set; }
}