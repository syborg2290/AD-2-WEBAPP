namespace AD2_WEB_APP.Entities;

using System.Text.Json.Serialization;

public class Series{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryID { get; set; }
}