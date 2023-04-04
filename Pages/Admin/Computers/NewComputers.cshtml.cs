using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AD2_WEB_APP.Services;

namespace AD2_WEB_APP.Pages.Admin;

public class NewComputersModel : PageModel
{
    private readonly ILogger<NewComputersModel> _logger;

    private ISeriesService _seriesService;

    private IComputerModelService _computerService;

    private IConfigurationService _configurationService;

    public NewComputersModel(ILogger<NewComputersModel> logger, ISeriesService seriesService, IConfigurationService configurationService, IComputerModelService computerService)
    {
        _logger = logger;
        _seriesService = seriesService;
        _computerService = computerService;
        _configurationService = configurationService;
    }

    [BindProperty]
    public Models.ComputerModel.CreateRequestComputerModel computer { get; set; }

    public SelectList configurations { get; set; }

    public SelectList series { get; set; }

    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }


    public void OnGet()
    {
        series = _seriesService.GetAll();
        configurations = _configurationService.GetAll();

    }

    public IActionResult OnPost()
    {
        try
        {
            var data = computer;

            _computerService.Create(data);
            Type = "success";
            Message = "Computer created !";
            return Page();
        }
        catch (System.Exception)
        {

            Type = "error";
            Message = "Operation failed !";
            return Page();
        }

    }
}
