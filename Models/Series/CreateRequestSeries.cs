namespace AD2_WEB_APP.Models.Series;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestSeries
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int CategoryID { get; set; }

}