namespace AD2_WEB_APP.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Image
{
    public string path { get; set; }
    public int id{ get; set; }
    public string description { get; set; }
    [NotMapped]
    public IFormFile file{ get; set; }
}