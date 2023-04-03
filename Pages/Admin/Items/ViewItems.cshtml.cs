using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

public class ViewItemsModel : PageModel
{
    private readonly ILogger<ViewItemsModel> _logger;

    public ViewItemsModel(ILogger<ViewItemsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
