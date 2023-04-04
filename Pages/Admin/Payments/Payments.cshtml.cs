using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages.Admin;

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
