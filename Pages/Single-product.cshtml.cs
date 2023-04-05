using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages;

public class SigleProductModel : PageModel
{
    private readonly ILogger<SigleProductModel> _logger;

    public SigleProductModel(ILogger<SigleProductModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
