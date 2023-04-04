using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Services;
using AD2_WEB_APP.Models.ComputerModel;

namespace AD2_WEB_APP.Pages;

public class ShopModel : PageModel
{
    private readonly ILogger<ShopModel> _logger;
    private IComputerModelService _computerService;
    public ShopModel(ILogger<ShopModel> logger,IComputerModelService computerService)
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
