using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Models.Customer;
using AD2_WEB_APP.Services;

namespace AD2_WEB_APP.Pages;

public class CustomerRegisterModel : PageModel
{
    private readonly ILogger<CustomerRegisterModel> _logger;

    [BindProperty]
    public CreateRequestCustomer Model { get; set; }

    private ICustomerService _customerService;

    public CustomerRegisterModel(ILogger<CustomerRegisterModel> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        try
        {
            var data = Model;

            _customerService.Create(data);
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
