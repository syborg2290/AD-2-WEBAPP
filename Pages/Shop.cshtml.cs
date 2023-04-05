using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages;

public class ShopModel : PageModel
{
    private readonly ILogger<ShopModel> _logger;

    public ShopModel(ILogger<ShopModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
