using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

public class NewItemsModel : PageModel
{
    private readonly ILogger<NewItemsModel> _logger;

    public NewItemsModel(ILogger<NewItemsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
