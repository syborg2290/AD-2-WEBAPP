using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

public class ComputersModel : PageModel
{
    private readonly ILogger<ComputersModel> _logger;

    public ComputersModel(ILogger<ComputersModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
