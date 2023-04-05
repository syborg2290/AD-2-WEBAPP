using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace AD2_WEB_APP.Pages.Admin;

[Authorize]
public class PaymentsModel : PageModel
{
    private readonly ILogger<PaymentsModel> _logger;

    public PaymentsModel(ILogger<PaymentsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
