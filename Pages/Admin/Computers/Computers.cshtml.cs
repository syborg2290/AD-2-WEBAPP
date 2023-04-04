using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Services;
using AD2_WEB_APP.Models.ComputerModel;

namespace AD2_WEB_APP.Pages.Admin;

public class ComputersModel : PageModel
{
    private readonly ILogger<ComputersModel> _logger;

    private IComputerModelService _computerService;

    public ComputersModel(ILogger<ComputersModel> logger, IComputerModelService computerService)
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
