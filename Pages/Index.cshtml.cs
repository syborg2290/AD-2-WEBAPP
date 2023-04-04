using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Services;
using AD2_WEB_APP.Models.ComputerModel;
namespace AD2_WEB_APP.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IComputerModelService _computerService;
    public IndexModel(ILogger<IndexModel> logger,IComputerModelService computerService)
    {
        _logger = logger;
        _computerService = computerService;
    }
    public List<GetRequestComputerModel> itemList { get; set; }
    public void OnGet()
    {
        itemList = _computerService.GetAll();
    }
}
