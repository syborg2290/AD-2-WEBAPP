using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AD2_WEB_APP.Helpers;


namespace AD2_WEB_APP.Pages.Admin;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    [BindProperty]
    public Login Model { get; set; }

    public LoginModel(ILogger<LoginModel> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User successfully signed in");
                if (returnUrl == null || returnUrl == "/")
                {
                    return RedirectToPage("/Admin/Dashboard");
                }
                else
                {
                    return RedirectToPage(returnUrl);
                }
            }
            else
            {
                _logger.LogWarning("Failed to sign in user: {0}", result.ToString());
            }
        }
        else
        {
            _logger.LogWarning("Invalid model state");
        }

        ModelState.AddModelError("", "Username or pasword incorrect!");
        return Page();
    }
}

