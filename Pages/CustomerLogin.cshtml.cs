using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Models.Customer;

namespace AD2_WEB_APP.Pages;

public class CustomerLoginModel : PageModel
{
    private readonly ILogger<CustomerLoginModel> _logger;

    [BindProperty]
    public CustomerLogin Model { get; set; }

    public CustomerLoginModel(ILogger<CustomerLoginModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
