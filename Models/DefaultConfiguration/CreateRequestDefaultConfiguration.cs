namespace AD2_WEB_APP.Models.DefaultConfiguration;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestDefaultConfiguration
{

    [Required]
    public int ConfigurationID { get; set; }

}