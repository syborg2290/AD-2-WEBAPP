namespace AD2_WEB_APP.Models.ComputerModel;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class GetRequestWithoutCategoryComputerModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Model_Name { get; set; }
    
    [Required]
    public List<Series> Series { get; set; }

    [Required]
    public List<Configuration> Configuration { get; set; }

}