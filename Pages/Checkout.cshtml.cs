using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AD2_WEB_APP.Pages;

public class CheckoutModel : PageModel
{
    private readonly ILogger<CheckoutModel> _logger;
    public Int32 amount;
    public CheckoutModel(ILogger<CheckoutModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
     
        for (int i = 1; i < 55; i++)
        {
           
            var id = HttpContext.Session.GetInt32("id" + i);
            var price = HttpContext.Session.GetInt32("price" + i);
            if (id != null && price != null)
            {
                amount=(amount + Convert.ToInt32(price));
              
            }

        }
       
    }
}
