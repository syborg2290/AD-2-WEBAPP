namespace AD2_WEB_APP.Entities;

using System.Text.Json.Serialization;

public class Configuration{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public string Description { get; set; } = null!;
    public double Price { get; set; } = 0.0!;
}