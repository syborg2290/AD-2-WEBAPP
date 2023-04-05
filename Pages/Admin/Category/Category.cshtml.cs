using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;

namespace AD2_WEB_APP.Pages.Admin;

[Authorize]
public class CategoryModel : PageModel
{
    private readonly ILogger<CategoryModel> _logger;
    private ICategoryService _categoryService;
    private ICommonService _commonService;

    public CategoryModel(ILogger<CategoryModel> logger, ICategoryService categoryService, ICommonService commonService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _commonService = commonService;
    }

    [BindProperty]
    public Models.Category.CreateRequestCategory category { get; set; }

    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        try
        {
            var data = category;
            
            _categoryService.Create(data);
            Type = "success";
            Message = "Category created !";
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
