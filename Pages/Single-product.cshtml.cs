using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Services;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Models.ComputerModel;

namespace AD2_WEB_APP.Pages;

public class SigleProductModel : PageModel
{
    [BindProperty(Name = "id", SupportsGet = true)]
    public int Id { get; set; }
    private readonly ILogger<SigleProductModel> _logger;
    private IComputerModelService _computerService;
     public GetRequestComputerModel item { get; set; }

    public SigleProductModel(ILogger<SigleProductModel> logger,
    IComputerModelService computerService)
    {
        _logger = logger;
        _computerService = computerService;
    }

    public void OnGet()
    {
        if (Id==null)
        {
            item = _computerService.GetComputerById(1);
        }else
        {
            item = _computerService.GetComputerById(Id);
        }
        
    }
}
