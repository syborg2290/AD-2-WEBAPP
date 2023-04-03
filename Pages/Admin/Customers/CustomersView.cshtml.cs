using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

public class CustomersModel : PageModel
{
    private readonly ILogger<CustomersModel> _logger;

    public CustomersModel(ILogger<CustomersModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
