using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AD2_WEB_APP.Services;

namespace AD2_WEB_APP.Pages.Admin;

public class NewItemsModel : PageModel
{
    private readonly ILogger<NewItemsModel> _logger;

    private IConfigurationService _configurationService;

    private IItemService _itemService;

    public NewItemsModel(ILogger<NewItemsModel> logger,IConfigurationService configurationService, IItemService itemService)
    {
        _logger = logger;
        _configurationService = configurationService;
        _itemService = itemService;
    }

    [BindProperty]
    public Models.Item.CreateRequestItem item { get; set; }

    public SelectList configurations { get; set; }
    
    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }

    
    public void OnGet()
    {
        configurations = _configurationService.GetAll();
        
    }

    public IActionResult OnPost()
    {
        try
        {
            var data = item;

            _itemService.Create(data);
            Type = "success";
            Message = "Item created !";
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
