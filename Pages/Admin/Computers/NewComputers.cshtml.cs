using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

public class NewComputersModel : PageModel
{
    private readonly ILogger<NewComputersModel> _logger;

    public NewComputersModel(ILogger<NewComputersModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
