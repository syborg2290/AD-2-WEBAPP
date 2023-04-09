using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;

namespace AD2_WEB_APP.Pages.Admin;

[Authorize]
public class SeriesModel : PageModel
{
    private readonly ILogger<SeriesModel> _logger;

    private ICategoryService _categoryService;

    private ISeriesService _seriesService;

    public SeriesModel(ILogger<SeriesModel> logger,ICategoryService categoryService, ISeriesService seriesService)
    {
        _logger = logger;
         _categoryService = categoryService;
        _seriesService = seriesService;
    }

    [BindProperty]
    public Models.Series.CreateRequestSeries series { get; set; }

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
            var data = series;

            _seriesService.Create(data);
            Type = "success";
            Message = "Series created !";
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
