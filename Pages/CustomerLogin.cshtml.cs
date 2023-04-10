using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Models.Customer;
using AD2_WEB_APP.Services;


namespace AD2_WEB_APP.Pages;

public class CustomerLoginModel : PageModel
{
    private readonly ILogger<CustomerLoginModel> _logger;

    [BindProperty]
    public CustomerLogin Model { get; set; }
    private ICustomerService _customerService;

    public CustomerLoginModel(ILogger<CustomerLoginModel> logger, ICustomerService customerService)
    {
        _logger = logger;
    }

    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }


    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var data = Model;

            string token = _customerService.Authenticate(data);
           
            Type = "success";
            Message = "Customer created !";
            return Page();
        }
        catch (System.Exception e)
        {

            Type = "error";
            Message = e.Message;
            return Page();
        }


    }
}
