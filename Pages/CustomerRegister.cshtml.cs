using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Models.Customer;

namespace AD2_WEB_APP.Pages;

public class CustomerRegisterModel : PageModel
{
    private readonly ILogger<CustomerRegisterModel> _logger;

    [BindProperty]
    public CreateRequestCustomer Model { get; set; }

    public CustomerRegisterModel(ILogger<CustomerRegisterModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
