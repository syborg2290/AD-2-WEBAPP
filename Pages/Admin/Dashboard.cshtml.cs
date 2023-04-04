using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

public class DashboardModel : PageModel
{
    private readonly ILogger<DashboardModel> _logger;

    public DashboardModel(ILogger<DashboardModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
