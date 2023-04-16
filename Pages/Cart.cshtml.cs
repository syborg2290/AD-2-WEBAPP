
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Text.Json;
namespace AD2_WEB_APP.Pages;

public class CartModel : PageModel
{
    private readonly ILogger<CartModel> _logger;

    public ArrayList cartList;
    public Int32 amount;
    public CartModel(ILogger<CartModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        amount=0;
        ArrayList myAL = new ArrayList();
        for (int i = 1; i < 55; i++)
        {
           
            var id = HttpContext.Session.GetInt32("id" + i);
            var price = HttpContext.Session.GetInt32("price" + i);
            if (id != null && price != null)
            {
                amount=(amount + Convert.ToInt32(price));
                // myAL.Add(id);
                
                myAL.Add(price);
            }

        }
        if (myAL != null)
        {
            cartList = myAL;
            var json2 = JsonSerializer.Serialize(cartList);
            //System.Console.Write(json2);
        }

    }
}