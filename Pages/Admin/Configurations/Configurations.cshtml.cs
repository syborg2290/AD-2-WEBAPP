using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AD2_WEB_APP.Services;

namespace AD2_WEB_APP.Pages.Admin;

public class ConfigurationsModel : PageModel
{
    private readonly ILogger<ConfigurationsModel> _logger;

    private ICategoryService _categoryService;
    private IConfigurationService _configurationService;

    public ConfigurationsModel(ILogger<ConfigurationsModel> logger, ICategoryService categoryService, IConfigurationService configurationService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _configurationService = configurationService;
    }

    [BindProperty]
    public Models.Configuration.CreateRequestConfiguration configuration { get; set; }

    public SelectList categories { get; set; }


    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }

    
    public void OnGet()
    {
        categories = _categoryService.GetAll();
        
    }

    public IActionResult OnPost()
    {
        try
        {
            var data = configuration;
            data.Price =  Convert.ToDouble(data.Price);


            _configurationService.Create(data);
            Type = "success";
            Message = "Configuration created !";
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
